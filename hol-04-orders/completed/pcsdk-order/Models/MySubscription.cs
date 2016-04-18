using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pcsdk_order.Models {
  public class MySubscription {
    public string Id { get; set; }
    public MyOffer Offer { get; set; }
    public int Quantity { get; set; }
    public string Status { get; set; }
  }
}