using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocelot.Client.Configuration
{
    public class OcelotConfigurationSerializerFactory
    {
        internal static JsonSerializerSettings Create(IOptions<MvcJsonOptions> applicationJsonOptions)
        {
            // TODO: Should this handle case where mvcJsonOptions.Value == null?
            return new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = applicationJsonOptions.Value.SerializerSettings.Formatting,                
                ContractResolver = new OcelotConfigurationContractResolver(applicationJsonOptions.Value.SerializerSettings)
            };
        }
    }
}
