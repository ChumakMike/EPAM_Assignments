using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using EpamSqlTask5EntityFramework;

namespace WebApp {
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            // Конфигурация и службы веб-API
            onConf(config);
            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}/",
                defaults: new { id = RouteParameter.Optional }
            );
        }
        public static void onConf(HttpConfiguration config) {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().AsSelf().SingleInstance();
            var buildForDep = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(buildForDep);
        }
    }
}
