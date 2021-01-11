using Mahamudra.ParallelDots.Patterns;

namespace Mahamudra.ParallelDots.Enumerations
{

    public class EndPoints
        : Enumeration
    {
        private static string _hosts = "https://apis.paralleldots.com/";
        private static string _hostsv4 = $"{_hosts}v4/";

        private static string _host = "http://apis.paralleldots.com/";
        private static string _hostv4 = $"{_host}v4/";

        public static EndPoints Abuse = new EndPoints(1, $"{_hostsv4}abuse");
        public static EndPoints AbuseBatch = new EndPoints(2, $"{_hostsv4}abuse_batch");

        public static EndPoints CustomClassifier = new EndPoints(3, $"{_hostsv4}custom_classifier");
       
        public static EndPoints Emotion = new EndPoints(4, $"{_hostsv4}emotion");
        public static EndPoints EmotionBatch = new EndPoints(5, $"{_hostsv4}emotion_batch");

        public static EndPoints FacialEmotion = new EndPoints(6, $"{_hostsv4}facial_emotion");

        public static EndPoints Intent = new EndPoints(7, $"{_hostsv4}intent");
        public static EndPoints IntentBatch = new EndPoints(8, $"{_hostsv4}intent_batch");

        public static EndPoints Keywords = new EndPoints(9, $"{_hostsv4}keywords");
        public static EndPoints KeywordsBatch = new EndPoints(10, $"{_hostsv4}keywords_batch");

        public static EndPoints LanguageDetection = new EndPoints(11, $"{_hostsv4}language_detection");
        public static EndPoints LanguageDetectionBatch = new EndPoints(12, $"{_hostsv4}language_detection_batch");
        public static EndPoints MultiLangKeywords = new EndPoints(13, $"{_hostsv4}multilang_keywords");
       
        public static EndPoints Ner = new EndPoints(14, $"{_hostsv4}ner");
        public static EndPoints NerBatch = new EndPoints(15, $"{_hostsv4}ner_batch");
       
        public static EndPoints Nsfw = new EndPoints(16, $"{_hostsv4}nsfw");
        public static EndPoints ObjectRecognizer = new EndPoints(17, $"{_hostsv4}object_recognizer");
        
        public static EndPoints PhraseExtractor = new EndPoints(18, $"{_hostsv4}phrase_extractor");
        public static EndPoints PhraseExtractorBatch = new EndPoints(19, $"{_hostsv4}phrase_extractor_batch");
       
        public static EndPoints Popularity = new EndPoints(20, $"{_hostsv4}popularity");
        
        public static EndPoints Sentiment = new EndPoints(21, $"{_hostsv4}sentiment");
        public static EndPoints SentimentBatch = new EndPoints(22, $"{_hostsv4}sentiment_batch");

        public static EndPoints Sarcasm = new EndPoints(23, $"{_hostsv4}sarcasm");
        public static EndPoints SarcasmBatch = new EndPoints(24, $"{_hostsv4}sarcasm_batch");
        public static EndPoints TargetSentiment = new EndPoints(25, $"{_hostsv4}target/sentiment");
        public static EndPoints TargetSentimentBatch = new EndPoints(26, $"{_hostsv4}target/sentiment_batch");

        public static EndPoints Similarity = new EndPoints(27, $"{_hostsv4}similarity");

        public static EndPoints Taxonomy = new EndPoints(28, $"{_hostsv4}taxonomy");
        public static EndPoints TaxonomyBatch = new EndPoints(29, $"{_hostsv4}taxonomy_batch");

        public static EndPoints TextParser = new EndPoints(29, $"{_hostsv4}text_parser"); 

        public static EndPoints Usage = new EndPoints(30, $"{_hosts}usage");

        public EndPoints(int id, string uri)
            : base(id, uri)
        {

        }
    }
}
