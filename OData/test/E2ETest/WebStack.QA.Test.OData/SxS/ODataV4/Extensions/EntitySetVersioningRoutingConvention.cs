﻿using System.Linq;
using System.Web.OData.Routing;
using System.Web.OData.Routing.Conventions;

namespace WebStack.QA.Test.OData.SxS.ODataV4.Extensions
{
    public class EntitySetVersioningRoutingConvention : IODataRoutingConvention
    {
        private readonly string _versionSuffix;

        private readonly EntitySetRoutingConvention _entitySetRoutingConvention = new EntitySetRoutingConvention();

        public EntitySetVersioningRoutingConvention(string versionSuffix)
        {
            _versionSuffix = versionSuffix;
        }

        public string SelectAction(System.Web.OData.Routing.ODataPath odataPath, System.Web.Http.Controllers.HttpControllerContext controllerContext, ILookup<string, System.Web.Http.Controllers.HttpActionDescriptor> actionMap)
        {
            return (string)null;
        }

        /// <summary>
        /// Returns the controller names with the version suffix. 
        /// For example: request from route V1 can be dispatched to ProductsV1Controller.
        /// </summary>
        public string SelectController(System.Web.OData.Routing.ODataPath odataPath, System.Net.Http.HttpRequestMessage request)
        {
            var baseControllerName = _entitySetRoutingConvention.SelectController(odataPath, request);
            if (baseControllerName != null)
            {
                return string.Concat(baseControllerName, _versionSuffix);
            }
            return null;
        }
    }
}
