using Blueyonder.Companion.Controllers;
using Blueyonder.Companion.Controllers.Formatters;
using Blueyonder.Companion.Host;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace Blueyonder.Web.Client
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.DependencyResolver = new BlueYonderResolver();

            config.Formatters.Add(new AtomFormatter());
            config.MessageHandlers.Add(new AtomHandler());

            config.Routes.MapHttpRoute(
                name: "atom",
                routeTemplate: "atom/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "TravelerReservationsApi",
                routeTemplate: "travelers/{travelerId}/reservations",
                defaults: new
                {
                    controller = "reservations",
                    id = RouteParameter.Optional
                }
            );

            config.Routes.MapHttpRoute(
               name: "ReservationsApi",
               routeTemplate: "Reservations/{id}",
               defaults: new
               {
                   controller = "Reservations",
                   action = "GetReservation"
               },
               constraints: new
               {
                   httpMethod = new HttpMethodConstraint(HttpMethod.Get)
               }
           );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


           
        }
    }
}
