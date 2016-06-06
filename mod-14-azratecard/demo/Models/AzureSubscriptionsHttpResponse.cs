using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Newtonsoft.Json;

namespace AzureBillingViewer.Models {
  public class AzureSubscriptionsHttpResponse {
    [JsonProperty(PropertyName = "value")]
    public AzureSubscription[] AzureSubscriptions { get; set; }
    [JsonProperty(PropertyName = "nextLink")]
    public string nextLink { get; set; }
  }

  public class AzureSubscription {
    [JsonProperty(PropertyName = "id")]
    public string RelativePathUrlId { get; set; }
    [JsonProperty(PropertyName = "subscriptionId")]
    [DisplayName("Subscription ID")]
    public string SubscriptionId { get; set; }
    [JsonProperty(PropertyName = "displayName")]
    [DisplayName("Subscription Name")]
    public string DisplayName { get; set; }
    [JsonProperty(PropertyName = "state")]
    public string State { get; set; }
    [JsonProperty(PropertyName = "subscriptionPolicies")]
    public Subscriptionpolicies Policies { get; set; }
  }

  public class Subscriptionpolicies {
    [JsonProperty(PropertyName = "locationPlacementId")]
    public string LocationPlacementId { get; set; }
    [JsonProperty(PropertyName = "quotaId")]
    public string QuotaId { get; set; }
  }

}