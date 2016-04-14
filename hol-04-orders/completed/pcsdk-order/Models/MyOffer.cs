using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pcsdk_order.Models {
  public class MyOffer {
    public string Id { get; set; }
    public bool IsAddon { get; set; }
    public string UnitType { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int MinQuanity { get; set; }
    public int MaxQuantity { get; set; }
    public string Category { get; set; }
  }
}