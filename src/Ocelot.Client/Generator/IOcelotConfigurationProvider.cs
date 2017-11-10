using Ocelot.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocelot.Client.Generator
{
    public interface IOcelotConfigurationProvider
    {
        /// <summary>
        /// Get ReRoutes
        /// </summary>
        /// <param name="schemes">Protocol</param>
        /// <param name="port">Port</param>
        /// <param name="host">Url</param>
        /// <param name="baseTemplatePath">App name. Example: App name defined in IIS</param>
        /// <returns></returns>
        /// <example>GetConfiguracao("http", 80, "myaddress.com", "myapi") => http://myaddress.com:80/mayapi </example>
        FileConfiguration GetConfiguration(string schemes,
            int port,
            string host,
            string baseTemplatePath = null
            );
    }
}
