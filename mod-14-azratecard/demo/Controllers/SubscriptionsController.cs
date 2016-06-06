using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using AzureBillingViewer.Models;

namespace AzureBillingViewer.Controllers {
  [Authorize]
  public class SubscriptionsController : Controller {
    // GET: Subscriptions
    public async Task<ActionResult> Index() {
      // get subscriptions
      var subscriptions = await AzureSubscriptionRepository.GetSubscriptions();

      // create view model for view
      AzureSubscriptionsViewModel viewModel = new AzureSubscriptionsViewModel {
        AzureSubscriptions = subscriptions
      };

      return View(viewModel);
    }
  }
}