using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace AzureBillingViewer.Models {
  public class AzureSubscriptionsViewModel {
    [DisplayName("HTTP Request URL")]
    public string HttpRequestEndpoint { get; set; }

    [DisplayName("HTTP Response Body")]
    public string HttpResponseBody { get; set; }

    [DisplayName("Azure Subscriptions")]
    public List<AzureSubscription> AzureSubscriptions { get; set; }
    public string SelectedSubscription { get; set; }

    public AzureSubscriptionsViewModel() {
      AzureSubscriptions = new List<AzureSubscription>();
    }
  }
}