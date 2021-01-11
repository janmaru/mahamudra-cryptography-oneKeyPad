using Mahamudra.Cryptography.Random;
using Mahamudra.Cryptography.Random.CustomExtensions;
using Mahamudra.ParallelDots;
using Mahamudra.Text.Analysis;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTestRandom
{
    [TestClass]
    public class UnitTestTextAnalyze
    {
        private TextAnalyzer _text;
        private ApiClient _apiClient;
        private readonly Rnd _random;
        IConfiguration _configuration { get; set; }

        public UnitTestTextAnalyze()
        {
            // the type specified here is just so the secrets library can 
            // find the UserSecretId we added in the csproj file
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<UnitTestTextAnalyze>();
            _configuration = builder.Build();
            this._random = new Rnd();
        }

        [TestInitialize]
        public void Initialize()
        {
            string secret = _configuration["ApiSecret"];
            if (string.IsNullOrEmpty(secret))
                secret = Environment.GetEnvironmentVariable("PARALLELDOTS_KEY");
            _apiClient = new ApiClient(secret);
            this._text = new TextAnalyzer(_apiClient);
        }

        [TestMethod]
        public async Task HighEntropy_ShouldReturn_True()
        {
            string randomKey = _random.RandomString(255);
            var result = await _text.HighEntropy(randomKey);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void FailsFrequency_ShouldFailEnglishFrequencyLetters_True()
        {
            string randomKey = _random.RandomString(255);
            var result = _text.FailsFrequency(randomKey);
            Assert.IsTrue(result);
        }
    }
}
