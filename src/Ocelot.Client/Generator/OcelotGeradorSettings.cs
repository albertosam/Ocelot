using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocelot.Client.Generator
{
    public class OcelotGeneratorSettings
    {
        public OcelotGeneratorSettings()
        {
            TagSelector = (apiDesc) => apiDesc.ControllerName();
            DocInclusionPredicate = (docName, api) => api.GroupName == null || api.GroupName == docName;
            SortKeySelector = (apiDesc) => TagSelector(apiDesc);
        }

        public Func<string, ApiDescription, bool> DocInclusionPredicate { get; set; }

        public bool IgnoreObsoleteActions { get; set; }

        public Func<ApiDescription, string> TagSelector { get; set; }

        public Func<ApiDescription, string> SortKeySelector { get; set; }

        public bool DescribeAllParametersInCamelCase { get; set; }
    }
}
