using Mahamudra.ParallelDots;
using Mahamudra.ParallelDots.Enumerations;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationTestsParallelDots
{

    [TestClass]
    public partial class IntegrationTestsParallelDots
    {
        private ApiClient _apiClient;
        IConfiguration _configuration { get; set; }

        public IntegrationTestsParallelDots()
        {
            // the type specified here is just so the secrets library can 
            // find the UserSecretId we added in the csproj file
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<IntegrationTestsParallelDots>();
            _configuration = builder.Build();
        }

        [TestInitialize]
        public void Initialize()
        {
            string secret = _configuration["ApiSecret"];
            if (string.IsNullOrEmpty(secret))
                secret = Environment.GetEnvironmentVariable("PARALLELDOTS_KEY");
            _apiClient = new ApiClient(secret);
        }

        [TestMethod]
        public async Task Abuse_ShouldReturn_True()
        {
            var result = await _apiClient.Abuse("Fuck yourself!");
            Assert.IsTrue(result.Abusive > 0.5);
            Thread.Sleep(1000);
            // slow calls, it seems there is
            // some kind of limit per sec for the same key
            // depending on the payment
            result = await _apiClient.Abuse("Nazi swastika");
            Assert.IsTrue(result.HateSpeech > 0.5);
            Thread.Sleep(1000);
            result = await _apiClient.Abuse("I am happy.");
            Assert.IsTrue(result.Neither > 0.5);
        }

        [TestMethod]
        public async Task AbuseBatch_ShouldReturn_True()
        {
            string json = @"[
  'Fuck yourself!',
  'Love yourself!',
  'Nazi swastika'
]";

            JArray list = JArray.Parse(json);
            var results = (await _apiClient.AbuseBatch(list)).Abuse;
            Assert.IsTrue(results[0].Abusive > 0.5);
            Assert.IsTrue(results[1].Neither > 0.5);
            Assert.IsTrue(results[2].HateSpeech > 0.5);
        }


        [TestMethod]
        public async Task CustomClassifier_ShouldReturn_True()
        {
            var text = "Le scelte di Andrea Pirlo e Luca Gotti per la gara che chiude la 15ª giornata di campionato";
            JArray category = JArray.Parse(@"['news', 'sport']");
            var results = await _apiClient.CustomClassifier(text, category, LangCode.Italian);
            var cat = results.Taxonomy.Where(x => x.Category == "sport").FirstOrDefault();
            Assert.IsTrue(cat.ConfidenceScore > 0.95);
        }


        [TestMethod]
        public async Task Emotion_ShouldReturn_True()
        {
            var text = "I love you!";
            var results = (await _apiClient.Emotion(text));
            Assert.IsTrue(results.Emotion.Happy > 0.5);
            Assert.IsTrue(results.Emotion.Sad < 0.5);
        }

        [TestMethod]
        public async Task EmotionItalian_ShouldReturn_True()
        {
            var text = "Sei un sacchetto!!!";
            var results = (await _apiClient.Emotion(text, LangCode.Italian));
            Assert.IsTrue(results.Emotion.Angry > 0.5);
        }

        [TestMethod]
        public async Task EmotionBatch_ShouldReturn_True()
        {
            string json = @"[
  'Fuck yourself!',
  'Love yourself!' 
]";

            JArray list = JArray.Parse(json);
            var results = ((await _apiClient.EmotionBatch(list))).Emotion;
            Assert.IsTrue(results[0].Angry > 0.5);
            Assert.IsTrue(results[1].Happy > 0.5);
        }

        [TestMethod]
        public async Task Intent_ShouldReturn_True()
        {
            var text = "I love cats.";
            var results = await _apiClient.Intent(text);
            Assert.IsTrue(results.Intent.Spam > 0.2);
            text = "Where are you from?";
            results = await _apiClient.Intent(text);
            Assert.IsTrue(results.Intent.Query > 0.8);
        }

        [TestMethod]
        public async Task IntentBatch_ShouldReturn_True()
        {
            string json = @"[
  'Now whenever my parents shout at me, I put on these great headphones and listen to David Hasselhoff',
  'Do you love cats?'
]";
            JArray list = JArray.Parse(json);
            var results = (await _apiClient.IntentBatch(list)).Intent;
            Assert.IsTrue(results[0].Intent.Spam > 0.3);
            Assert.IsTrue(results[1].Intent.Query > 0.7);
        }

        [TestMethod]
        public async Task Keywords_ShouldReturn_True()
        {
            var text = "Where are you from?";
            var results = await _apiClient.Keywords(text);
            Assert.IsTrue(results.Keywords == null);
            Thread.Sleep(1000);
            text = @"I\'ll devote a couple of posts to this issue.  In this one I\'ll talk about how it is widely thought and claimed that in fact this is a widespread pagan idea. ";
            results = await _apiClient.Keywords(text);
            Assert.IsTrue(results.Keywords.Count > 0);
            var issue = results.Keywords.Where(x => x.Keyword == "issue").FirstOrDefault();
            Assert.AreEqual(issue.Keyword, "issue");
            Assert.IsTrue(Convert.ToDouble(issue.ConfidenceScore) > 0.5);
        }

        [TestMethod]
        public async Task Ner_ShouldReturn_True()
        {
            var text = "James is a doctor";
            var results = (await _apiClient.Ner(text));
            Assert.IsTrue(results.Entities[0].Category == "name");
            Assert.IsTrue(results.Entities[0].ConfidenceScore > 0.9);
        }

        [TestMethod]
        public async Task NerBatch_ShouldReturn_True()
        {
            string json = @"[
  'Now whenever my parents shout at me, I put on these great headphones and listen to David Hasselhoff',
  'Do you love cats?'
]";
            JArray list = JArray.Parse(json);
            var results = (await _apiClient.NerBatch(list));
            Assert.IsTrue(results.Entities[0].Count > 0);
            Assert.IsTrue(results.Entities[1].Count == 0);
        }

        [TestMethod]
        public async Task Sarcasm_ShouldReturn_True()
        {
            var text = "I am proficient at sarcasm.";
            var results = (await _apiClient.Sarcasm(text, LangCode.English));
            Assert.IsTrue(results.Sarcastic > 0.7);
        }

        [TestMethod]
        public async Task Sentiment_ShouldReturn_True()
        {
            var text = "I love you.";
            var results = (await _apiClient.Sentiment(text, LangCode.English));
            Assert.IsTrue(results.Sentiment.Positive >= 0.5);
        }

        [TestMethod]
        public async Task SentimentBatch_ShouldReturn_True()
        {
            string json = @"[
  'I need you',
  'I hate you'
]";
            JArray list = JArray.Parse(json);
            var results = (await _apiClient.SentimentBatch(list, LangCode.English));
            Assert.IsTrue(results.Sentiment[0].Neutral > 0.5);
            Assert.IsTrue(results.Sentiment[1].Negative > 0.5);
        }


        [TestMethod]
        public async Task PhraseExtractorBatch_ShouldReturn_True()
        {
            string json = @"[
  'Now whenever my parents shout at me, I put on these great headphones and listen to David Hasselhoff',
  'Do you love cats?'
]";
            JArray list = JArray.Parse(json);
            var results = await _apiClient.PhraseExtractorBatch(list);

            Assert.IsTrue(results.Phrases[0].Count > 0);
            Assert.IsTrue(results.Phrases[1].Count == 0);
        }

        [TestMethod]
        public async Task PhraseExtractor_ShouldReturn_True()
        {
            var text = "The fool doth think he is wise, but the wise man knows himself to be a fool.";
            var results = (await _apiClient.PhraseExtractor(text));
            Assert.IsTrue(results.Keywords.Count > 0);
        }

        [TestMethod]
        public async Task PhraseExtractorItalian_ShouldReturn_True()
        {
            var text = @"C'è qualcosa di nuovo oggi nel sole,
anzi d'antico: io vivo altrove, e sento
che sono intorno nate le viole.";
            var results = await _apiClient.PhraseExtractor(text, LangCode.Italian);
            Assert.IsTrue(results.Keywords.Count > 0);
        }


        [TestMethod]
        public async Task SarcasmBatch_ShouldReturn_True()
        {
            string json = @"[
  'I am proficient at sarcasm.',
  'I am not'
]";
            JArray list = JArray.Parse(json);
            var results = (await _apiClient.SarcasmBatch(list));
            Assert.IsTrue(results[0].Sarcastic > 0.7);
            Assert.IsTrue(results[1].Sarcastic > 0.6);
        }


        [TestMethod]
        public async Task TaxonomyBatch_ShouldReturn_True()
        {
            string json = @"[
  'I am proficient at sarcasm.',
  'I am not'
]";
            JArray list = JArray.Parse(json);
            var results = await _apiClient.TaxonomyBatch(list);
            Assert.IsTrue(results.Taxonomy[0].Count > 0);
            Assert.IsTrue(results.Taxonomy[1].Count > 0);
        }

        [TestMethod]
        public async Task Taxonomy_ShouldReturn_True()
        {
            var text = "Trump is president";
            var results = await _apiClient.Taxonomy(text);
            Assert.IsTrue(results.Taxonomy.Where(x => x.Tag == "POLITICS").FirstOrDefault().ConfidenceScore > 0.2);
        }

        [TestMethod]
        public async Task Similarity_GivenTwoTextsShouldReturnHighSimilarityScore_True()
        {
            var text1 = "Trump is president";
            var text2 = "Macron is president";
            var results = await _apiClient.Similarity(text1, text2);
            Assert.IsTrue(results.SimilarityScore > 0.7);
        }

        [TestMethod]
        public async Task Usage_ShouldReturnDailyBillableHits_True()
        {
            var results = await _apiClient.Usage();
            Assert.IsTrue(results.DailyBillableHits > 0);
        }
    }
}
