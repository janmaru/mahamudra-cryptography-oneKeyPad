using System.Runtime.Serialization;

namespace Mahamudra.ParallelDots.Dtos
{

    [DataContract]
    public class DailyBillableHitsBreakdown
    {
        [DataMember(Name = "intent")]
        public int Intent { get; set; }
        [DataMember(Name = "abuse")]
        public int Abuse { get; set; }
        [DataMember(Name = "emotion")]
        public int Emotion { get; set; }
        [DataMember(Name = "keyword")]
        public int Keyword { get; set; }
        [DataMember(Name = "ner")]
        public int Ner { get; set; }
        [DataMember(Name = "taxonomy")]
        public int Taxonomy { get; set; }
        [DataMember(Name = "similarity")]
        public int Similarity { get; set; }
        [DataMember(Name = "sentiment")]
        public int Sentiment { get; set; }
        [DataMember(Name = "phrase_extractor")]
        public int PhraseExtractor { get; set; }
        [DataMember(Name = "custom_classifier")]
        public int CustomClassifier { get; set; }
    }

    [DataContract]
    public class MonthlyBillableHitsBreakdown
    {
        [DataMember(Name = "facial_emotion")]
        public int FacialEmotion { get; set; }
        [DataMember(Name = "emotion")]
        public int Emotion { get; set; }
        [DataMember(Name = "sentiment")]
        public int Sentiment { get; set; }
        [DataMember(Name = "keyword")]
        public int Keyword { get; set; }
        [DataMember(Name = "similarity")]
        public int Similarity { get; set; }
        [DataMember(Name = "taxonomy")]
        public int Taxonomy { get; set; }
        [DataMember(Name = "text_parser")]
        public int TextParser { get; set; }
        [DataMember(Name = "ner")]
        public int Ner { get; set; }
        [DataMember(Name = "custom_classifier")]
        public int CustomClassifier { get; set; }
        [DataMember(Name = "abuse")]
        public int Abuse { get; set; }
        [DataMember(Name = "intent")]
        public int Intent { get; set; }
        [DataMember(Name = "object_recognizer")]
        public int ObjectRecognizer { get; set; }
        [DataMember(Name = "multilang_keywords")]
        public int MultilangKeywords { get; set; }
        [DataMember(Name = "phrase_extractor")]
        public int PhraseExtractor { get; set; } 
    }

    [DataContract]
    public class UsageDto
    {
        [DataMember(Name = "daily_billable_hits")]
        public int DailyBillableHits { get; set; }

        [DataMember(Name = "monthly_billable_hits")]
        public int MonthlyBillableHits { get; set; }

        [DataMember(Name = "daily_billable_hits_breakdown")]
        public DailyBillableHitsBreakdown DailyBillableHitsBreakdown { get; set; }

        [DataMember(Name = "monthly_billable_hits_breakdown")]
        public MonthlyBillableHitsBreakdown MonthlyBillableHitsBreakdown { get; set; }

        [DataMember(Name = "package_id")]
        public int PackageId { get; set; }

        [DataMember(Name = "excel_daily_quota")]
        public int ExcelDailyQuota { get; set; }
    }

}
