using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using AzureBillingViewer.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AzureBillingViewer.Models {
  public enum AggregationGranularity {
    Daily,
    Hourly
  }
  public class AzureUsageRepository {
    public static async Task<AzureUsageHttpResponse> GetUsage(string subscriptionId,
                                              DateTime reportedStart,
                                              DateTime reportedEnd,
                                              AggregationGranularity? granularity = AggregationGranularity.Daily,
                                              bool? showDetails = true) {
      // get access token
      var accessToken = await AadAuthHelper.GetAadAuthToken(SettingsHelper.AzureManagementApiResourceId);

      // setup authenticated http client
      var httpClient = new HttpClient();
      httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
      httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

      // create request
      var azQueryPath = string.Format("subscriptions/{0}/providers/Microsoft.Commerce/UsageAggregates?api-version=2015-06-01-preview&reportedStartTime={1}&reportedEndTime={2}&aggregationGranularity={3}&showDetails={4}",
        HttpUtility.UrlEncode(subscriptionId),
        HttpUtility.UrlEncode(reportedStart.ToString("s")),
        HttpUtility.UrlEncode(reportedEnd.ToString("s")),
        HttpUtility.UrlEncode(granularity.ToString()),
        HttpUtility.UrlEncode(showDetails.ToString()));
      var query = string.Format(SettingsHelper.AzureManagementApiEndpoint, azQueryPath);
      var request = new HttpRequestMessage(HttpMethod.Get, query);

      // issue request and convert response to typed object
      var response = await httpClient.SendAsync(request);
      var rawResponseString = await response.Content.ReadAsStringAsync();
      var azarmResponse = JsonConvert.DeserializeObject<AzureUsageHttpResponse>(rawResponseString);

      // POSTPROCESS - some fields contain a dynamic JSON object as a string
      //  need to do additional processing on these
      //  if data present in RawInstanceData, handle it
      if (azarmResponse.LineItems != null) {
        foreach (var lineItem in azarmResponse.LineItems) {
          if (lineItem.Properties.InstanceDataRaw != null) {
            lineItem.Properties.InstanceData = PostProcessInstanceData(lineItem.Properties.InstanceDataRaw);
          }
        };
      }

      return azarmResponse;
    }

    private static InstanceData PostProcessInstanceData(string rawInstanceData) {
      // replace all quotes
      rawInstanceData = rawInstanceData.Replace("\\", string.Empty);
      var subParsedInstanceData = JsonConvert.DeserializeObject<InstanceData>(rawInstanceData);

      // if there are tags, add them to the tag dictionary
      if (subParsedInstanceData.MicrosoftResources.TagsRaw != null) {
        subParsedInstanceData.MicrosoftResources.Tags = ConvertDynamicJsonToDictionary((JObject)subParsedInstanceData.MicrosoftResources.TagsRaw);
      }

      // if there is additional info, add to the additional info dictionary
      if (subParsedInstanceData.MicrosoftResources.AdditionalInfoRaw != null) {
        subParsedInstanceData.MicrosoftResources.AdditionalInfo = ConvertDynamicJsonToDictionary((JObject)subParsedInstanceData.MicrosoftResources.AdditionalInfoRaw);
      }

      return subParsedInstanceData;
    }

    private static Dictionary<string,string> ConvertDynamicJsonToDictionary(JObject dynamicJson) {
      Dictionary<string, string> extractedJson = new Dictionary<string, string>();

      try {
        foreach (var prop in dynamicJson) {
          extractedJson.Add(prop.Key, prop.Value.ToString());
        }
      } catch { }

      return extractedJson;
    }
  }
}