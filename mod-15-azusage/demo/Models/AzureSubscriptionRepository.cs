using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Helpers;
using Newtonsoft.Json;
using AzureBillingViewer.Utilities;

namespace AzureBillingViewer.Models {
  public class AzureSubscriptionRepository {
    private const string KEY_AZURE_SUBSCRIPTIONS = "azuresubscriptions";

    public static async Task<List<AzureSubscription>> GetSubscriptions(bool fromServer = true) {
      List<AzureSubscription> results = new List<AzureSubscription>();

      // if fromServer = false, try to get previous subscriptions from cache
      if (!fromServer) {
        results = HttpContext.Current.Session[KEY_AZURE_SUBSCRIPTIONS] as List<AzureSubscription>;
      }

      // if have sessions from cache | told to get from server, return them...
      if (results.Any()) {
        return results;
      }
      // ... else continue to get them from server

      // get access token
      var accessToken = await AadAuthHelper.GetAadAuthToken(SettingsHelper.AzureManagementApiResourceId);

      // setup authenticated http client
      var httpClient = new HttpClient();
      httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
      httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

      // create request
      var azQueryPath = "subscriptions/?api-version=2014-04-01";
      var query = string.Format(SettingsHelper.AzureManagementApiEndpoint, azQueryPath);
      var request = new HttpRequestMessage(HttpMethod.Get, query);

      // issue request and convert response to typed object
      var response = await httpClient.SendAsync(request);
      var rawResponseString = await response.Content.ReadAsStringAsync();
      var azarmResponse = JsonConvert.DeserializeObject<AzureSubscriptionsHttpResponse>(rawResponseString);

      // convert to normal collection
      results.AddRange(azarmResponse.AzureSubscriptions);

      return results;
    }
  }
}