using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MCBECore.Schema;
using System.Collections.Generic;

namespace MCBECoreTest
{
    [TestClass]
    public class DetermineCheetahTest
    {
        public DetermineCheetahTest()
        {
            json = Model.AnimalModel.GetJson();
        }

        [TestMethod, TestCategory("初期化")]
        public void モデルを正常にロードできている()
        {
            var identifier = new MCBECore.Identifier(json);

            var q = identifier.DescriptionToAsk();

            Assert.AreEqual("D1", q.id);
        }

        [TestMethod]
        public void チーターが判別できる()
        {
            var identifier = new MCBECore.Identifier(json);

            // R1: 体毛を持つ → ほ乳動物
            var q = identifier.DescriptionToAsk();
            Assert.AreEqual("D1", q.id);
            identifier.Answer(q, true);

            // R5
            q = identifier.DescriptionToAsk();
            Assert.AreEqual("D9", q.id);
            identifier.Answer(q, true);

            // R7
            q = identifier.DescriptionToAsk();
            Assert.AreEqual("D13", q.id);
            identifier.Answer(q, false);

            // R8
            q = identifier.DescriptionToAsk();
            Assert.AreEqual("D15", q.id);
            identifier.Answer(q, true);

            q = identifier.DescriptionToAsk();
            Assert.AreEqual("D16", q.id);
            identifier.Answer(q, false);

            // R9
            q = identifier.DescriptionToAsk();
            Assert.AreEqual("D18", q.id);
            identifier.Answer(q, true);

            // Determined!
            q = identifier.DescriptionToAsk();

            Assert.IsNull(q);
            Assert.AreEqual(MCBECore.Identifier.ResultState.Determined, identifier.State);
            Assert.AreEqual("チーターである", identifier.Determined.text);

        }

        [TestMethod]
        public void 一発でチーターが判別できる()
        {
            var identifier = new MCBECore.Identifier(json);

            identifier.Answer("D1", true); // 体毛を持つ
            identifier.Answer("D11", true); // 鋭い歯を持つ
            identifier.Answer("D12", true); // 鋭い爪を持つ
            identifier.Answer("D15", true); // 体の色は黄褐色
            identifier.Answer("D18", true); // 黒い斑点を持つ
            identifier.Answer("D13", false); // 蹄を持たない
            identifier.Answer("D16", false); // 黒いしまを持たない

            // Determined!
            var q = identifier.DescriptionToAsk();

            Assert.IsNull(q);
            Assert.AreEqual(MCBECore.Identifier.ResultState.Determined, identifier.State);
            Assert.AreEqual("チーターである", identifier.Determined.text);
        }

        [TestMethod]
        public void 最初候補は4つ()
        {
            var identifier = new MCBECore.Identifier(json);

            var expected = new List<string>() {
                "鳥類である", "有蹄動物である", "虎である", "チーターである"
            };

            Assert.AreEqual(4, identifier.Candidates.Count);
            Assert.IsTrue(identifier.Candidates.Select(d => d.text).SequenceEqual(expected));
        }

        [TestMethod]
        public void Determined時の候補は空()
        {
            var identifier = new MCBECore.Identifier(json);

            identifier.Answer("D1", true); // 体毛を持つ
            identifier.Answer("D11", true); // 鋭い歯を持つ
            identifier.Answer("D12", true); // 鋭い爪を持つ
            identifier.Answer("D15", true); // 体の色は黄褐色
            identifier.Answer("D13", false); // 蹄を持たない
            identifier.Answer("D18", true); // 黒い斑点を持つ
            identifier.Answer("D16", false); // 黒いしまを持たない

            Assert.AreEqual(0, identifier.Candidates.Count);
        }

        [TestMethod]
        public void ほ乳動物で有蹄動物でないとき候補は虎とチーター()
        {
            var identifier = new MCBECore.Identifier(json);

            identifier.Answer("D1", true); // 体毛を持つ
            identifier.Answer("D11", true); // 鋭い歯を持つ
            identifier.Answer("D12", true); // 鋭い爪を持つ
            identifier.Answer("D13", false); // 蹄を持たない

            var expected = new List<string>() {
                "虎である", "チーターである"
            };
            Assert.AreEqual(2, identifier.Candidates.Count);
            Assert.IsTrue(identifier.Candidates.Select(r => r.text).SequenceEqual(expected));
        }

        [TestMethod]
        public void 虎を判別できる()
        {
            var identifier = new MCBECore.Identifier(json);

            identifier.Answer("D1", true); // 体毛を持つ
            identifier.Answer("D11", true); // 鋭い歯を持つ
            identifier.Answer("D12", true); // 鋭い爪を持つ
            identifier.Answer("D15", true); // 体の色は黄褐色
            identifier.Answer("D13", false); // 蹄を持たない

            var q = identifier.DescriptionToAsk();
            Assert.AreEqual("D16", q.id); // 黒いしまを持つ
            identifier.Answer(q, true);

            q = identifier.DescriptionToAsk();
            Assert.AreEqual("D18", q.id); // 黒い斑点を持たない
            identifier.Answer(q, false);

            // Determined!
            q = identifier.DescriptionToAsk();

            Assert.IsNull(q);
            Assert.AreEqual(MCBECore.Identifier.ResultState.Determined, identifier.State);
            Assert.AreEqual("虎である", identifier.Determined.text);
        }

        [TestMethod]
        public void しまと斑点を同時に持つとき判別できない()
        {
            var identifier = new MCBECore.Identifier(json);

            identifier.Answer("D1", true); // 体毛を持つ
            identifier.Answer("D11", true); // 鋭い歯を持つ
            identifier.Answer("D12", true); // 鋭い爪を持つ
            identifier.Answer("D15", true); // 体の色は黄褐色
            identifier.Answer("D13", false); // 蹄を持たない
            identifier.Answer("D16", true); // 黒いしまを持つ
            identifier.Answer("D18", true); // 黒い斑点を持つ

            // Unknown...
            var q = identifier.DescriptionToAsk();

            Assert.IsNull(q);
            Assert.AreEqual(MCBECore.Identifier.ResultState.Unknown, identifier.State);

            var expected = new List<string>() {
                "虎である", "チーターである"
            };
            Assert.AreEqual(2, identifier.Candidates.Count);
            Assert.IsTrue(identifier.Candidates.Select(r => r.text).SequenceEqual(expected));
        }

        [TestMethod]
        public void ほ乳動物じゃなかったら残りは2ルール()
        {
            var identifier = new MCBECore.Identifier(json);
            var pObjId = new PrivateObject(identifier);

            // R1
            var q = identifier.DescriptionToAsk();
            Assert.AreEqual("D1", q.id);
            identifier.Answer(q, false);

            var count = ((Queue<MCBERule>)pObjId.GetField("candidateQueue")).Count;

            Assert.AreEqual(8, count);

            // R2
            q = identifier.DescriptionToAsk();
            Assert.AreEqual("D3", q.id);
            identifier.Answer(q, false);

            count = ((Queue<MCBERule>)pObjId.GetField("candidateQueue")).Count;

            Assert.AreEqual(2, count);

        }

        private readonly string json;

    }
}
