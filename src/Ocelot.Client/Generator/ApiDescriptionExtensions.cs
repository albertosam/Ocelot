using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Ocelot.Client.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Ocelot.Client.Generator
{
    public static class ApiDescriptionExtensions
    {
        internal static string ControllerName(this ApiDescription apiDescription)
        {
            var controllerActionDescriptor = apiDescription.ControllerActionDescriptor();
            return (controllerActionDescriptor == null) ? null : controllerActionDescriptor.ControllerName;
        }

        private static ControllerActionDescriptor ControllerActionDescriptor(this ApiDescription apiDescription)
        {
            var controllerActionDescriptor = apiDescription.GetProperty<ControllerActionDescriptor>();
            if (controllerActionDescriptor == null)
            {
                controllerActionDescriptor = apiDescription.ActionDescriptor as ControllerActionDescriptor;
                apiDescription.SetProperty(controllerActionDescriptor);
            }
            return controllerActionDescriptor;
        }

        public static IEnumerable<object> ActionAttributes(this ApiDescription apiDescription)
        {
            var controllerActionDescriptor = apiDescription.ControllerActionDescriptor();
            return (controllerActionDescriptor == null)
                ? Enumerable.Empty<object>()
                : controllerActionDescriptor.MethodInfo.GetCustomAttributes(false);
        }

         public static IEnumerable<object> ControllerAttributes(this ApiDescription apiDescription)
        {
            var controllerActionDescriptor = apiDescription.ControllerActionDescriptor();            
            return (controllerActionDescriptor == null)
                ? Enumerable.Empty<object>()
                : controllerActionDescriptor.ControllerTypeInfo.GetCustomAttributes(false);
        }

        internal static bool IsObsolete(this ApiDescription apiDescription)
        {
            return apiDescription.ActionAttributes().OfType<ObsoleteAttribute>().Any();
        }

        internal static bool IsGenerator(this ApiDescription apiDescription)
        {
            return apiDescription.ControllerAttributes().OfType<IgnoreAttribute>().Any();
        }

        internal static string RelativePathSansQueryString(this ApiDescription apiDescription)
        {
            return apiDescription.RelativePath.Split('?').First();
        }
    }
}
