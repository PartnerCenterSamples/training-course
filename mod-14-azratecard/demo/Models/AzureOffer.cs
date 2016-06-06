using System;
using System.ComponentModel;

namespace AzureBillingViewer.Models {
  public class AzureOffer {
    [DisplayName("Display Name")]
    public string DisplayName { get; set; }
    [DisplayName("OfferId")]
    public string OfferId { get; set; }
  }
}