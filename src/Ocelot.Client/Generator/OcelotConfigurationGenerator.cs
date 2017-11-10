using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ocelot.Client.Generator
{
    public class OcelotConfigurationGenerator : IOcelotConfigurationProvider
    {
        private readonly IApiDescriptionGroupCollectionProvider _apiDescriptionsProvider;
        private readonly OcelotGeneratorSettings _settings;

        public OcelotConfigurationGenerator(IApiDescriptionGroupCollectionProvider apiDescriptionsProvider, OcelotGeneratorSettings settings = null)
        {
            _apiDescriptionsProvider = apiDescriptionsProvider;
            _settings = settings ?? new OcelotGeneratorSettings();
        }

        public FileConfiguration GetConfiguration(string scheme,
            int port,
            string host,
            string basePath = null)
        {
            var apiDescriptions = _apiDescriptionsProvider.ApiDescriptionGroups.Items
                     .SelectMany(group => group.Items)
                     //.Where(apiDesc => _settings.DocInclusionPredicate(documentName, apiDesc))
                     .Where(apiDesc => !apiDesc.IsGenerator())
                     .Where(apiDesc => !_settings.IgnoreObsoleteActions || !apiDesc.IsObsolete())
                     .OrderBy(_settings.SortKeySelector);

            var paths = apiDescriptions
                .GroupBy(apiDesc => apiDesc.RelativePathSansQueryString())
                .Select(x => CreateRouteItem(scheme, port, host, x.Key, x, basePath))
                .ToList();

            return new FileConfiguration() { ReRoutes = paths };
        }

        public FileReRoute CreateRouteItem(string scheme, int port, string host, string group, IEnumerable<ApiDescription> apiDescriptions, string basePath = null)
        {
            // Paths devem iniciar com barra (/)
            // para garantir a correspondência entre UpstreamPathTemplate e DownstreamPathTemplate
            // contendo parametros na querystring
            // /pathParte1/{param}/pathParte2

            // O / inicial evita a seguinte falha:
            // No exemplo a seguir, a requisição é criada sem realizar a devida substituição do parmetro informado
            // Up:      /pathParte1/999999/pathParte2
            // Down:    pathParte1/{param}/pathParte2
            if (!string.IsNullOrEmpty(basePath))
            {
                group = $"/{basePath}/{group}";
            }

            return new FileReRoute(scheme, port, host, group, apiDescriptions.Select(x => x.HttpMethod).ToList());
        }
    }
}
