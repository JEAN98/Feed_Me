using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiTest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            var urlPermitidas = new EnableCorsAttribute("*", "*", "*");  // le dé acceso a cualquier dominio de origen (el primer asterísco). Aquí podría indicar cada uno de los dominios permitido, separandolos por una coma ("www.midominio1.com, www.midominio2.es").
            config.EnableCors(urlPermitidas);  //habilitando las comunicaciones Cross Domain

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
