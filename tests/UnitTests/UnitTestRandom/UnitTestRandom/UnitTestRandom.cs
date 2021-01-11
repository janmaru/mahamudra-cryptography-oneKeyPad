using Mahamudra.Cryptography.Random;
using Mahamudra.Cryptography.Random.CustomExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestRandom
{
    [TestClass]
    public class UnitTestRandom
    {
        private Rnd _random;
        [TestInitialize]
        public void Initialize()
        {
            this._random = new Rnd();
        }

        [TestMethod]
        public void RandomString_ShouldReturnANonEmptyRandomString_True()
        {
            string randomString = _random.RandomString(5);
            Assert.IsTrue(!string.IsNullOrEmpty(randomString));
        }

        [TestMethod]
        public void FrequencyLetters_ShouldReturnRightFrequencyInText_True()
        {
            string randomString = "aaaaafdnfndsaodnsdosa";
            var frequency = randomString.FrequencyLetters();
            var frequencya = frequency.Where(x => x.Key == 'a').Select(x => x.Value).FirstOrDefault();
            Assert.AreEqual(frequencya, 7);
            var frequencyn = frequency.Where(x => x.Key == 'n').Select(x => x.Value).FirstOrDefault();
            Assert.AreEqual(frequencyn, 3);
            var frequencyd = frequency.Where(x => x.Key == 'd').Select(x => x.Value).FirstOrDefault();
            Assert.AreEqual(frequencyd, 4);
        }

        /// <summary>Does a string look random? 
        /// It's very hard to define what looks random.
        /// So it used frequency in order to decide.</summary>
        [TestMethod]
        public void IsFairlyRandom_ShouldReturnAFairlyRandomString_True()
        {
            var count = 0;
            var space = 52;
            var limit = 4; // given the {space} of 26 letters*2 = 52 
            var repetition = 10;
            List<bool> check = new List<bool>();
            while (count <= repetition)
            {
                string randomString = _random.RandomString(space);
                check.Add(randomString.IsFairlyRandom(limit));
                count++;
            }

            var countOccurencies = check.Where(x => x == true).Count(x => x);
            // if the number of any letter doesn't show up max {limit} times out of bigger or equal 80% of {repetition} times, 
            // then it's fairly ok.
            var perCent = repetition * 0.6;
            Assert.IsTrue(countOccurencies >= perCent);
        }
    }
}
