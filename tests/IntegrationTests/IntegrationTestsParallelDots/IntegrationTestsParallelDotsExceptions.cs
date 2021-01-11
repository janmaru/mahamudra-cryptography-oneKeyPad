using Mahamudra.ParallelDots.Enumerations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Threading.Tasks;

namespace IntegrationTestsParallelDots
{
    public partial class IntegrationTestsParallelDots
    {
        private string dir = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task FacialEmotionUrl_ShouldThrowException_True()
        {
            //// Greta Thunberg
            var url = "https://upload.wikimedia.org/wikipedia/commons/1/14/Greta_Thunberg_au_parlement_europ%C3%A9en_%2833744056508%29%2C_recadr%C3%A9.png";
            await _apiClient.FacialEmotionUrl(url); 
        } 
   
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task LanguageDetection_ShouldThrowException_True()
        {
            var text = "Questa è una frase in un linguaggio sconosciuto.";
            await _apiClient.LanguageDetection(text); 
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task LanguageDetectionBatch_ShouldThrowException_True()
        {
            string json = @"[
  'Now whenever my parents shout at me, I put on these great headphones and listen to David Hasselhoff',
  'Do you love cats?'
]";
            JArray list = JArray.Parse(json);
            await _apiClient.LanguageDetectionBatch(list);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task FacialEmotion_ShouldThrowException_True()
        {
            var file = Path.Combine(dir, "greta.jpg");
            await _apiClient.FacialEmotion(file);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task Nsfw_ShouldThrowException_True()
        {
            var file = Path.Combine(dir, "greta.jpg");
            await _apiClient.Nsfw(file);
        } 


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task NsfwUrl_ShouldThrowException_True()
        {
            //// Greta Thunberg
            var url = "https://upload.wikimedia.org/wikipedia/commons/1/14/Greta_Thunberg_au_parlement_europ%C3%A9en_%2833744056508%29%2C_recadr%C3%A9.png";
            await _apiClient.NsfwUrl(url);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task ObjectRecognizer_ShouldThrowException_True()
        {
            var file = Path.Combine(dir, "greta.jpg");
            await _apiClient.ObjectRecognizer(file);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task ObjectRecognizerUrl_ShouldThrowException_True()
        {
            //// Greta Thunberg
            var url = "https://upload.wikimedia.org/wikipedia/commons/1/14/Greta_Thunberg_au_parlement_europ%C3%A9en_%2833744056508%29%2C_recadr%C3%A9.png";
            await _apiClient.ObjectRecognizerUrl(url);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task PopularityUrl_ShouldThrowException_True()
        {
            //// Greta Thunberg
            var url = "https://upload.wikimedia.org/wikipedia/commons/1/14/Greta_Thunberg_au_parlement_europ%C3%A9en_%2833744056508%29%2C_recadr%C3%A9.png";
            await _apiClient.PopularityUrl(url);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task Popularity_ShouldThrowException_True()
        {
            var file = Path.Combine(dir, "greta.jpg");
            await _apiClient.Popularity(file);
        } 
 
 
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task TextParser_ShouldThrowException_False()
        {
            var text = "James is a doctor";
            var result = await _apiClient.TextParser(text);
            if (result.Contains("Bad Gateway"))
                throw new Exception();
        } 
 
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task TargetSentiment_ShouldThrowExceptionTrue()
        {
            var text = "Trump is president";
            var entity = "POLITICS";
            await _apiClient.TargetSentiment(text, entity, LangCode.English);
        }  
    }
}
