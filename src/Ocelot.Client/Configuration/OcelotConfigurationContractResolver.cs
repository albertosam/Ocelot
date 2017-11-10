using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ocelot.Client.Configuration
{
    public class OcelotConfigurationContractResolver : DefaultContractResolver
    {
        private readonly JsonConverter _applicationTypeConverter;

        public OcelotConfigurationContractResolver(JsonSerializerSettings applicationSerializerSettings)
        {
            NamingStrategy = new Newtonsoft.Json.Serialization.DefaultNamingStrategy { ProcessDictionaryKeys = false };             
            _applicationTypeConverter = new ApplicationTypeConverter(applicationSerializerSettings);            
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var jsonProperty = base.CreateProperty(member, memberSerialization);

            if (member.Name == "Example" || member.Name == "Examples" || member.Name == "Default")
                jsonProperty.Converter = _applicationTypeConverter;

            return jsonProperty;
        }

        private class ApplicationTypeConverter : JsonConverter
        {
            private JsonSerializer _applicationTypeSerializer;

            public ApplicationTypeConverter(JsonSerializerSettings applicationSerializerSettings)
            {
                _applicationTypeSerializer = JsonSerializer.Create(applicationSerializerSettings);
            }

            public override bool CanConvert(Type objectType) { return true; }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                _applicationTypeSerializer.Serialize(writer, value);
            }
        }
    }
}
