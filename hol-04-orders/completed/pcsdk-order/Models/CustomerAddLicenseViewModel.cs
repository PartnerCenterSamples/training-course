using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pcsdk_order.Models {
  public class CustomerAddLicenseViewModel {
    public MyCustomer Customer { get; set; }

    public MySubscription CustomerSubscription { get; set; }

    public string LicensesToAdd { get; set; }

    public IEnumerable<SelectListItem> AvailableLicenseQuantity { get; set; }

    public CustomerAddLicenseViewModel() {
      AvailableLicenseQuantity = new List<SelectListItem>();
    }
  }
}