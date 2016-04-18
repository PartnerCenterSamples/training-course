using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Store.PartnerCenter;
using Microsoft.Store.PartnerCenter.Models.Subscriptions;
using pcsdk_order.Utilities;

namespace pcsdk_order.Models {
  public class MySubscriptionRepository {

    private static IAggregatePartner _partner;

    private static async Task<IAggregatePartner> GetPartner() {
      if (_partner == null) {
        _partner = await PcAuthHelper.GetPartnerCenterOps();
      }

      return _partner;
    }

    public static async Task<List<MySubscription>> GetSubscriptions(string customerId) {
      var pcSubscriptions = await (await GetPartner()).Customers.ById(customerId).Subscriptions.GetAsync();

      List<MySubscription> subscriptions = new List<MySubscription>();
       
      foreach(var pcSubscription in pcSubscriptions.Items) {
        subscriptions.Add(await ConvertSubscription(pcSubscription));
      }

      return subscriptions;
    }

    public static async Task<MySubscription> GetSubscription(string customerId, string subscriptionId) {
      var pcSubscription = await (await GetPartner()).Customers.ById(customerId).Subscriptions.ById(subscriptionId).GetAsync();

      return await ConvertSubscription(pcSubscription);
    }

    public static async Task UpdateSubscription(string customerId, MySubscription subscription) {
      // get subscription
      var pcSubscription = await(await GetPartner()).Customers.ById(customerId).Subscriptions.ById(subscription.Id).GetAsync();
      // update quantity 
      pcSubscription.Quantity = subscription.Quantity;
      // update subscription
      await (await GetPartner()).Customers.ById(customerId).Subscriptions.ById(subscription.Id).PatchAsync(pcSubscription);
    }

    public static async Task<List<MyUpgrade>> GetUpgradeOptions(string customerId, string subscriptionId) {
      var pcSubscription = (await GetPartner()).Customers.ById(customerId).Subscriptions.ById(subscriptionId);
      var pcUpgrades = await pcSubscription.Upgrades.GetAsync();

      List<MyUpgrade> upgrades = new List<MyUpgrade>();

      foreach(var pcUpgrade in pcUpgrades.Items) {
        upgrades.Add(await ConvertUpgradeOffer(pcUpgrade));
      }

      return upgrades;
    }

    public static async Task UpgradeSubscrption(string customerId, string subscriptionId, string targetOfferId, string targetUpgradeType) {
      var pcSubscription = (await GetPartner()).Customers.ById(customerId).Subscriptions.ById(subscriptionId);
      var pcUpgrades = await pcSubscription.Upgrades.GetAsync();

      // get the one selected
      var upgradeSelected = pcUpgrades.Items.First(upgrade => (upgrade.TargetOffer.Id == targetOfferId && upgrade.UpgradeType.ToString() == targetUpgradeType));
      // upgrade
      var result = pcSubscription.Upgrades.Create(upgradeSelected);
      // handle issues
    }

    private static async Task<MySubscription> ConvertSubscription(Subscription pcSubscription) {
      var subscription = new MySubscription {
        Id = pcSubscription.Id,
        Offer = await MyOfferRepository.GetOffer(pcSubscription.OfferId),
        Quantity = pcSubscription.Quantity,
        Status = pcSubscription.Status.ToString()
      };

      return subscription;
    }

    private static async Task<MyUpgrade> ConvertUpgradeOffer(Upgrade pcUpgrade) {
      var upgrade = new MyUpgrade {
        TargetOfferId = pcUpgrade.TargetOffer.Id,
        TargetOfferName = pcUpgrade.TargetOffer.Name,
        TargetOfferDescription = pcUpgrade.TargetOffer.Description,
        Quantity = pcUpgrade.Quantity,
        UpgradeType = pcUpgrade.UpgradeType.ToString()
      };

      return upgrade;
    }

  }
}