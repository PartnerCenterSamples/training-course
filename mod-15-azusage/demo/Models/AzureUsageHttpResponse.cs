using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace AzureBillingViewer.Models {
  public class AzureUsageHttpResponse {
    [JsonProperty(PropertyName = "value")]
    public UsageDetail[] LineItems { get; set; }
  }

  public class UsageDetail {
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }
    [JsonProperty(PropertyName = "properties")]
    public UsageDetailProperties Properties { get; set; }
  }

  public class UsageDetailProperties {
    [JsonProperty(PropertyName = "subscriptionId")]
    public string SubscriptionId { get; set; }
    [JsonProperty(PropertyName = "usageStartTime")]
    public DateTime UsageStartTime { get; set; }
    [JsonProperty(PropertyName = "usageEndTime")]
    public DateTime UsageEndTime { get; set; }
    [JsonProperty(PropertyName = "meterName")]
    public string MeterName { get; set; }
    [JsonProperty(PropertyName = "meterCategory")]
    public string MeterCategory { get; set; }
    [JsonProperty(PropertyName = "unit")]
    public string Unit { get; set; }
    [JsonProperty(PropertyName = "meterId")]
    public string MeterId { get; set; }
    [JsonProperty(PropertyName = "infoFields")]
    public Infofields InfoFields { get; set; }

    // for InstanceData, it comes back as a string, not as an object
    //  this requires post-processing... the InstanceDataRaw = string which is the raw data from Azure
    //  the InstanceData property is an object... this is where the post-processed data will go
    [JsonProperty(PropertyName = "instanceData",
                  NullValueHandling = NullValueHandling.Ignore)]
    public string InstanceDataRaw { get; set; }
    [JsonIgnore]
    public InstanceData InstanceData { get; set; }

    [JsonProperty(PropertyName = "quantity")]
    public float Quantity { get; set; }
    [JsonProperty(PropertyName = "meterSubCategory")]
    public string MeterSubCategory { get; set; }
  }

  public class Infofields {
    [JsonProperty(PropertyName = "meteredRegion")]
    public string MeteredRegion { get; set; }
    [JsonProperty(PropertyName = "meteredService")]
    public string MeteredService { get; set; }
    [JsonProperty(PropertyName = "meteredServiceType")]
    public string MeteredServiceType { get; set; }
    [JsonProperty(PropertyName = "project")]
    public string Project { get; set; }
  }

  public class InstanceData {
    [JsonProperty(PropertyName = "Microsoft.Resources")]
    public MicrosoftResources MicrosoftResources { get; set; }
  }

  public class MicrosoftResources {
    [JsonProperty(PropertyName = "resourceUri")]
    public string ResourceUri { get; set; }

    [JsonProperty(PropertyName = "location")]
    public string Location { get; set; }

    // for Tags, it comes back as a string, not as an object
    //  this requires post-processing... the TagsRaw = string which is the raw data from Azure
    //  the Tags property is an object... this is where the post-processed data will go
    [JsonProperty(PropertyName = "tags",
                  NullValueHandling = NullValueHandling.Ignore)]
    public dynamic TagsRaw { get; set; }
    [JsonIgnore]
    public Dictionary<string, string> Tags { get; set; }

    // for AdditionalInfo, it comes back as a string, not as an object
    //  this requires post-processing... the AdditionalInfoRaw = string which is the raw data from Azure
    //  the AdditionalInfo property is an object... this is where the post-processed data will go
    [JsonProperty(PropertyName = "additionalInfo",
                  NullValueHandling = NullValueHandling.Ignore)]
    public dynamic AdditionalInfoRaw { get; set; }
    [JsonIgnore]
    public Dictionary<string, string> AdditionalInfo { get; set; }

    [JsonProperty(PropertyName = "partNumber",
                  NullValueHandling = NullValueHandling.Ignore)]
    public string PartNumber { get; set; }

    [JsonProperty(PropertyName = "orderNumber",
                  NullValueHandling = NullValueHandling.Ignore)]
    public string OrderNumber { get; set; }

    public MicrosoftResources() {
      Tags = new Dictionary<string, string>();
      AdditionalInfo = new Dictionary<string, string>();
    }
  }

}



