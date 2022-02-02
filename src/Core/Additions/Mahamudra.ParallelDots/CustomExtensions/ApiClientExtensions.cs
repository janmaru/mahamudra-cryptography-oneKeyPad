using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace Mahamudra.ParallelDots.CustomExtensions
{
    public static class ApiClientExtensions
    {
        public static T Deserialize<T>(this string json, bool map = true)
        {
            try
            {
                JsonSerializerSettings jsonSettings;
                if (map)
                {
                    // Throws error if JSON does not exactly maps into class
                    jsonSettings = new JsonSerializerSettings
                    {
                        MissingMemberHandling = MissingMemberHandling.Error
                    };
                    return JsonConvert.DeserializeObject<T>(json, jsonSettings);
                }
                else
                    return JsonConvert.DeserializeObject<T>(json); 
            }
            catch (Exception ex)
            { 
                // if doesn't bind it might probably 'cause the ParallelDots service
                // gave an error inside the 200 json
                throw new Exception($"json: {json} ex:{ex.ToString()}");
            }
        }
 
        public static async Task<string> ResolveRequest(this string serviceUri, ApiClientSettings
            apiClientSettings)
        {
            var myServiceUri = new Uri(serviceUri).ToString(); //throws exception if not well formed
            var client = new RestClient(myServiceUri);
            var request = AddParameters(apiClientSettings);
            RestResponse response = await client.ExecuteAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return response.Content.ToString();
            else
                throw new Exception($"Error call {myServiceUri} with code {response.StatusCode}");
        }

        private static RestRequest AddParameters(ApiClientSettings
            apiClientSettings)
        {
            var request = new RestRequest(string.Empty, Method.Post)
                .AddParameter("api_key", apiClientSettings.ApiKey)
                .AddHeader("cache-control", "no-cache")
                .AddHeader("source", "c#wrapper")
                .AddParameter("lang_code", apiClientSettings.LangCode.Name);
            if (apiClientSettings.Entity != null)
                request.AddParameter("entity", apiClientSettings.Entity.ToString());
            if (apiClientSettings.Text != null)
                request.AddParameter("text", apiClientSettings.Text.ToString());
            if (apiClientSettings.Category != null)
                request.AddParameter("category", apiClientSettings.Category.ToString());
            if (apiClientSettings.Url != null)
                request.AddParameter("url", apiClientSettings.Url.ToString());
            if (apiClientSettings.Compare != null)
            {
                request.AddParameter("text_1", apiClientSettings.Compare.Text1.ToString());
                request.AddParameter("text_2", apiClientSettings.Compare.Text2.ToString());
            }
            if (apiClientSettings.FilePath != null)
            {
                request.AddParameter("file", apiClientSettings.FilePath);
                request.AlwaysMultipartFormData = true;
            }
            return request;
        }
    }
}
