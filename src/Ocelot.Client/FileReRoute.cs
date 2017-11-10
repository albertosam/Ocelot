using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocelot.Client
{
    public class FileReRoute
    {
        public FileReRoute()
        {
            UpstreamHttpMethod = new List<string>();
            AddHeadersToRequest = new Dictionary<string, string>();
            AddClaimsToRequest = new Dictionary<string, string>();
            RouteClaimsRequirement = new Dictionary<string, string>();
            AddQueriesToRequest = new Dictionary<string, string>();
            //AuthenticationOptions = new FileAuthenticationOptions();
            //FileCacheOptions = new FileCacheOptions();
            //QoSOptions = new FileQoSOptions();
            //RateLimitOptions = new FileRateLimitRule();
        }

        public FileReRoute(string scheme, int port, string host, string pathTemplate, List<string> httpMethod)
        {
            DownstreamScheme = scheme;
            DownstreamPort = port;
            DownstreamHost = host;
            DownstreamPathTemplate = pathTemplate;

            UpstreamPathTemplate = pathTemplate;
            UpstreamHttpMethod = httpMethod;            

        }

        public string DownstreamPathTemplate { get; set; }
        public string UpstreamPathTemplate { get; set; }
        public List<string> UpstreamHttpMethod { get; set; }
        //public FileAuthenticationOptions AuthenticationOptions { get; set; }
        public Dictionary<string, string> AddHeadersToRequest { get; set; }
        public Dictionary<string, string> AddClaimsToRequest { get; set; }
        public Dictionary<string, string> RouteClaimsRequirement { get; set; }
        public Dictionary<string, string> AddQueriesToRequest { get; set; }
        public string RequestIdKey { get; set; }
        //public FileCacheOptions FileCacheOptions { get; set; }
        public bool ReRouteIsCaseSensitive { get; set; }
        public string ServiceName { get; set; }
        public string DownstreamScheme { get; set; }
        public string DownstreamHost { get; set; }
        public int DownstreamPort { get; set; }
        //public FileQoSOptions QoSOptions { get; set; }
        public string LoadBalancer { get; set; }
        //public FileRateLimitRule RateLimitOptions { get; set; }
    }
}
