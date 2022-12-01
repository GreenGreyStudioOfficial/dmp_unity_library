using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace GreenGrey.Analytics.Helpers
{
    internal sealed class NewtonsoftProxy : IJsonProxy
    {
        public object Parse(string _source)
        {
            try
            {
                return JObject.Parse(_source);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public object TryGetValue(string _source, string _value)
        {
            try
            {
                var jsonResult = JObject.Parse(_source);
                return jsonResult.TryGetValue(_value, out JToken userIdToken) ? userIdToken : null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public string SerializeObject(object _source, object _settings = null)
        {
            try
            {
                return 
                    _settings == null ? 
                    JsonConvert.SerializeObject(_source) : 
                    JsonConvert.SerializeObject(_source, (JsonSerializerSettings)_settings);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public T DeserializeObject<T>(string _source, object _settings = null)
        {
            try
            {
                return
                    _settings == null
                        ? JsonConvert.DeserializeObject<T>(_source)
                        : JsonConvert.DeserializeObject<T>(_source, (JsonSerializerSettings)_settings);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public object jsonSettings => m_jsonSerializerSettings;
        public object fileJsonSettings => m_fileJsonSerializerSettings;
        
        private readonly JsonSerializerSettings m_jsonSerializerSettings = new JsonSerializerSettings
        {
            DateFormatString = "yyyy-MM-dd HH:mm:ss",
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new IgnorePropertiesResolver(new[] { "id", "status", "type" })
            {
                NamingStrategy = new SnakeCaseNamingStrategy(),
            },
            Formatting = Formatting.None
        };
        
        private readonly JsonSerializerSettings m_fileJsonSerializerSettings = new JsonSerializerSettings
        {
            DateFormatString = "yyyy-MM-dd HH:mm:ss",
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new IgnorePropertiesResolver(new[] { "json" })
            {
                NamingStrategy = new SnakeCaseNamingStrategy(),
            },
            Formatting = Formatting.None
        };
    }
}
