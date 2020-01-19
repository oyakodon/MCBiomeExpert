using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

using MCBECore.Schema;

namespace MCBECore
{
    public class Identifier
    {
        public Identifier(string json, bool loadOnly = false, bool shortcut = false)
        {
            model = loadModel(json);
            shortcutDeterminating = shortcut;

            if (!loadOnly)
            {
                init();
            }
        }

        public Identifier(MCBEModel _model, bool loadOnly = false, bool shortcut = false)
        {
            model = _model;
            shortcutDeterminating = shortcut;

            if (!loadOnly)
            {
                init();
            }
        }

        public void Reset()
        {
            init();
        }

        public void Answer(MCBEDescription desc, bool answer)
        {
            if (desc == null) throw new NullReferenceException();

            Answer(desc.id, answer);
        }

        public void Answer(string id, bool answer)
        {
            if (model == null) throw new NullReferenceException();
            if (State != ResultState.Continue) return;

            if (!conditions.ContainsKey(id))
            {
                conditions.Add(id, answer);
            }
            else
            {
                conditions[id] = answer;
            }
            verify();
        }

        public MCBEDescription DescriptionToAsk()
        {
            if (model == null) throw new NullReferenceException();
            if (State != ResultState.Continue) return null;

            var rule = candidateQueue.Peek();

            var nextAskId = rule.antecedents.First(c => !conditions.Contains(c)).Key;
            return model.descriptions.First(d => d.id == nextAskId);
        }

        public ResultState State { get; private set; }

        public MCBEDescription Determined { get; private set; }

        public List<MCBEDescription> Candidates
        {
            get
            {
                // 仮定部で使われていない結論部のid
                var ids = candidateQueue.Where(r => r.consequents.All(_r => leavesSet.Contains(_r.Key))).SelectMany(r => r.consequents).Select(r => r.Key);
                return model.descriptions.Where(d => ids.Contains(d.id)).ToList();
            }
        }


        public enum ResultState
        {
            Determined,
            Unknown,
            Continue
        }

        private MCBEModel loadModel(string json)
        {
            return JsonConvert.DeserializeObject<MCBEModel>(json);
        }

        private void verify()
        {
            // candidateQueueに存在する(仮定部が全部Trueとなる || 仮定部に一つでもFalseがある)Ruleの個数
            Func<int> countRemain = () =>
            {
                return candidateQueue.Count(r => r.antecedents.All(d => conditions.ContainsKey(d.Key) && conditions[d.Key] == d.Value))
                    + candidateQueue.Count(r => r.antecedents.Any(d => conditions.ContainsKey(d.Key) && conditions[d.Key] != d.Value));
            };

            var q = new Queue<MCBERule>();
            var leavesQ = new Queue<MCBERule>();
            var trash = new List<MCBERule>();

            while (countRemain() > 0)
            {
                q.Clear();
                leavesQ.Clear();
                trash.Clear();

                foreach (var rule in candidateQueue)
                {
                    // 既に結論部が導き出されていたらスキップ
                    if (rule.consequents.All(d => conditions.Contains(d)))
                    {
                        continue;
                    }

                    // 仮定部が全部Trueならconditionsに結論部を追加
                    if (rule.antecedents.All(d => conditions.ContainsKey(d.Key) && conditions[d.Key] == d.Value))
                    {
                        // 結論部が他に仮定部で使われていなければleavesQに追加
                        if (rule.consequents.All(d => leavesSet.Contains(d.Key)))
                        {
                            leavesQ.Enqueue(rule);
                            continue;
                        }

                        foreach (var d in rule.consequents)
                        {
                            conditions.Add(d.Key, d.Value);
                        }
                        continue;
                    }

                    // 仮定部に一つでもFalseがあったらcandidateに追加しない
                    if (rule.antecedents.Any(d => conditions.ContainsKey(d.Key) && conditions[d.Key] ^ d.Value))
                    {
                        trash.Add(rule);
                        continue;
                    }

                    // まだ尋ねてないものがあるのでqueueに戻す
                    q.Enqueue(rule);
                }

                // 他にDescriptionを導くRuleがなければFalseをconditionsに追加する
                foreach (var rule in trash)
                {
                    foreach (var d in rule.consequents)
                    {
                        if (model.descriptions.Find(_d => _d.id == d.Key).isInternal && !conditions.ContainsKey(d.Key) && !q.Any(x => x.consequents.ContainsKey(d.Key)))
                        {
                            conditions.Add(d.Key, !d.Value);
                        }
                    }
                }

                candidateQueue = new Queue<MCBERule>(q);
            }

            if (leavesQ.Count > 0)
            {
                if (candidateQueue.Count > 0)
                {
                    if (shortcutDeterminating && candidateQueue.Count == 1)
                    {
                        var _consequents = leavesQ.Dequeue().consequents;
                        foreach (var d in _consequents)
                        {
                            conditions.Add(d.Key, d.Value);
                        }
                        Determined = model.descriptions.First(d => d.id == _consequents.First().Key);

                        State = ResultState.Determined;

                        return;
                    }
                    
                    // 未だ尋ねていないDescがあれば、確定Qを候補Qに挿入して続行
                    foreach (var rule in leavesQ)
                    {
                        candidateQueue.Enqueue(rule);
                    }

                    return;
                }

                if (leavesQ.Count > 1)
                {
                    // すべて尋ねたが複数個のルールが残り絞り込めないため、Unknownを返す
                    candidateQueue = new Queue<MCBERule>(leavesQ);

                    State = ResultState.Unknown;
                    Determined = null;

                    return;
                }

                // 確定
                var consequents = leavesQ.Dequeue().consequents;
                foreach (var d in consequents)
                {
                    conditions.Add(d.Key, d.Value);
                }
                Determined = model.descriptions.First(d => d.id == consequents.First().Key);

                State = ResultState.Determined;

                return;
            }

            if (candidateQueue.Count == 0)
            {
                // 何も満たさなかったため、Unknown。検証用にcandidatesにはごみ箱の中身を戻しておく
                trash.ForEach(r => candidateQueue.Enqueue(r));

                State = ResultState.Unknown;
                Determined = null;
                return;
            }
        }

        private void init()
        {
            State = ResultState.Continue;
            Determined = null;

            conditions = new Dictionary<string, bool>();

            // candidateQueueにrulesをpriorityの順番に追加
            candidateQueue = new Queue<MCBERule>();

            model.rules.Sort((a, b) => a.priority - b.priority);
            var ids = model.descriptions.Select(_d => _d.id).ToList();
            foreach (var rule in model.rules)
            {
                if (rule.antecedents.Any(d => !ids.Contains(d.Key)) ||
                    rule.consequents.Any(d => !ids.Contains(d.Key)))
                {
                    throw new KeyNotFoundException("Rule中にのみ定義されているDescriptionがあります (対応するDescriptionがmodel.description中に存在しませんでした.)");
                }

                candidateQueue.Enqueue(rule);
            }

            // leaveSet: 求めたい結論・他に仮定部で使われていないDescription のset
            // (終了判定で使う)
            leavesSet = new HashSet<string>();
            foreach (var desc in model.descriptions)
            {
                if (!model.rules.Any(r => r.antecedents.Any(_r => _r.Key == desc.id)))
                {
                    leavesSet.Add(desc.id);
                }
            }

        }

        private bool shortcutDeterminating = false;
        private Dictionary<string, bool> conditions;
        private Queue<MCBERule> candidateQueue;
        private HashSet<string> leavesSet;
        private readonly MCBEModel model;

        //private int compareRule(MCBERule a, MCBERule b)
        //{
        //    if (a.antecedents.Count(d => conditions.ContainsKey(d.Key)) != b.antecedents.Count(d => conditions.ContainsKey(d.Key)))
        //    {
        //        return b.antecedents.Count(d => conditions.ContainsKey(d.Key)) - a.antecedents.Count(d => conditions.ContainsKey(d.Key));
        //    }

        //    return a.priority - b.priority;
        //}

    }
}
