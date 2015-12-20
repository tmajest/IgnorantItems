using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using CoffeeCat.RiotCommon.Settings;
using CoffeeCat.RiotCommon.Utils;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Serialization;
using RiotFrontend.App_Start;
using RiotFrontend.Providers;
using System.Net.Http.Headers;
using CacheCow.Server;
using Newtonsoft.Json;

namespace RiotFrontend
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

#if (!DEBUG)
            // Enable for production
            GlobalConfiguration.Configuration.MessageHandlers.Add(new CachingHandler(config));
#endif

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate };
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            var container = new UnityContainer();
            var settings = GetUploaderSettings();

            container
                .RegisterInstance(settings)
                .RegisterType<ICloudManager, CloudManager>(new InjectionConstructor(settings.AzureStorageConnectionString))
                .RegisterType<IStaticData, StaticData>(new ContainerControlledLifetimeManager())
                .RegisterType<IDtoConverter, DtoConverter>(new ContainerControlledLifetimeManager())
                .RegisterType<IMatchProvider, MatchProvider>();

            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static IUploaderSettings GetUploaderSettings()
        {
            var appSettings = ConfigurationManager.AppSettings;
            return new UploaderSettings
            {
                AzureStorageConnectionString = appSettings["AzureStorageConnectionString"],
                RiotApiKeys = appSettings["ApiKeys"].Split(',').ToList(),
                DataContainerName = appSettings["DataContainerName"],
                MasteriesBlobPath = appSettings["MasteriesBlobPath"],
                RunesBlobPath = appSettings["RunesBlobPath"],
                ChampionsBlobPath = appSettings["ChampionsBlobPath"],
                ItemsBlobPath = appSettings["ItemsBlobPath"],
                ApiVersionsBlobPath = appSettings["ApiVersionsBlobPath"],
                SummonersTableName = appSettings["SummonersTableName"],
                MatchListTableName = appSettings["MatchListTableName"],
            };
        }
    }
}
