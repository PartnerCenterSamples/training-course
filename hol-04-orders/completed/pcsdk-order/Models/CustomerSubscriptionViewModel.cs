using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pcsdk_order.Models {
  public class CustomerSubscriptionViewModel {
    public MyCustomer Customer { get; set; }

    public List<MySubscription> CustomerSubscriptions { get; set; }

  }
}