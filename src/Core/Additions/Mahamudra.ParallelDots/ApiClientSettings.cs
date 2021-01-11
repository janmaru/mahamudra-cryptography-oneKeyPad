using Mahamudra.ParallelDots.Enumerations;
using System;

namespace Mahamudra.ParallelDots
{
    public class Compare
    {
        public string Text1 { get; set; }
        public string Text2 { get; set; }
    }
    public class ApiClientSettings
    { 
        public string ApiKey { get; set; } 
        public object Text { get; set; } 
        public object Category { get; set; }
        public string Entity { get; set; } 
        public string FilePath { get; set; }
        public Uri Url { get; set; }
        public Compare Compare { get; set; }
        /// <summary>Gets or sets the language code. Default English.</summary>
        /// <value>The language code.</value>
        public LangCode LangCode { get; set; } = LangCode.English;
    }
}
