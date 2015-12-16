using Microsoft.WindowsAzure.Storage.Table;
using RiotFrontend.App_Start;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CoffeeCat.RiotCommon.Settings;
using CoffeeCat.RiotCommon.Utils;
using RiotFrontend.Providers;

namespace RiotFrontend
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var catalog = new AggregateCatalog(
                new AssemblyCatalog(Assembly.GetExecutingAssembly()),
                new AssemblyCatalog(typeof (ICloudManager).Assembly));
            
            var container = new CompositionContainer(catalog);

            var settings = GetUploaderSettings();
            container.ComposeExportedValue("ConnectionString", settings.AzureStorageConnectionString);
            container.ComposeExportedValue("Settings", settings);

            IControllerFactory mefControllerFactory = new MefControllerFactory(container);
            ControllerBuilder.Current.SetControllerFactory(mefControllerFactory);
        }

        private IUploaderSettings GetUploaderSettings()
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
