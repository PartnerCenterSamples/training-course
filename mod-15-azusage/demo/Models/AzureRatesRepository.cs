using System.Web;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using AzureBillingViewer.Services;
using AzureBillingViewer.Utilities;

namespace AzureBillingViewer.Models {
  public class AzureRatesRepository {

    public static async Task<AzureRateCardHttpResponse> GetRates(string subscriptionId,
                                                                 string offerId,
                                                                 AzureRegion region,
                                                                 string locale) {
      // get access token
      var accessToken = await AadAuthHelper.GetAadAuthToken(SettingsHelper.AzureManagementApiResourceId);

      // setup authenticated http client
      var httpClient = new HttpClient();
      httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
      httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

      // create request
      var azQueryPath = string.Format("subscriptions/{0}/providers/Microsoft.Commerce/RateCard?api-version=2015-06-01-preview&$filter=OfferDurableId eq '{1}' and Currency eq '{2}' and Locale eq '{3}' and RegionInfo eq '{4}'",
         HttpUtility.UrlEncode(subscriptionId),
         HttpUtility.UrlEncode(offerId),
         HttpUtility.UrlEncode(region.CurrencyCode),
         HttpUtility.UrlEncode(locale),
         HttpUtility.UrlEncode(region.Id));
      var query = string.Format(SettingsHelper.AzureManagementApiEndpoint, azQueryPath);
      var request = new HttpRequestMessage(HttpMethod.Get, query);

      // issue request and convert response to typed object
      var response = await httpClient.SendAsync(request);
      var rawResponseString = await response.Content.ReadAsStringAsync();
      var azarmResponse = JsonConvert.DeserializeObject<AzureRateCardHttpResponse>(rawResponseString);

      return azarmResponse;
    }

  }
}