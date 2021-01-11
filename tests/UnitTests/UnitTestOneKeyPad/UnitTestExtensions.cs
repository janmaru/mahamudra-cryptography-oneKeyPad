using Mahamudra.Cryptography.OneKeyPad.CustomExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestOneKeyPad
{
    [TestClass]
    public class UnitTestExtensions
    { 
        [TestMethod]
        public void ToByteToString_ShouldTransformToByteAndForth_True()
        {
            string input = "Iosonobelloèèèè";
            var bytes  = input.ToBytes();
            var stringa = bytes.ToText();
            Assert.AreEqual(stringa, input);
        }  
    }
}
