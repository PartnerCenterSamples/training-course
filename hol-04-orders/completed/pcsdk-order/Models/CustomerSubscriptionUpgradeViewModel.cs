using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pcsdk_order.Models {
  public class CustomerSubscriptionUpgradeViewModel {
    public MyCustomer Customer { get; set; }

    public MySubscription CustomerSubscription { get; set; }

    public string UpgradeOfferSelected { get; set; }

    public IEnumerable<SelectListItem> UpgradeOptions { get; set; }

    public CustomerSubscriptionUpgradeViewModel() {
      UpgradeOptions = new List<SelectListItem>();
    }
  }
}