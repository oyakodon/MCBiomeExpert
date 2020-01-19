using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

using MCBECore.Schema;

namespace MCBECoreTest
{
    [TestClass]
    public class IdentifierTest
    {
        private readonly string testJson =
@"{
  ""_id"": ""1"",
  ""name"": ""テストモデル"",
  ""descriptions"": [
    {
      ""_id"": ""1"",
      ""is_internal"": false,
      ""comment"": null,
      ""text"": ""D1"",
      ""image"": null
    },
    {
      ""_id"": ""2"",
      ""is_internal"": true,
      ""comment"": null,
      ""text"": ""D2"",
      ""image"": null
    }
  ],
  ""rules"": [
    {
      ""_id"": ""1"",
      ""comment"": null,
      ""priority"": 1,
      ""antecedents"": {
        ""1"": true
      },
      ""consequents"": {
        ""2"": true
      }
    }
  ]
}";

        private readonly MCBEDescription TestD1;
        private readonly MCBEDescription TestD2;
        private readonly MCBERule TestR1;

        public IdentifierTest()
        {
            // D1
            TestD1 = new MCBEDescription();
            TestD1.id = "1";
            TestD1.text = "D1";

            // D2
            TestD2 = new MCBEDescription();
            TestD2.id = "2";
            TestD2.isInternal = true;
            TestD2.text = "D2";

            // R1
            TestR1 = new MCBERule();
            TestR1.id = "1";
            TestR1.priority = 1;
            TestR1.antecedents = new Dictionary<string, bool>() { { "1", true } };
            TestR1.consequents = new Dictionary<string, bool>() { { "2", true } };
        }

        [TestMethod, TestCategory("初期化")]
        public void モデルは正常にシリアライズできる()
        {
            var model = new MCBEModel();
            model.name = "テストモデル";
            model.id = "1";
            model.descriptions = new List<MCBEDescription>() { TestD1, TestD2 };
            model.rules = new List<MCBERule>() { TestR1 };

            var json = JsonConvert.SerializeObject(model, Formatting.Indented);

            Assert.AreEqual(testJson, json);
        }

        [TestMethod, TestCategory("初期化")]
        public void モデルのロードができる()
        {
            var identifier = new MCBECore.Identifier(testJson, loadOnly: true);

            var pObjId = new PrivateObject(identifier);
            var _model = (MCBEModel)pObjId.GetField("model");

            Assert.AreEqual("1", _model.id);
            Assert.AreEqual("テストモデル", _model.name);

            var expected_descs = new List<MCBEDescription>()
            {
                TestD1,
                TestD2
            };

            Assert.IsTrue(expected_descs.SequenceEqual(_model.descriptions, new DescriptionEqualityComparer()), "descriptionsが期待した内容と異なる");

            var expected_rules = new List<MCBERule>()
            {
                TestR1
            };
            Assert.IsTrue(expected_rules.SequenceEqual(_model.rules, new RuleEqualityComparer()), "rulesが期待した内容と異なる");

        }

        [TestMethod, TestCategory("初期化")]
        public void モデルロード時のconditionsは空()
        {
            var identifier = new MCBECore.Identifier(testJson);
            var pObjId = new PrivateObject(identifier);

            var conditions = (Dictionary<string, bool>)pObjId.GetField("conditions");
            Assert.AreEqual(0, conditions.Count(), "初期のconditionsの要素数が0ではない");
        }

        [TestMethod, TestCategory("初期化")]
        public void モデルロード時のcandidateQueueは全Ruleが入っている()
        {
            var identifier = new MCBECore.Identifier(testJson);
            var pObjId = new PrivateObject(identifier);

            var candidateQueue = (Queue<MCBERule>)pObjId.GetField("candidateQueue");
            Assert.AreEqual(1, candidateQueue.Count);
            Assert.IsTrue((new RuleEqualityComparer()).Equals(candidateQueue.Peek(), TestR1));
        }

        [TestMethod, TestCategory("初期化")]
        public void モデルロード時のStateはcontinue()
        {
            var identifier = new MCBECore.Identifier(testJson);

            Assert.AreEqual(MCBECore.Identifier.ResultState.Continue, identifier.State);
        }

        [TestMethod, TestCategory("初期化")]
        public void モデルロード時のDeterminedはnull()
        {
            var identifier = new MCBECore.Identifier(testJson);

            Assert.IsNull(identifier.Determined);
        }

        [TestMethod, TestCategory("初期化")]
        public void モデルロード時leavesSetにはD2のみが入っている()
        {
            var identifier = new MCBECore.Identifier(testJson);
            var pObjId = new PrivateObject(identifier);

            var leavesSet = (HashSet<string>)pObjId.GetField("leavesSet");
            Assert.AreEqual(1, leavesSet.Count);
            Assert.IsTrue(leavesSet.Contains(TestD2.id));
        }

        [TestMethod, TestCategory("初期化")]
        public void Ruleにのみ定義されているDescriptionがあったらExceptionを吐く()
        {
            var json =
@"
{
  ""_id"": ""1"",
  ""name"": ""テストモデル"",
  ""descriptions"": [
    {
      ""_id"": ""1"",
      ""text"": ""D1"",
      ""image"": null
    },
    {
      ""_id"": ""2"",
      ""text"": ""D2"",
      ""image"": null
    }
  ],
  ""rules"": [
    {
      ""_id"": ""1"",
      ""priority"": 1,
      ""antecedents"": {
        ""1"": true,
        ""3"": false
      },
      ""consequents"": {
        ""2"": true
      }
    }
  ]
}
";

            Action actDefine = () =>
            {
                var identifier = new MCBECore.Identifier(json);
            };

            Assert.ThrowsException<KeyNotFoundException>(actDefine);

        }

        [TestMethod, TestCategory("基本ロジック")]
        public void モデルロード時にverifyしても何も変わらない()
        {
            var identifier = new MCBECore.Identifier(testJson);
            var pObjId = new PrivateObject(identifier);

            pObjId.Invoke("verify");

            var conditions = (Dictionary<string, bool>)pObjId.GetField("conditions");
            Assert.AreEqual(0, conditions.Count(), "初期のconditionsの要素数が0ではない");

            var candidateQueue = (Queue<MCBERule>)pObjId.GetField("candidateQueue");
            Assert.AreEqual(1, candidateQueue.Count);
            Assert.IsTrue((new RuleEqualityComparer()).Equals(candidateQueue.Peek(), TestR1));
        }

        [TestMethod, TestCategory("testJson-Ask")]
        public void testJsonにおいてDescriptionToAsk1回目はD1を返す()
        {
            var identifier = new MCBECore.Identifier(testJson);

            Assert.IsTrue((new DescriptionEqualityComparer()).Equals(TestD1, identifier.DescriptionToAsk()));
        }

        [TestMethod, TestCategory("testJson-Ask")]
        public void testJsonにおいてDescriptionToAsk2回目はnullを返す()
        {
            var identifier = new MCBECore.Identifier(testJson);

            var d1 = identifier.DescriptionToAsk(); // 1
            identifier.Answer(d1, true); // d1, true
            Assert.IsNull(identifier.DescriptionToAsk()); // 2
        }

        [TestMethod, TestCategory("testJson-Answer-True")]
        public void testJsonにおいてD1をTrueでAnswerするとD1とD2がconditionsに入る()
        {
            var identifier = new MCBECore.Identifier(testJson);

            var d1 = identifier.DescriptionToAsk();
            identifier.Answer(d1, true);

            var pObjId = new PrivateObject(identifier);

            var conditions = (Dictionary<string, bool>)pObjId.GetField("conditions");
            Assert.AreEqual(2, conditions.Count());
            Assert.IsTrue(conditions.Contains(new KeyValuePair<string, bool>(TestD1.id, true)));
            Assert.IsTrue(conditions.Contains(new KeyValuePair<string, bool>(TestD2.id, true)));
        }

        [TestMethod, TestCategory("testJson-Answer-True")]
        public void testJsonにおいてD1をTrueでAnswerするとDescriptionToAskはnull()
        {
            var identifier = new MCBECore.Identifier(testJson);

            var d1 = identifier.DescriptionToAsk();
            identifier.Answer(d1, true);

            Assert.IsNull(identifier.DescriptionToAsk());
        }

        [TestMethod, TestCategory("testJson-Answer-True")]
        public void testJsonにおいてD1をTrueでAnswerするとDeterminedはD2を返しStateはDetermined()
        {
            var identifier = new MCBECore.Identifier(testJson);

            var d1 = identifier.DescriptionToAsk();
            identifier.Answer(d1, true);

            Assert.IsTrue((new DescriptionEqualityComparer()).Equals(TestD2, identifier.Determined));
            Assert.AreEqual(MCBECore.Identifier.ResultState.Determined, identifier.State);
        }

        [TestMethod, TestCategory("testJson-Answer-True")]
        public void testJsonにおいてD1をTrueでAnswerするとcandidateQueueは空()
        {
            var identifier = new MCBECore.Identifier(testJson);

            var d1 = identifier.DescriptionToAsk();
            identifier.Answer(d1, true);

            var pObjId = new PrivateObject(identifier);

            var candidateQueue = (Queue<MCBERule>)pObjId.GetField("candidateQueue");
            Assert.AreEqual(0, candidateQueue.Count());
        }

        [TestMethod, TestCategory("testJson-Answer-False")]
        public void testJsonにおいてD1をFalseでAnswerするとconditionsはFalseのD1とFalseのD2()
        {
            var identifier = new MCBECore.Identifier(testJson);

            var d1 = identifier.DescriptionToAsk();
            identifier.Answer(d1, false);

            var pObjId = new PrivateObject(identifier);

            var conditions = (Dictionary<string, bool>)pObjId.GetField("conditions");
            Assert.AreEqual(2, conditions.Count());
            Assert.IsTrue(conditions.ContainsKey("1"));
            Assert.IsFalse(conditions["1"]);
            Assert.IsTrue(conditions.ContainsKey("2"));
            Assert.IsFalse(conditions["2"]);

        }

        [TestMethod, TestCategory("testJson-Answer-False")]
        public void testJsonにおいてD1をFalseでAnswerするとcandidateQueueはR1が入ったまま()
        {
            var identifier = new MCBECore.Identifier(testJson);

            var d1 = identifier.DescriptionToAsk();
            identifier.Answer(d1, false);

            var pObjId = new PrivateObject(identifier);

            var candidateQueue = (Queue<MCBERule>)pObjId.GetField("candidateQueue");
            Assert.AreEqual(1, candidateQueue.Count());
            Assert.IsTrue((new RuleEqualityComparer()).Equals(candidateQueue.Peek(), TestR1));
        }

        [TestMethod, TestCategory("testJson-Answer-False")]
        public void testJsonにおいてD1をFalseでAnswerするとStateはUnknown()
        {
            var identifier = new MCBECore.Identifier(testJson);

            var d1 = identifier.DescriptionToAsk();
            identifier.Answer(d1, false);

            Assert.AreEqual(MCBECore.Identifier.ResultState.Unknown, identifier.State);
        }

        [TestMethod, TestCategory("testJson-Answer-False")]
        public void testJsonにおいてD1をFalseでAnswerするとDeterminedはnull()
        {
            var identifier = new MCBECore.Identifier(testJson);

            var d1 = identifier.DescriptionToAsk();
            identifier.Answer(d1, false);

            Assert.IsNull(identifier.Determined);
        }

        [TestMethod, TestCategory("基本ロジック")]
        public void priorityの値の小さいものから順に出てくる()
        {
            var json = Model.AnimalModel.GetJson();
            var identifier = new MCBECore.Identifier(json);

            var d = identifier.DescriptionToAsk();
            Assert.AreEqual("D1", d.id);
        }

        [TestMethod, TestCategory("基本ロジック")]
        public void 結論部がconditionsに追加されたときはそのルールを除外する()
        {
            var json = Model.AnimalModel.GetJson();
            var identifier = new MCBECore.Identifier(json);

            var d = identifier.DescriptionToAsk();
            Assert.AreEqual("D1", d.id);

            identifier.Answer(d, true);
            // R2がなくなるはず

            d = identifier.DescriptionToAsk();

            // Assert.IsTrue("D4" == d.id || "D9" == d.id);
            Assert.AreEqual("D9", d.id);
        }

        // priorityで対処することにした
        //[TestMethod, TestCategory("基本ロジック")]
        //public void 合致する仮定部の多いルールから先に出てくる()
        //{
        //    // priorityは次点に優先される

        //    var json = Model.AnimalModel.GetJson();
        //    var identifier = new MCBECore.Identifier(json);

        //    identifier.Answer("D1", true);
        //    identifier.Answer("D9", true);
        //    identifier.Answer("D15", true);

        //    var d = identifier.DescriptionToAsk();
        //    Assert.AreEqual("D16", d.id);
        //}

        [TestMethod, TestCategory("基本ロジック")]
        public void モデルロード時の候補はD2のみ()
        {
            var identifier = new MCBECore.Identifier(testJson);

            var expected = new List<string>() {
                "D2"
            };

            Assert.AreEqual(1, identifier.Candidates.Count);
            Assert.IsTrue(identifier.Candidates.Select(d => d.text).SequenceEqual(expected));
        }

        [TestMethod, TestCategory("基本ロジック")]
        public void Determined時にリセットをかけるとちゃんと初期状態に戻る()
        {
            var identifier = new MCBECore.Identifier(testJson);

            var d1 = identifier.DescriptionToAsk();
            identifier.Answer(d1, true);

            Assert.IsTrue((new DescriptionEqualityComparer()).Equals(TestD2, identifier.Determined));
            Assert.AreEqual(MCBECore.Identifier.ResultState.Determined, identifier.State);

            identifier.Reset();

            Assert.AreEqual(MCBECore.Identifier.ResultState.Continue, identifier.State);
            Assert.IsNull(identifier.Determined);
        }

        [TestMethod, TestCategory("基本ロジック")]
        public void Unknown時にリセットをかけてもちゃんと初期状態に戻る()
        {
            var identifier = new MCBECore.Identifier(testJson);

            var d1 = identifier.DescriptionToAsk();
            identifier.Answer(d1, false);

            Assert.IsNull(identifier.Determined);
            Assert.AreEqual(1, identifier.Candidates.Count);
            Assert.AreEqual(MCBECore.Identifier.ResultState.Unknown, identifier.State);

            identifier.Reset();

            Assert.IsNull(identifier.Determined);
            Assert.AreEqual(1, identifier.Candidates.Count);
            Assert.AreEqual(MCBECore.Identifier.ResultState.Continue, identifier.State);
        }

        // Description, Rule の同値評価関数
        // (通常はidが同じかどうかで判定するが、各fieldも判定することで厳密に判定する)

        class DescriptionEqualityComparer : IEqualityComparer<MCBEDescription>
        {
            public bool Equals(MCBEDescription d1, MCBEDescription d2)
            {
                return d1.id == d2.id
                    && d1.text == d2.text
                    && d1.image == d2.image;
            }

            public int GetHashCode(MCBEDescription obj)
            {
                return obj.id.GetHashCode();
            }
        }

        class RuleEqualityComparer : IEqualityComparer<MCBERule>
        {
            public bool Equals(MCBERule r1, MCBERule r2)
            {
                return r1.id == r2.id
                    && r1.priority == r2.priority
                    && r1.antecedents.SequenceEqual(r2.antecedents)
                    && r1.consequents.SequenceEqual(r2.consequents);
            }

            public int GetHashCode(MCBERule obj)
            {
                return obj.id.GetHashCode();
            }
        }


    }
}
