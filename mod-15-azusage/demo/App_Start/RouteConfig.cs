using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AzureBillingViewer {
  public class RouteConfig {
    public static void RegisterRoutes(RouteCollection routes) {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      // setup route to rates & usage
      routes.MapRoute(
        name: "SubscriptionDetails",
        url: "Subscriptions/{subscriptionId}/{controller}/{action}",
        defaults: new {
          action = "Index"
        }
      );

      // setup default route
      routes.MapRoute(
          name: "Default",
          url: "{controller}/{action}/{id}",
          defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
      );
    }
  }
}
