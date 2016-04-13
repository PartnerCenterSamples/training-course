using System;
using System.Configuration;

namespace pcsdk_order.Utilities {

  public class SettingsHelper {
    public static string ClientId
    {
      get { return ConfigurationManager.AppSettings["ida:ClientId"]; }
    }
    public static string ClientKey
    {
      get { return ConfigurationManager.AppSettings["ida:ClientSecret"]; }
    }
    public static string AadInstance
    {
      get { return ConfigurationManager.AppSettings["ida:AADInstance"]; }
    }
    public static string AadTenantId
    {
      get { return ConfigurationManager.AppSettings["ida:TenantId"]; }
    }
    public static string AadCommonAuthority
    {
      get { return string.Format("{0}common", SettingsHelper.AadInstance); }
    }
    public static string AadTenantAuthority
    {
      get { return string.Format("{0}{1}", SettingsHelper.AadInstance, SettingsHelper.AadTenantId); }
    }
    public static string AadGraphApiResourceId
    {
      get { return "https://graph.windows.net"; }
    }
    public static string AadGraphApiEndpoint
    {
      get { return SettingsHelper.AadGraphApiResourceId; }
    }
    public static string PartnerCenterApiResourceId
    {
      get { return "https://api.partnercenter.microsoft.com"; }
    }
    public static string PartnerCenterApiEndpoint
    {
      get { return SettingsHelper.PartnerCenterApiResourceId; }
    }
    public static string ClaimTypeObjectIdentifier
    {
      get { return "http://schemas.microsoft.com/identity/claims/objectidentifier"; }
    }
  }

}