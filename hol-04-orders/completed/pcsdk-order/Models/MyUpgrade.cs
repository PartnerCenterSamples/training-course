using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pcsdk_order.Models {
  public class MyUpgrade {
    public string TargetOfferId { get; set; }
    public string TargetOfferName { get; set; }
    public string TargetOfferDescription { get; set; }
    public int Quantity { get; set; }
    public string UpgradeType { get; set; }

    public MyUpgrade() {
      Quantity = 0;
      UpgradeType = "None";
    }
  }
}