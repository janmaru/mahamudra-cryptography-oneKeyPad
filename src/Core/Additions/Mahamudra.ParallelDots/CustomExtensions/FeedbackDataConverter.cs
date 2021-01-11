using Mahamudra.ParallelDots.Dtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Mahamudra.ParallelDots.CustomExtensions
{
    public class FeedbackDataConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Feedback));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Object)
                return token.ToObject<Feedback>();
            else
                return new Feedback()
                {
                    Score = token.ToObject<double>()
                }; 
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
