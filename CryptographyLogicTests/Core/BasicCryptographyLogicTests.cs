using CryptographyLogic.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptographyLogicTests.Core
{
    [TestClass()]
    public class BasicCryptographyLogicTests
    {
        [TestMethod()]
        public void EnCryptographyTest()
        {
            const string plainText = "1234567abc";
            var logic = new BasicCryptographyLogic();
            var encryptText = logic.EnCryptography(plainText, "1111");
            Assert.AreEqual(plainText, logic.DeCryptographyy(encryptText, "1111"));
        }

        [TestMethod()]
        public void DeCryptographyyTest()
        {
            const string plainText = "1234567abc";
            const string deCryptText = "RVfqtbgcS4gn+vUPa21XBg==;E5PmsnSyieAUeMom3ZEIHQ==";
            var logic = new BasicCryptographyLogic();
            Assert.AreEqual(plainText, logic.DeCryptographyy(deCryptText, "1111"));
        }
    }
}