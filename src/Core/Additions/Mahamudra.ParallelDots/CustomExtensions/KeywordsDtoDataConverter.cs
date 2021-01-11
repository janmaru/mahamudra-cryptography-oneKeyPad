using Mahamudra.ParallelDots.Dtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Mahamudra.ParallelDots.CustomExtensions
{
    public class KeywordsDtoDataConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(KeywordsDto));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Object)
                return null;
            else
                return token.ToObject<List<KeywordText>>(); 
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
