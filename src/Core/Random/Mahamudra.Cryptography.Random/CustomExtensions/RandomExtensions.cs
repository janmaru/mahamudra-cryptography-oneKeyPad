using System.Collections.Generic;
using System.Linq;

namespace Mahamudra.Cryptography.Random.CustomExtensions
{
    public static class RandomExtensions
    {
        public static Dictionary<char, int> FrequencyLetters(this string text)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (char t in text)
            {
                if (!dic.TryAdd(t, 1))
                    dic[t]++;
            }
            return dic;
        }

        public static bool IsFairlyRandom(this string randomString, int limit)
        {
            var frequency = randomString.FrequencyLetters();
            var max = frequency.OrderByDescending(x => x.Value).Select(x => x.Value).FirstOrDefault();
            // if the number of any letter doesn't show up {limit} times, then it's fairly ok.
            return max <= limit;
        }
    }
}
