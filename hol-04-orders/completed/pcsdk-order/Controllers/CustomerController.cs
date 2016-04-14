using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using pcsdk_order.Models;

namespace pcsdk_order.Controllers {
  [Authorize]
  public class CustomerController : Controller {
    // GET: Customer
    public async Task<ActionResult> Index() {
      CustomerViewModel viewModel = new CustomerViewModel();
      viewModel.Customers = await MyCustomerRepository.GetCustomers();
      return View(viewModel);
    }

    [Authorize]
    public async Task<ActionResult> Subscriptions(string id) {
      // if no customer provided, redirect to list 
      if (string.IsNullOrEmpty(id)) {
        return RedirectToAction("Index");
      } else {
        CustomerSubscriptionViewModel viewModel = new CustomerSubscriptionViewModel();

        // get customer & add to viewmodel
        var customer = await MyCustomerRepository.GetCustomer(id);
        viewModel.Customer = customer;

        // get all subscriptions customer currently has
        var subscriptions = await MySubscriptionRepository.GetSubscriptions(id);
        viewModel.CustomerSubscriptions = subscriptions.OrderBy(s => s.Offer.Name).ToList();

        return View(viewModel);
      }
    }

  }
}
