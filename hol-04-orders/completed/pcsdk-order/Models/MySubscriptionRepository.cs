﻿using System;
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

    private static async Task<MySubscription> ConvertSubscription(Subscription pcSubscription) {
      var subscription = new MySubscription {
        Id = pcSubscription.Id,
        Offer = await MyOfferRepository.GetOffer(pcSubscription.OfferId),
        Quantity = pcSubscription.Quantity
      };

      return subscription;
    }

  }
}