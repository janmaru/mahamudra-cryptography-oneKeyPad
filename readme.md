# One Key Pad
![alt text](stephanie-ortiz.jpg "Mahamudra Cryptography OneKeyPad")
[Photo by  Stephanie Ortiz on Unsplash]

A simple package that implements safe, random, one key pad cryptography.

## Usage

```c#
        public BitArray Cypher()
        {
            var t = _text.GetKeyBitArray();
            var c = t.Xor(_key.GetKeyBitArray());
            _cypher = new Cypher(c);
            return c;
        }

        public BitArray DeCypher(BitArray cypher)
        {
            var ab = _cypher.GetKeyBitArray();
            var t = _text.GetKeyBitArray();
            return ab.Xor(t);
        }

        [TestMethod]
        public void CypherDeCypher_ShouldTransformToByteAndForth_True()
        {
            var cypher = _okp.Cypher();
            var decypher = _okp.DeCypher(cypher);
            Assert.AreEqual(cypher.Convert(), decypher.Convert());
        } 
```

In cryptography, the one-time pad (OTP) is an encryption technique that cannot be cracked, but requires the use of a one-time pre-shared key the same size as, or longer than, the message being sent.  

The resulting ciphertext will be impossible to decrypt or break if the following four conditions are met:

1. The key must be **truly random**.
2. The key must be at least as long as the plaintext.
3. The key must never be reused in whole or in part.
4. The key must be kept completely secret.

## Test 

```c#
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

```
```c#

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
            var perCent = repetition * 0.8;
            Assert.IsTrue(countOccurencies >= perCent);
        }
```
 Does a string look random? 
 It's very hard to define what looks random.
 Aside from using frequency to decide whether it is or not, we're going to use **NLP** in order to inquire patterns into the text.

# Text Analysis
To detect any intention in the wannabe text for the **Vernam Key** we're going to text:
1. if the frequency of the letters, in a given natural language, (in this case English) is "natural" or random.
2. if inside the text that represents the Vernam Key we could detect any human natural language meaningful text.
```c#
        public async Task<bool> HighEntropy(string vernamKey)
        {
            return await FailsNLP(vernamKey) && FailsFrequency(vernamKey);
        }

        [TestMethod]
        public async Task HighEntropy_ShouldReturn_True()
        {
            string randomKey = _random.RandomString(255);
            var result = await _text.HighEntropy(randomKey);
            Assert.IsTrue(result);
        }
```
# ParallelDots
![alt text](markus-spiske.jpg "ParallelDots")
[Photo by Markus Spiske on Unsplash]

A simple package wrapper to ParallelDots services at [https://www.paralleldots.com/](https://www.paralleldots.com/)
Image Recognition For Perfect Retail Execution. 
## Usage
### Abuse:
Protect abusive and offensive language in your forums or portals. This API identifies offensive language with 98% accuracy and helps you in fighting online abuse and spam.

```c#
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
```

### Custom Classifier
This classifier for text classification relies on Zero-Shot learning technique called as Custom Classifier. Our base model is trained on a large news corpus of 10 million news articles to discover relationships between sentences and their categories. The resulting model can then generalize on new, unseen categories as well not available in training data. Custom Classifier 2.0 is now called SmartReader. SmartReader is based on deep learning where AI trains your data to automatically give you topics and sub-topics from your data. This data is further analyzed and gives confidence score for each topic. SmartReader has some salient features such as smart topic identification, automatic categorization, and in-depth analysis of data. SmartReader can quickly analyze large sets of open-ended verbatim comments, surveys, feedback and find actionable insights to boost your business.
 
```c#
        [TestMethod]
        public async Task CustomClassifier_ShouldReturn_True()
        {
            var text = "Le scelte di Andrea Pirlo e Luca Gotti per la gara che chiude la 15ª giornata di campionato";
            JArray category = JArray.Parse(@"['news', 'sport']");
            var results = await _apiClient.CustomClassifier(text, category, LangCode.Italian);
            var cat = results.Taxonomy.Where(x => x.Category == "sport").FirstOrDefault();
            Assert.IsTrue(cat.ConfidenceScore > 0.95);
        }
```
### Emotion
Sometimes the three classes of sentiment (positive, negative and neutral) are not sufficient to understand the nuances regarding the underlying tone of a sentence. Our Emotion Analysis classifier is trained on our proprietary dataset and tells whether the underlying emotion behind a message is: Happy, Sad, Angry, Fearful, Excited or Bored.
 
```c#
        [TestMethod]
        public async Task Emotion_ShouldReturn_True()
        {
            var text = "I love you!";
            var results = (await _apiClient.Emotion(text));
            Assert.IsTrue(results.Emotion.Happy > 0.5);
            Assert.IsTrue(results.Emotion.Sad < 0.5);
        }
```

### Intent
This classifier tells whether the underlying intention behind a sentence is opinion, news, marketing, complaint, suggestion, appreciation, and query. This is trained on our proprietary dataset.
Our intent API is widely used to build customer service chatbots in banking, finance and airline industry.
 
```c#
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
```

### Keywords
Keyword Extractor is a powerful tool in text analysis that can be used to index data, generate tag clouds and accelerate the searching time. It generates an extensive list of relevant keywords and phrases to make research more context focussed.
 
```c#
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
```

### Ner
Named Entity Recognition can identify individuals, companies, places, organization, cities and other various type of entities. API can extract this information from any type of text, web page or social media network.
 
```c#
        [TestMethod]
        public async Task Ner_ShouldReturn_True()
        {
            var text = "James is a doctor";
            var results = (await _apiClient.Ner(text));
            Assert.IsTrue(results.NerEntities[0].Category == "name");
            Assert.IsTrue(results.Entities[0].ConfidenceScore > 0.9);
        } 
```

### Sarcasm
Sarcasm is one of the oldest and by far the wittiest of tools used by linguists all around the world. Identify sarcastic comments and text using our Sarcasm Detection API.
 
```c#
        [TestMethod]
        public async Task Sarcasm_ShouldReturn_True()
        {
            var text = "I am proficient at sarcasm.";
            var results = (await _apiClient.Sarcasm(text, LangCode.English));
            Assert.IsTrue(results.Sarcastic > 0.7);
        } 
```

### Sentiment Analysis
Understand the social sentiment of your brand, product or service while monitoring online conversations. Sentiment Analysis is contextual mining of text which identifies and extracts subjective information in source material.
 
```c#
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
```

### Phrase Extractor
The extraction of important topical words and phrases from documents, commonly known as terminology extraction or automatic keyphrase extraction.
 
```c#
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
```

### Taxonomy
The ParallelDots Text Classification (Taxonomy) API can help you understand customer behavior by categorizing conversations on social networks, feedback and other web sources. Search engines, newspapers, or e-commerce portals categorize their content or products to facilitate the search and navigation.
 
```c#
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
```

### Similarity
Semantic analysis API helps users cluster similar articles by understanding the relatedness between different content and streamlines research by eliminating redundant text contents. Semantic analysis API can help bloggers, publishing and media houses to write more engaging stories by retrieving similar articles from the past quickly, and news aggregators to combine similar news from different sources to reduce clutter in the feeds of their readers.
 
```c#
        [TestMethod]
        public async Task Similarity_GivenTwoTextsShouldReturnHighSimilarityScore_True()
        {
            var text1 = "Trump is president";
            var text2 = "Macron is president";
            var results = await _apiClient.Similarity(text1, text2);
            Assert.IsTrue(results.SimilarityScore > 0.7);
        } 
```

### Usage
Usage of ParallelDots API, a webservice that can comprehend a huge amount of unstructured textual content to enhance your textual cognition. 
 
```c#
        [TestMethod]
        public async Task Usage_ShouldReturnDailyBillableHits_True()
        {
            var results = await _apiClient.Usage();
            Assert.IsTrue(results.DailyBillableHits > 0);
        }
```