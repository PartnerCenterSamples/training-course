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

    [Authorize]
    [HttpGet]
    public async Task<ActionResult> AddLicense(string customerId, string subscriptionId) {
      // if no ids provided, redirect to list 
      if (string.IsNullOrEmpty(customerId) || string.IsNullOrEmpty(subscriptionId)) {
        return RedirectToAction("Index");
      } else {
        CustomerAddLicenseViewModel viewModel = new CustomerAddLicenseViewModel();

        // get customer & add to viewmodel
        var customer = await MyCustomerRepository.GetCustomer(customerId);
        viewModel.Customer = customer;

        // get subscription
        var subscription = await MySubscriptionRepository.GetSubscription(customerId, subscriptionId);
        viewModel.CustomerSubscription = subscription;

        // create lookup for licenses available for purchase
        List<SelectListItem> dropDownItems = new List<SelectListItem>();
        for (int index = 1; index + subscription.Quantity <= subscription.Offer.MaxQuantity; index++) {
          dropDownItems.Add(new SelectListItem {
            Text = string.Format("add {0} more license(s) - total of {1}", index, subscription.Quantity + index),
            Value = index.ToString()
          });
          // limit adding only 1000 licenses at a time
          if (index == 1000) {
            break;
          }
        }
        viewModel.AvailableLicenseQuantity = dropDownItems;

        return View(viewModel);
      }
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult> AddLicense(string customerId, string subscriptionId, string licensesToAdd) {
      // if no ids provided, redirect to list 
      if (string.IsNullOrEmpty(customerId) || string.IsNullOrEmpty(subscriptionId) || string.IsNullOrEmpty(licensesToAdd)) {
        return RedirectToAction("Index");
      } else {
        // get customer
        var customer = await MyCustomerRepository.GetCustomer(customerId);

        // get subscription
        var subscription = await MySubscriptionRepository.GetSubscription(customerId, subscriptionId);

        // update quantity and save
        subscription.Quantity += Convert.ToInt16(licensesToAdd);
        await MySubscriptionRepository.UpdateSubscription(customerId, subscription);


        return RedirectToAction("Index");
      }
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult> UpgradeSubscription(string customerId, string subscriptionId) {
      // if no ids provided, redirect to list 
      if (string.IsNullOrEmpty(customerId) || string.IsNullOrEmpty(subscriptionId)) {
        return RedirectToAction("Index");
      } else {
        CustomerSubscriptionUpgradeViewModel viewModel = new CustomerSubscriptionUpgradeViewModel();

        // get customer & add to viewmodel
        var customer = await MyCustomerRepository.GetCustomer(customerId);
        viewModel.Customer = customer;

        // get subscription
        var subscription = await MySubscriptionRepository.GetSubscription(customerId, subscriptionId);
        viewModel.CustomerSubscription = subscription;

        // get upgrade options
        var upgrades = await MySubscriptionRepository.GetUpgradeOptions(customerId, subscriptionId);
        List<SelectListItem> upgadeOptions = new List<SelectListItem>();
        foreach (var upgrade in upgrades) {
          upgadeOptions.Add(new SelectListItem {
            Text = string.Format("Upgrade to offer '{0}' - Option: {1}", upgrade.TargetOfferName, upgrade.UpgradeType),
            Value = string.Format("{0}|{1}", upgrade.TargetOfferId, upgrade.UpgradeType)
          });
        }
        viewModel.UpgradeOptions = upgadeOptions;

        return View(viewModel);
      }
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult> UpgradeSubscription(string customerId, string subscriptionId, string upgradeOfferSelected) {
      // if no ids provided, redirect to list 
      if (string.IsNullOrEmpty(customerId) || string.IsNullOrEmpty(subscriptionId) || string.IsNullOrEmpty(upgradeOfferSelected)) {
        return RedirectToAction("Index");
      } else {
        // get customer
        var customer = await MyCustomerRepository.GetCustomer(customerId);

        // get subscription
        var subscription = await MySubscriptionRepository.GetSubscription(customerId, subscriptionId);

        // split upgrade up
        var targetOfferId = upgradeOfferSelected.Split("|".ToCharArray())[0];
        var targetUpgradeType = upgradeOfferSelected.Split("|".ToCharArray())[1];

        // upgrade the subscription
        await MySubscriptionRepository.UpgradeSubscrption(customerId, subscriptionId, targetOfferId, targetUpgradeType);

        return RedirectToAction("Index");
      }

    }

  }
}
