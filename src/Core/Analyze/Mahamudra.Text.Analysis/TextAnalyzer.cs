using Mahamudra.Cryptography.Random.CustomExtensions;
using Mahamudra.ParallelDots;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahamudra.Text.Analysis
{
    public class TextAnalyzer
    {
        private readonly ApiClient _apiClient;
        public TextAnalyzer(ApiClient apiClient)
        {
            this._apiClient = apiClient;
        }

        public async Task<bool> HighEntropy(string vernamKey)
        {
            return await FailsNLP(vernamKey) && FailsFrequency(vernamKey);
        }

        public async Task<bool> FailsNLP(string vernamKey)
        {
            var abuse = await _apiClient.Abuse(vernamKey);
            var result = abuse.Abusive <= 0.1
                && abuse.HateSpeech <= 0.1
                && abuse.Neither >= 0.98;
            var emotion = (await _apiClient.Emotion(vernamKey));
            result = result
                && emotion.Emotion.Angry <= 0.3
                && emotion.Emotion.Bored <= 0.3
                && emotion.Emotion.Excited <= 0.3
                && emotion.Emotion.Fear <= 0.3
                && emotion.Emotion.Happy <= 0.3
                && emotion.Emotion.Sad <= 0.3;
            return result;
        }

        public bool FailsFrequency(string vernamKey)
        {
            var enFreq = LettersEnglish.Frequency;
            var realFreq = vernamKey.FrequencyLetters();
            List<bool> checks = new List<bool>();
            foreach (var pair in realFreq)
            {
                var rfew = enFreq.Where(x => x.Key == pair.Key).Select(x => x.Value).FirstOrDefault();
                if (rfew - pair.Value / (double)vernamKey.Length > 0.1)
                    checks.Add(true);
                else
                    checks.Add(false);
            }
            var t = checks.Where(x => x == true).Select(x => 1).ToList().Sum();
            var f = checks.Where(x => x == false).Select(x => 1).ToList().Sum();

            return f > t;
        }
    }
}
