using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AzureBillingViewer.Models;

namespace AzureBillingViewer.Controllers {
  public class UsageController : Controller {
    [Authorize]
    public async Task<ActionResult> Index(string subscriptionId,
                                          DateTime? reportedStart = null,
                                          DateTime? reportedEnd = null,
                                          AggregationGranularity granularity = AggregationGranularity.Daily,
                                          bool showDetails = true) {

      // verify subscription id present
      if (string.IsNullOrEmpty(subscriptionId)) {
        return RedirectToRoute("Default", new { controller = "Subscriptions" });
      }

      // fixup defaults
      var now = DateTime.UtcNow;
      if (!reportedStart.HasValue) {
        reportedStart = new DateTime(now.Year, now.Month, 1, 0, 0, 0);
      }
      if (!reportedEnd.HasValue) {
        reportedEnd = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
      }

      // get usage info from Azure
      var azureUsage = await AzureUsageRepository.GetUsage(subscriptionId,
                                                           reportedStart.Value,
                                                           reportedEnd.Value,
                                                           granularity,
                                                           showDetails);

      // create viewmodel
      //  > all line items have same report id, name & type
      var sharedLineItems = azureUsage.LineItems != null ? azureUsage.LineItems[0] : null;
      AzureUsageViewModel viewModel = new AzureUsageViewModel() {
        AzureSubscriptionId = subscriptionId,
        UsageDetailReportId = (sharedLineItems != null) ? sharedLineItems.Id : string.Empty,
        UsageDetailReportName = (sharedLineItems != null) ? sharedLineItems.Name : string.Empty,
        UsageDetailReportType = (sharedLineItems != null) ? sharedLineItems.Type : string.Empty,
        ReportedStart = reportedStart.Value,
        ReportedEnd = reportedEnd.Value,
        Granularity = granularity,
        ShowDetails = showDetails
      };

      // loop through all line items and aggregate...
      List<UsageDetailProperties> usageDetails = new List<UsageDetailProperties>();
      if (azureUsage.LineItems != null) {
        foreach (var lineItem in azureUsage.LineItems) {
          usageDetails.Add(lineItem.Properties);
        }
      }
      // sort it up
      viewModel.UsageDetails.AddRange(from detail in usageDetails
                                      orderby detail.MeterCategory, detail.MeterSubCategory, detail.MeterName, detail.UsageStartTime
                                      select detail);


      return View(viewModel);
    }
  }
}