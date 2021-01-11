using Mahamudra.ParallelDots.CustomExtensions;
using Mahamudra.ParallelDots.Dtos;
using Mahamudra.ParallelDots.Enumerations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mahamudra.ParallelDots
{
    public class ApiClient
    {
        private readonly ILogger<ApiClient> _logger;  
        private readonly string _apiKey;
        public ApiClient(string apiKey, ILogger<ApiClient> logger = null)
        {
            if (String.IsNullOrWhiteSpace(apiKey))
                throw new Exception("Provide an apikey");
            this._apiKey = apiKey;
            this._logger = logger ?? NullLogger<ApiClient>.Instance;
        }

        public async Task<AbuseDto> Abuse(string text)
        {
            var url = EndPoints.Abuse.Name;
            var result = await url.ResolveRequest(
                new ApiClientSettings()
                {
                    ApiKey = _apiKey,
                    Text = text
                });
            return result.Deserialize<AbuseDto>();
        }

        public async Task<AbuseListDto> AbuseBatch(JArray textList)
        { 
            var url = EndPoints.AbuseBatch.Name;
            var result = await url.ResolveRequest(
                new ApiClientSettings()
                {
                    ApiKey = _apiKey,
                    Text = textList
                });
            return result.Deserialize<AbuseListDto>();
        }

        public async Task<TaxonomyDto> CustomClassifier(string text, JArray category, LangCode langCode)
        {
            var url = EndPoints.CustomClassifier.Name;
            var json = await url.ResolveRequest(
                new ApiClientSettings()
                {
                    ApiKey = _apiKey,
                    Text = text,
                    Category = category,
                    LangCode = langCode
                });
            return json.Deserialize<TaxonomyDto>();
        }

        public async Task<TaxonomyDto> CustomClassifier(string text, JArray category)
        {
            return await CustomClassifier(text, category, LangCode.English);
        }

        public async Task<EmotionDto> Emotion(string text)
        {
            return await Emotion(text, LangCode.English);
        }

        public async Task<EmotionDto> Emotion(string text, LangCode langCode)
        {
            var url = EndPoints.Emotion.Name;
            var result = await url.ResolveRequest(
                new ApiClientSettings()
                {
                    ApiKey = _apiKey,
                    Text = text,
                    LangCode = langCode
                });
            return result.Deserialize<EmotionDto>();
        }

        public async Task<EmotionListDto> EmotionBatch(JArray textList)
        {
            return await EmotionBatch(textList, LangCode.English);
        }

        public async Task<EmotionListDto> EmotionBatch(JArray textList, LangCode langCode)
        {
            var url = EndPoints.EmotionBatch.Name;
            var result = await url.ResolveRequest(
                new ApiClientSettings()
                {
                    ApiKey = _apiKey,
                    Text = textList,
                    LangCode = langCode
                });
            return result.Deserialize<EmotionListDto>();
        }

        [ObsoleteAttribute("This api doesn't work. Returns BadGateway", false)]

        public async Task<string> FacialEmotion(string imageFilePath)
        {
            var url = EndPoints.FacialEmotion.Name;
            var result = await url.ResolveRequest(
                    new ApiClientSettings()
                    {
                        ApiKey = _apiKey,
                        FilePath = imageFilePath
                    });
            return result;
        }

        [ObsoleteAttribute("This api doesn't work. Returns BadGateway", false)]
        public async Task<string> FacialEmotionUrl(string imageUrl)
        {
            var url = EndPoints.FacialEmotion.Name;
            var json = await url.ResolveRequest(
                new ApiClientSettings()
                {
                    ApiKey = _apiKey,
                    Url = new Uri(imageUrl)
                });
            return json;
        }

        /// <summary>Intent of the specified text.</summary>
        /// Intent Analysis
        /// This classifier tells whether the underlying intention behind a sentence is opinion, news, marketing, complaint, suggestion, appreciation, and query.This is trained on our proprietary dataset.
        /// The intent API is widely used to build customer service chatbots in banking, finance and airline industry.
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public async Task<IntentDto> Intent(string text)
        {
            var url = EndPoints.Intent.Name;
            var result = await url.ResolveRequest(
                new ApiClientSettings()
                {
                    ApiKey = _apiKey,
                    Text = text
                });
            return result.Deserialize<IntentDto>();
        }

        /// <summary>Intent of a text array.</summary>
        /// Intent Analysis
        /// This classifier tells whether the underlying intention behind a sentence is opinion, news, marketing, complaint, suggestion, appreciation, and query.This is trained on our proprietary dataset.
        /// The intent API is widely used to build customer service chatbots in banking, finance and airline industry.
        /// <param name="textList">The text list.</param>
        /// <returns></returns>
        public async Task<IntentListDto> IntentBatch(JArray textList)
        {
            var url = EndPoints.IntentBatch.Name;
            var result = await url.ResolveRequest(
                new ApiClientSettings()
                {
                    ApiKey = _apiKey,
                    Text = textList
                });
            return result.Deserialize<IntentListDto>();
        }

        /// <summary>Generates a list of keywords.</summary>
        /// The Keyword Generator.
        /// The Keyword Generator is a powerful tool with text analysis that can be used to index data, generate tag clouds and accelerate the searching time. 
        /// It generates an extensive list of relevant keywords and phrases to make research more context focused. 
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public async Task<KeywordsDto> Keywords(string text)
        {
            var url = EndPoints.Keywords.Name;
            var json = await url.ResolveRequest(
                new ApiClientSettings()
                {
                    ApiKey = _apiKey,
                    Text = text
                });
            return json.Deserialize<KeywordsDto>();
        }

        public async Task<KeywordsDto> KeywordsBatch(JArray textList, LangCode langCode)
        {
            var url = EndPoints.KeywordsBatch.Name;
            var json = await url.ResolveRequest(
                new ApiClientSettings()
                {
                    ApiKey = _apiKey,
                    Text = textList,
                    LangCode = langCode
                });
            return json.Deserialize<KeywordsDto>();
        }
        public async Task<KeywordsDto> KeywordsBatch(JArray textList)
        {
            return await KeywordsBatch(textList, LangCode.English);
        }

        [ObsoleteAttribute("This api doesn't work. Returns NotFound.", false)]
        public async Task<string> LanguageDetection(string text)
        {
            var url = EndPoints.LanguageDetection.Name;
            var json = await url.ResolveRequest(
                new ApiClientSettings()
                {
                    ApiKey = _apiKey,
                    Text = text
                });
            return json;
        }


        [ObsoleteAttribute("This api doesn't work. Returns NotFound.", false)]
        public async Task<string> LanguageDetectionBatch(JArray textList)
        {
            var url = EndPoints.LanguageDetectionBatch.Name;
            var json = await url.ResolveRequest(
                   new ApiClientSettings()
                   {
                       ApiKey = _apiKey,
                       Text = textList
                   });
            return json;
        }

        public async Task<string> MultiLangKeywords(string text, LangCode langCode)
        {
            var url = EndPoints.MultiLangKeywords.Name;
            var json = await url.ResolveRequest(
              new ApiClientSettings()
              {
                  ApiKey = _apiKey,
                  Text = text
              });
            return json;
        }

        /// <summary>Named Entity Extraction/Recognition (NER)</summary>
        /// Named-entity recognition (NER) (also known as (named) entity identification, entity chunking, and entity extraction) is a subtask of information extraction that seeks to locate and classify named entities mentioned in unstructured text 
        /// into pre-defined categories such as person names, organizations, locations, medical codes, time expressions, quantities, monetary values, percentages, etc.
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public async Task<EntityDto> Ner(string text)
        {
            return await Ner(text, LangCode.English);
        }

        public async Task<EntityListDto> NerBatch(JArray textList, LangCode langCode)
        {
            var url = EndPoints.NerBatch.Name;
            var json = await url.ResolveRequest(
                 new ApiClientSettings()
                 {
                     ApiKey = _apiKey,
                     Text = textList,
                     LangCode = langCode
                 });
            return json.Deserialize<EntityListDto>();
        }

        public async Task<EntityListDto> NerBatch(JArray textList)
        {
            return await NerBatch(textList, LangCode.English);
        }

        public async Task<EntityDto> Ner(string text, LangCode langCode)
        {
            var url = EndPoints.Ner.Name;
            var json = await url.ResolveRequest(
                new ApiClientSettings()
                {
                    ApiKey = _apiKey,
                    Text = text,
                    LangCode = langCode
                });
            return json.Deserialize<EntityDto>();
        }

        [ObsoleteAttribute("This api doesn't work. Returns NotFound.", false)]
        public async Task<string> Nsfw(string imageFilePath)
        {
            var url = EndPoints.Nsfw.Name;
            var json = await url.ResolveRequest(
                   new ApiClientSettings()
                   {
                       ApiKey = _apiKey,
                       FilePath = imageFilePath,
                   });
            return json;
        }

        [ObsoleteAttribute("This api doesn't work. Returns NotFound.", false)]
        public async Task<string> NsfwUrl(string imageUrl)
        {
            var url = EndPoints.Nsfw.Name;
            var json = await url.ResolveRequest(
                     new ApiClientSettings()
                     {
                         ApiKey = _apiKey,
                         Url = new Uri(imageUrl)
                     });
            return json;
        }

        [ObsoleteAttribute("This api doesn't work. Returns BadGateway.", false)]
        public async Task<string> ObjectRecognizer(string imageFilePath)
        {
            var url = EndPoints.ObjectRecognizer.Name;
            var json = await url.ResolveRequest(
                    new ApiClientSettings()
                    {
                        ApiKey = _apiKey,
                        FilePath = imageFilePath,
                    });
            return json;
        }

        [ObsoleteAttribute("This api doesn't work. Returns BadGateway.", false)]
        public async Task<string> ObjectRecognizerUrl(string imageUrl)
        {
            var url = EndPoints.ObjectRecognizer.Name;
            var json = await url.ResolveRequest(
                    new ApiClientSettings()
                    {
                        ApiKey = _apiKey,
                        Url = new Uri(imageUrl)
                    });
            return json;
        }

        public async Task<KeywordsDto> PhraseExtractor(string text)
        {
            return await PhraseExtractor(text, LangCode.English);
        }

        public async Task<KeywordsDto> PhraseExtractor(string text, LangCode langCode)
        {
            var url = EndPoints.PhraseExtractor.Name;
            var json = await url.ResolveRequest(
               new ApiClientSettings()
               {
                   ApiKey = _apiKey,
                   Text = text,
                   LangCode = langCode
               });
            return json.Deserialize<KeywordsDto>();
        }

        public async Task<PhraseExtractorListDto> PhraseExtractorBatch(JArray textList)
        {
            return await PhraseExtractorBatch(textList, LangCode.English);
        }

        public async Task<PhraseExtractorListDto> PhraseExtractorBatch(JArray textList, LangCode langCode)
        {
            var url = EndPoints.PhraseExtractorBatch.Name;
            var json = await url.ResolveRequest(
                 new ApiClientSettings()
                 {
                     ApiKey = _apiKey,
                     Text = textList,
                     LangCode = langCode
                 });
            return json.Deserialize<PhraseExtractorListDto>();
        }

        [ObsoleteAttribute("This api doesn't work. Returns NotFound.", false)]
        public async Task<string> Popularity(string imageFilePath)
        {
            var url = EndPoints.Popularity.Name;
            var json = await url.ResolveRequest(
                new ApiClientSettings()
                {
                    ApiKey = _apiKey,
                    FilePath = imageFilePath
                });
            return json;
        }

        [ObsoleteAttribute("This api doesn't work. Returns NotFound.", false)]
        public async Task<string> PopularityUrl(string imageUrl)
        {
            var url = EndPoints.Popularity.Name;
            var json = await url.ResolveRequest(
                 new ApiClientSettings()
                 {
                     ApiKey = _apiKey,
                     Url = new Uri(imageUrl)
                 });
            return json;
        }

        public async Task<SentimentDto> Sentiment(string text)
        {
            return await Sentiment(text, LangCode.English);
        }

        public async Task<SentimentDto> Sentiment(string text, LangCode langCode)
        {
            var url = EndPoints.Sentiment.Name;
            var json = await url.ResolveRequest(
                 new ApiClientSettings()
                 {
                     ApiKey = _apiKey,
                     Text = text,
                     LangCode = langCode
                 });
            return json.Deserialize<SentimentDto>();
        }

        public async Task<SentimentListDto> SentimentBatch(JArray textList)
        {
            return await SentimentBatch(textList, LangCode.English);
        }

        public async Task<SentimentListDto> SentimentBatch(JArray textList, LangCode langCode)
        {
            var url = EndPoints.SentimentBatch.Name;
            var json = await url.ResolveRequest(
                   new ApiClientSettings()
                   {
                       ApiKey = _apiKey,
                       Text = textList,
                       LangCode = langCode
                   });
            return json.Deserialize<SentimentListDto>();
        }

        public async Task<SarcasmDto> Sarcasm(string text)
        {
            return await Sarcasm(text, LangCode.English);
        }

        public async Task<SarcasmDto> Sarcasm(string text, LangCode langCode)
        {
            var url = EndPoints.Sarcasm.Name;
            var json = await url.ResolveRequest(
               new ApiClientSettings()
               {
                   ApiKey = _apiKey,
                   Text = text,
                   LangCode = langCode
               });
            return json.Deserialize<SarcasmDto>();
        }

        public async Task<List<SarcasmDto>> SarcasmBatch(JArray textList)
        {
            return await SarcasmBatch(textList, LangCode.English);
        }

        public async Task<List<SarcasmDto>> SarcasmBatch(JArray textList, LangCode langCode)
        {
            var url = EndPoints.SarcasmBatch.Name;
            var json = await url.ResolveRequest(
               new ApiClientSettings()
               {
                   ApiKey = _apiKey,
                   Text = textList,
                   LangCode = langCode
               });
            return json.Deserialize<List<SarcasmDto>>();
        }


        [ObsoleteAttribute("This api doesn't work. Returns NotFound.", false)]
        public async Task<string> TargetSentiment(string text, string entity)
        {
            return await TargetSentiment(text, entity, LangCode.English);
        }

        [ObsoleteAttribute("This api doesn't work. Returns NotFound.", false)]
        public async Task<string> TargetSentiment(string text, string entity, LangCode langCode)
        {
            var url = EndPoints.TargetSentiment.Name;
            var json = await url.ResolveRequest(
               new ApiClientSettings()
               {
                   ApiKey = _apiKey,
                   Entity = entity,
                   Text = text,
                   LangCode = langCode
               });
            return json;
        }

        [ObsoleteAttribute("This api doesn't work. Returns NotFound.", false)]
        public async Task<string> TargetSentimentBatch(JArray textList, string entity)
        {
            return await TargetSentimentBatch(textList, entity, LangCode.English);
        }

        [ObsoleteAttribute("This api doesn't work. Returns NotFound.", false)]
        public async Task<string> TargetSentimentBatch(JArray textList, string entity, LangCode langCode)
        {
            var url = EndPoints.TargetSentimentBatch.Name;
            var json = await url.ResolveRequest(
            new ApiClientSettings()
            {
                ApiKey = _apiKey,
                Entity = entity,
                Text = textList,
                LangCode = langCode
            });
            return json;
        }

        public async Task<SimiliarityDto> Similarity(string text1, string text2)
        {
            var url = EndPoints.Similarity.Name;
            var json = await url.ResolveRequest(
              new ApiClientSettings()
              {
                  ApiKey = _apiKey,
                  Compare = new Compare() { Text1 = text1, Text2 = text2 }
              });
            return json.Deserialize<SimiliarityDto>();
        }

        public async Task<TaxonomyDto> Taxonomy(string text)
        {
            var url = EndPoints.Taxonomy.Name;
            var json = await url.ResolveRequest(
              new ApiClientSettings()
              {
                  ApiKey = _apiKey,
                  Text = text
              });
            return json.Deserialize<TaxonomyDto>();
        }

        public async Task<TaxonomyListDto> TaxonomyBatch(JArray textList)
        {
            return await TaxonomyBatch(textList, LangCode.English);
        }

        public async Task<TaxonomyListDto> TaxonomyBatch(JArray textList, LangCode langCode)
        {
            var url = EndPoints.TaxonomyBatch.Name;
            var json = await url.ResolveRequest(
                    new ApiClientSettings()
                    {
                        ApiKey = _apiKey,
                        Text = textList,
                        LangCode = langCode
                    });
            return json.Deserialize<TaxonomyListDto>();
        }

        [ObsoleteAttribute("This api doesn't work. Returns bad gateway.", false)]
        public async Task<string> TextParser(string text)
        {
            var url = EndPoints.TextParser.Name; 
            var json = await url.ResolveRequest(
              new ApiClientSettings()
              {
                  ApiKey = _apiKey,
                  Text = text
              });
            return json.Deserialize<string>();
        }

        public async Task<UsageDto> Usage()
        {
            var url = EndPoints.Usage.Name;
            var json = await url.ResolveRequest(
                new ApiClientSettings()
                {
                    ApiKey = _apiKey
                });
            return json.Deserialize<UsageDto>();
        }
    }
}
