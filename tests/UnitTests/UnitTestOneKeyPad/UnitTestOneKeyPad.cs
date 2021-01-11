using Mahamudra.Cryptography.OneKeyPad;
using Mahamudra.Cryptography.OneKeyPad.CustomExtensions;
using Mahamudra.Cryptography.OneKeyPad.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestOneKeyPad
{
    [TestClass]
    public class UnitTestOneKeyPad
    {
        private IOneKeyPad _okp;
        [TestInitialize]
        public void Initialize()
        {
            this._okp = new OneKeyPad("teston", "chiave");
        }

        [TestMethod]
        public void CypherDeCypher_ShouldTransformToByteAndForth_True()
        {
            var cypher = _okp.Cypher();
            var decypher = _okp.DeCypher(cypher);
            Assert.AreEqual(cypher.Convert(), decypher.Convert());
        } 
 
    }
}
