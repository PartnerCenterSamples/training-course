using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Store.PartnerCenter;
using Microsoft.Store.PartnerCenter.Models.Offers;
using pcsdk_order.Utilities;

namespace pcsdk_order.Models {
  public class MyOfferRepository {
    private static IAggregatePartner _partner;

    private static async Task<IAggregatePartner> GetPartner() {
      if (_partner == null) {
        _partner = await PcAuthHelper.GetPartnerCenterOps();
      }

      return _partner;
    }

    public static async Task<MyOffer> GetOffer(string offerId) {
      _partner = await GetPartner();

      // get offer from PC & convert to local model
      var pcOffer = await _partner.Offers.ByCountry("US").ById(offerId).GetAsync();
      var offer = await ConvertOffer(pcOffer);

      return offer;
    }

    private static async Task<MyOffer> ConvertOffer(Offer pcOffer) {
      var offer = new MyOffer {
        Id = pcOffer.Id,
        Category = pcOffer.Category.Id,
        UnitType = pcOffer.UnitType,
        Name = pcOffer.Name,
        Description = pcOffer.Description,
        IsAddon = pcOffer.IsAddOn,
        MinQuanity = pcOffer.MinimumQuantity,
        MaxQuantity = pcOffer.MaximumQuantity
      };

      return offer;
    }
  }
}