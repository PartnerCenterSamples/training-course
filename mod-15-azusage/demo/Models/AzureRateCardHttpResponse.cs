using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AzureBillingViewer.Models {
  public class AzureRateCardHttpResponse {
    public OfferTerm[] OfferTerms { get; set; }
    public Meter[] Meters { get; set; }
    public string Currency { get; set; }
    public string Locale { get; set; }
    public bool IsTaxIncluded { get; set; }
    public string MeterRegion { get; set; }
    public object[] Tags { get; set; }
  }

  public class OfferTerm {
    public string Name { get; set; }
    public float Credit { get; set; }
    public Dictionary<decimal, decimal> TieredDiscount { get; set; }
    public string[] ExcludedMeterIds { get; set; }
    public DateTime EffectiveDate { get; set; }
  }

  public class Meter {
    public string MeterId { get; set; }
    public string MeterName { get; set; }
    public string MeterCategory { get; set; }
    public string MeterSubCategory { get; set; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string MeterRegion { get; set; }
    public string Unit { get; set; }
    public object[] MeterTags { get; set; }
    public Dictionary<decimal, decimal> MeterRates { get; set; }
    public DateTime EffectiveDate { get; set; }
    public float IncludedQuantity { get; set; }
  }

}