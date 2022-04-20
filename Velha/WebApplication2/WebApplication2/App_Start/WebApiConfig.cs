using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApplication2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuração e serviços de API Web

            // Rotas de API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Login Route",
                routeTemplate: "api/login/{userName}/{senha}",
                new {
                    controller = "Player",
                    userName = String.Empty,
                    senha = String.Empty,
                }
            );
        }
    }
}
