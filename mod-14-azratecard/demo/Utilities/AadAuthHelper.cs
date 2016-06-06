using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AzureBillingViewer.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Threading.Tasks;
using System.Security.Claims;

namespace AzureBillingViewer.Utilities {
  public class AadAuthHelper {
    public static async Task<string> GetAadAuthToken(string resourceId) {
      ApplicationDbContext db = new ApplicationDbContext();

      // build client creds
      ClientCredential credential = new ClientCredential(SettingsHelper.ClientId, SettingsHelper.ClientKey);

      // get user info
      string userObjectId = ClaimsPrincipal.Current.FindFirst(SettingsHelper.ClaimTypeObjectIdentifier).Value;
      var userIdentifier = new UserIdentifier(userObjectId, UserIdentifierType.UniqueId);

      // get token from cache or get new token if not in cache
      AuthenticationContext authContext = new AuthenticationContext(SettingsHelper.AadTenantAuthority, new ADALTokenCache(userObjectId));
      var result = await authContext.AcquireTokenAsync(resourceId, credential);

      return result.AccessToken;
    }
  }
}