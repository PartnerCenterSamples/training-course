using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AzureBillingViewer.Models {
  [Bind(Include = "AzureSubscriptionId,ReportedStart,ReportedEnd,ShowDetails")]
  public class AzureUsageViewModel {
    [DisplayName("Subscription ID")]
    public string AzureSubscriptionId { get; set; }

    [DisplayName("Reported Start Date (UTC)")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime ReportedStart { get; set; }

    [DisplayName("Reported End Date (UTC)")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime ReportedEnd { get; set; }

    [DisplayName("Report Granularity")]
    public AggregationGranularity Granularity { get; set; }

    [DisplayName("Show Details")]
    public bool ShowDetails { get; set; }

    [DisplayName("Report ID")]
    public string UsageDetailReportId { get; set; }
    [DisplayName("Report Name")]
    public string UsageDetailReportName { get; set; }
    [DisplayName("Report Type")]
    public string UsageDetailReportType { get; set; }
    public List<UsageDetailProperties> UsageDetails { get; set; }

    public AzureUsageViewModel() {
      UsageDetails = new List<UsageDetailProperties>();
    }
  }
}