using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Ocelot.Client.Attributes;
using Ocelot.Client.Configuration;
using Ocelot.Client.Generator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocelot.Client.Controllers
{
    /// <summary>
    /// Serviço de geração de rotas para Ocelot
    /// </summary>    
    [Route("api/ocelot/generator")]
    [Ignore]
    public class OcelotGeneratorController : Controller
    {
        private readonly IOcelotConfigurationProvider _provider;
        private JsonSerializerSettings _serializer;

        public OcelotGeneratorController(IOcelotConfigurationProvider provider, IOptions<MvcJsonOptions> mvcJsonOptions)
        {
            _provider = provider;
            _serializer = OcelotConfigurationSerializerFactory.Create(mvcJsonOptions);
        }

        public string Get()
        {
            return "Ocelot Generator On Line. Try the GET with parameters";
        }

        /// <summary>
        /// Get reroutes for Ocelot format
        /// 
        /// <example>
        ///     {downstreamScheme}://{downstreamHost}:{downstreamPort}/{prefixAppName}/controller/action
        /// </example>
        /// </summary>
        /// <param name="downstreamScheme">Protocolo (Ex: http, https)</param>
        /// <param name="downstreamHost">Host (Ex: www.myaddress.com)</param>
        /// <param name="downstreamPort">Port (Ex: 80, 8080)</param>        
        /// <param name="prefixAppName">Prefix for app. (Ex: For IIS application use the ALIAS)</param>
        /// <returns></returns>
        [HttpGet("{downstreamScheme}/{downstreamHost}/{downstreamPort}")]
        public JsonResult GetConfiguration(string downstreamScheme, int downstreamPort, string downstreamHost, string prefixAppName)
        {
            var config = _provider.GetConfiguration(downstreamScheme, downstreamPort, downstreamHost, prefixAppName);
            return Json(config, _serializer);
        }
    }
}
