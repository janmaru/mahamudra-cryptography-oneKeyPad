using Mahamudra.ParallelDots.Patterns;

namespace Mahamudra.ParallelDots.Enumerations
{
    /// <summary> 
    /// - Portuguese(pt )
    /// - Simplified Chinese(zh)
    /// - Spanish(es)
    /// - German(de)
    /// - French(fr)
    /// - Dutch(nl)
    /// - Italian(it)
    /// - Japanese(ja)
    /// - Russian(ru)
    /// - Thai(th)
    /// - Danish(da)
    /// - Finish(fi)
    /// - Arabic(ar)
    /// - Greek(el)
    /// </summary>
    public class LangCode
        : Enumeration
    {
        public static LangCode English = new LangCode(1, "en");
        public static LangCode Portuguese = new LangCode(2, "pt");
        public static LangCode SimplifiedChinese = new LangCode(3, "zh");
        public static LangCode Spanish = new LangCode(4, "es");
        public static LangCode German = new LangCode(5, "de");
        public static LangCode French = new LangCode(6, "fr");
        public static LangCode Dutch = new LangCode(7, "nl");
        public static LangCode Italian = new LangCode(8, "it");
        public static LangCode Japanese = new LangCode(9, "ja");
        public static LangCode Russian = new LangCode(10, "ru"); 
        public static LangCode Thai = new LangCode(11, "th");
        public static LangCode Danish = new LangCode(12, "da");
        public static LangCode Finish = new LangCode(13, "fi");
        public static LangCode Arabic = new LangCode(14, "ar");
        public static LangCode Greek = new LangCode(15, "el"); 
        public LangCode(int id, string name)
            : base(id, name)
        {
            
        }
    }
}
