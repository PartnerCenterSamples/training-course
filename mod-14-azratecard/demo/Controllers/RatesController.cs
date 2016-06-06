using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Web.Routing;
using AzureBillingViewer.Models;
using AzureBillingViewer.Services;

namespace AzureBillingViewer.Controllers {
  public class RatesController : Controller {
    [Authorize]
    public async Task<ActionResult> Index(string subscriptionId,
                                          string azureOfferId = "MS-AZR-0044P",
                                          string azureRegionId = "US",
                                          string localeId = "en-US") {

      // verify subscription id present
      if (string.IsNullOrEmpty(subscriptionId)) {
        return RedirectToRoute("Default", new { controller = "Subscriptions" });
      }

      // get all regions & locals
      var offers = new List<AzureBillingViewer.Services.AzureOffer>(from offer in AzureOfferService.List()
                                                                    orderby offer.Retired, offer.Name
                                                                    select offer);
      var regions = new List<AzureRegion>(AzureRegionService.List());
      var locales = new List<string>(LocaleService.List());

      // init view model
      AzureRatesViewModel viewModel = new AzureRatesViewModel {
        AzureSubscriptionId = subscriptionId,
        AzureOfferId = azureOfferId,
        AzureRegion = regions.First(r => r.Id == azureRegionId),
        AzureRegionId = azureRegionId,
        LocaleId = localeId,
        AvailableAzureOffers = offers.Select(z => new SelectListItem {
          Text = (z.Retired)
                    ? string.Format("(retired) {0} - {1}", z.Id, z.Name)
                    : string.Format("{0} {1}", z.Id, z.Name),
          Value = z.Id
        }),
        AvailableAzureRegions = regions.OrderBy(x => x.Name).Select(y => new SelectListItem {
          Text = y.Name,
          Value = y.Id
        }),
        AvailableLocales = locales.Select(y => new SelectListItem {
          Text = y,
          Value = y
        })
      };


      // get rate info from Azure
      var azureRates = await AzureRatesRepository.GetRates(viewModel.AzureSubscriptionId,
                                                           viewModel.AzureOfferId,
                                                           viewModel.AzureRegion,
                                                           viewModel.LocaleId);

      // update view model
      if (azureRates.OfferTerms.Any()) {
        viewModel.AzureOfferName = azureRates.OfferTerms[0].Name;
        viewModel.OfferCredit = azureRates.OfferTerms[0].Credit;
        viewModel.EffectiveDate = azureRates.OfferTerms[0].EffectiveDate;
        viewModel.ExcludedMeterIds.AddRange(azureRates.OfferTerms[0].ExcludedMeterIds);
        viewModel.TieredDiscounts = azureRates.OfferTerms[0].TieredDiscount;
      }
      viewModel.MeterRegion = azureRates.MeterRegion;
      viewModel.IsTaxIncluded = azureRates.IsTaxIncluded;
      //viewModel.Tags = azureRates.Tags;
      viewModel.Meters.AddRange(azureRates.Meters
        .OrderBy(x => x.MeterCategory)
        .OrderBy(x => x.MeterSubCategory)
        .OrderBy(x => x.MeterName)
        .OrderBy(x => x.MeterRegion)
        );

      return View(viewModel);
    }
  }
}