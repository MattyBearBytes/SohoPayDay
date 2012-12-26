using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BearBytes.SohoPayDay.Business.Service;
using BearBytes.SohoPayDay.Business.Service.Interface;
using StructureMap;

namespace BearBytes.SohoPayDay.Mvc
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            LoadDependencies();
        }

        /// <summary>
        /// Load Dependencies for Structure Map
        /// </summary>
        private void LoadDependencies()
        {
            //Load Service Dependencies for Data Access Layer
            DependencyResolver.SetResolver(new StructureMapDependencyResolver(Business.Business.LoadDependencies()));

            //Load MVC Dependencies for Service Layer
            ObjectFactory.Initialize(x =>
            {
                x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
                x.For<IProductService>().Use<ProductService>();
            });
        }
    }
}