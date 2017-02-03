using System;
using System.Configuration;
using System.Net.Http.Headers;
using System.Web.Http;
using CoffeeCat.RiotCommon.Settings;
using CoffeeCat.RiotCommon.Utils;
using CoffeeCat.RiotFrontend.Providers;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using CoffeeCat.RiotFrontend.BusinessLogic.Converters;

namespace CoffeeCat.RiotFrontend
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            var container = new UnityContainer();
            var settings = GetUploaderSettings();

            container
                .RegisterInstance(settings)
                .RegisterType<ICloudManager, CloudManager>(new InjectionConstructor(settings.StorageConnectionString))
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

        private static ICommonSettings GetUploaderSettings()
        {
            var appSettings = ConfigurationManager.AppSettings;
            return new CommonSettings
            {
                StorageAccountName = appSettings["StorageAccountName"],
                StaticDataContainerName = appSettings["StaticDataContainerName"],
                DatabaseConnectionString = appSettings["DatabaseConnectionString"],
                StorageConnectionString = appSettings["StorageConnectionString"],
                ChampionsBlobPath = appSettings["ChampionsBlobPath"],
                ItemsBlobPath = appSettings["ItemsBlobPath"],
                MasteriesBlobPath = appSettings["MasteriesBlobPath"],
                RunesBlobPath = appSettings["RunesBlobPath"],
                SummonerSpellsBlobPath = appSettings["SummonerSpellsBlobPath"],
                Region = appSettings["Region"],
                StaticDataRefreshRate = TimeSpan.FromHours(double.Parse(appSettings["StaticDataRefreshRateHours"]))
            };
        }
    }
}
