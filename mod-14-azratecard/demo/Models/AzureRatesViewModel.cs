using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using AzureBillingViewer.Services;
using System.Security.Cryptography;
using System.Text;

namespace AzureBillingViewer.Models {
  [Bind(Include = "AzureSubscriptionId,AzureOfferId,LocaleId,RegionId,CurrencyId")]
  public class AzureRatesViewModel {
    // filter fields
    [DisplayName("Subscription ID")]
    public string AzureSubscriptionId { get; set; }
    [DisplayName("Offer ID")]
    public string AzureOfferId { get; set; }
    [DisplayName("Locale")]
    public string LocaleId { get; set; }
    [DisplayName("Region")]
    public string AzureRegionId { get; set; }
    public AzureRegion AzureRegion { get; set; }

    // pickers
    public IEnumerable<SelectListItem> AvailableAzureOffers { get; set; }
    public IEnumerable<SelectListItem> AvailableLocales { get; set; }
    public IEnumerable<SelectListItem> AvailableAzureRegions { get; set; }

    // offer details
    [DisplayName("Azure Offer")]
    public string AzureOfferName { get; set; }

    [DisplayName("Included Credit")]
    [DataType(DataType.Currency)]
    [DisplayFormat(DataFormatString = "{0:C}")]
    public float? OfferCredit { get; set; }

    [DisplayName("Effective")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy HH:mm:ss 'UTC'}")]
    public DateTime EffectiveDate { get; set; }
    [DisplayName("Meters Excluded from Discount")]
    public List<string> ExcludedMeterIds { get; set; }
    [DisplayName("Tiered Discounts")]
    public Dictionary<decimal, decimal> TieredDiscounts { get; set; }

    // meter response details
    [DisplayName("Meter Region")]
    public string MeterRegion { get; set; }
    public Dictionary<string, string> Tags { get; set; }
    [DisplayName("Tax Included")]
    public bool IsTaxIncluded { get; set; }

    // meters
    public List<Meter> Meters { get; set; }

    public AzureRatesViewModel() {
      // default response object
      ExcludedMeterIds = new List<string>();
      TieredDiscounts = new Dictionary<decimal, decimal>();
      Meters = new List<Meter>();
    }

    public string GetHashedString(string input) {
      var hashedInput = string.Empty;

      using (MD5 md5Hash = MD5.Create()) {
        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
        StringBuilder sb = new StringBuilder();
        for (int i=0; i<data.Length; i++) {
          sb.Append(data[i].ToString("x2"));
        }
        hashedInput = sb.ToString();
      }

      return hashedInput;
    }
  }

}