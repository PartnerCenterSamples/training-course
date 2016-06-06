using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureBillingViewer.Services {

  public class AzureOffer {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public bool Retired { get; set; }
  }
  public class AzureOfferService {
    public static IEnumerable<AzureOffer> List() {
      return new List<AzureOffer> {
        new AzureOffer {Id = "MS-AZR-0003P", Name = "Pay-As-You-Go", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0003P" },
        new AzureOffer {Id = "MS-AZR-0033P", Name = "Azure Dynamics", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0033P" },
        new AzureOffer {Id = "MS-AZR-0041P", Name = "Support Plans", Retired = false, Url = "https://azure.microsoft.com/en-us/support/plans/" },
        new AzureOffer {Id = "MS-AZR-0042P", Name = "Support Plans", Retired = false, Url = "https://azure.microsoft.com/en-us/support/plans/" },
        new AzureOffer {Id = "MS-AZR-0043P", Name = "Support Plans", Retired = false, Url = "https://azure.microsoft.com/en-us/support/plans/" },
        new AzureOffer {Id = "MS-AZR-0044P", Name = "Free Trial", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0044P" },
        new AzureOffer {Id = "MS-AZR-0059P", Name = "Visual Studio Professional subscribers", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0059P" },
        new AzureOffer {Id = "MS-AZR-0060P", Name = "Visual Studio Test Professional subscribers", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0060P" },
        new AzureOffer {Id = "MS-AZR-0062P", Name = "MSDN Platforms subscribers", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0062P" },
        new AzureOffer {Id = "MS-AZR-0063P", Name = "Visual Studio Enterprise subscribers", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0063P" },
        new AzureOffer {Id = "MS-AZR-0064P", Name = "Visual Studio Enterprise (BizSpark) subscribers", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0064P" },
        new AzureOffer {Id = "MS-AZR-0029P", Name = "Visual Studio Enterprise (MPN) subscribers", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0029P" },
        new AzureOffer {Id = "MS-AZR-0022P", Name = "Visual Studio Dev Essentials members", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0022P" },
        new AzureOffer {Id = "MS-AZR-0023P", Name = "Pay-As-You-Go Dev/Test", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0023P" },
        new AzureOffer {Id = "MS-AZR-0148P", Name = "Enterprise Dev/Test", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0148P" },
        new AzureOffer {Id = "MS-AZR-0025P", Name = "Action Pack", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0025P" },
        new AzureOffer {Id = "MS-AZR-0036P", Name = "Microsoft Azure Sponsored Offer", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0036P" },
        new AzureOffer {Id = "MS-AZR-0070P", Name = "Promotional Offer", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/ms-azr-0070p" },
        new AzureOffer {Id = "MS-AZR-0071P", Name = "Promotional Offer", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/ms-azr-0071p" },
        new AzureOffer {Id = "MS-AZR-0072P", Name = "Promotional Offer", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/ms-azr-0072p" },
        new AzureOffer {Id = "MS-AZR-0073P", Name = "Promotional Offer", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/ms-azr-0073p" },
        new AzureOffer {Id = "MS-AZR-0074P", Name = "Promotional Offer", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/ms-azr-0074p" },
        new AzureOffer {Id = "MS-AZR-0075P", Name = "Promotional Offer", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/ms-azr-0075p" },
        new AzureOffer {Id = "MS-AZR-0076P", Name = "Promotional Offer", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/ms-azr-0076p" },
        new AzureOffer {Id = "MS-AZR-0077P", Name = "Promotional Offer", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/ms-azr-0077p" },
        new AzureOffer {Id = "MS-AZR-0078P", Name = "Promotional Offer", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/ms-azr-0078p" },
        new AzureOffer {Id = "MS-AZR-0079P", Name = "Promotional Offer", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/ms-azr-0079p" },
        new AzureOffer {Id = "MS-AZR-0080P", Name = "Promotional Offer", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/ms-azr-0080p" },
        new AzureOffer {Id = "MS-AZR-0081P", Name = "Promotional Offer", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/ms-azr-0081p" },
        new AzureOffer {Id = "MS-AZR-0082P", Name = "Promotional Offer", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/ms-azr-0082p" },
        new AzureOffer {Id = "MS-AZR-0083P", Name = "Promotional Offer", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/ms-azr-0083p" },
        new AzureOffer {Id = "MS-AZR-0084P", Name = "Promotional Offer", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/ms-azr-0084p" },
        new AzureOffer {Id = "MS-AZR-0085P", Name = "Promotional Offer", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/ms-azr-0085p" },
        new AzureOffer {Id = "MS-AZR-0086P", Name = "Promotional Offer", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/ms-azr-0086p" },
        new AzureOffer {Id = "MS-AZR-0087P", Name = "Promotional Offer", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/ms-azr-0087p" },
        new AzureOffer {Id = "MS-AZR-0088P", Name = "Promotional Offer", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/ms-azr-0088p" },
        new AzureOffer {Id = "MS-AZR-0089P", Name = "Promotional Offer", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/ms-azr-0089p" },
        new AzureOffer {Id = "MS-AZR-0120P", Name = "Azure Pass", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/azure-pass/" },
        new AzureOffer {Id = "MS-AZR-0121P", Name = "Azure Pass", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/azure-pass/" },
        new AzureOffer {Id = "MS-AZR-0122P", Name = "Azure Pass", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/azure-pass/" },
        new AzureOffer {Id = "MS-AZR-0123P", Name = "Azure Pass", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/azure-pass/" },
        new AzureOffer {Id = "MS-AZR-0124P", Name = "Azure Pass", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/azure-pass/" },
        new AzureOffer {Id = "MS-AZR-0125P", Name = "Azure Pass", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/azure-pass/" },
        new AzureOffer {Id = "MS-AZR-0126P", Name = "Azure Pass", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/azure-pass/" },
        new AzureOffer {Id = "MS-AZR-0127P", Name = "Azure Pass", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/azure-pass/" },
        new AzureOffer {Id = "MS-AZR-0128P", Name = "Azure Pass", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/azure-pass/" },
        new AzureOffer {Id = "MS-AZR-0129P", Name = "Azure Pass", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/azure-pass/" },
        new AzureOffer {Id = "MS-AZR-0130P", Name = "Azure Pass", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/azure-pass/" },
        new AzureOffer {Id = "MS-AZR-0111p", Name = "Azure in Open Licensing", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0111p" },
        new AzureOffer {Id = "MS-AZR-0026P", Name = "12-Month Commitment Offer", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0026P" },
        new AzureOffer {Id = "MS-AZR-0144P", Name = "DreamSpark", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0144P" },
        new AzureOffer {Id = "MS-AZR-0149P", Name = "BizSpark Plus", Retired = false, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0149P" },
        new AzureOffer {Id = "MS-AZR-0005P", Name = "Azure MSDN Premium", Retired = true, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0005P" },
        new AzureOffer {Id = "MS-AZR-0010P", Name = "Azure MSDN – Visual Studio", Retired = true, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0010P" },
        new AzureOffer {Id = "MS-AZR-0011P", Name = "Azure MSDN – Visual Studio Premium", Retired = true, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0011P" },
        new AzureOffer {Id = "MS-AZR-0012P", Name = "Azure MSDN – Visual Studio Ultimate", Retired = true, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0012P" },
        new AzureOffer {Id = "MS-AZR-0027P", Name = "MPN Silver Cloud Platform Competency", Retired = true, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0027P" },
        new AzureOffer {Id = "MS-AZR-0028P", Name = "MPN Gold Cloud Platform Competency", Retired = true, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0028P" },
        new AzureOffer {Id = "MS-AZR-0034P", Name = "BizSpark Plus", Retired = true, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0034P" },
        new AzureOffer {Id = "MS-AZR-0037P", Name = "6-Month Plan", Retired = true, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0037P" },
        new AzureOffer {Id = "MS-AZR-0038P", Name = "6-Month Plan (Prepaid)", Retired = true, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0038P" },
        new AzureOffer {Id = "MS-AZR-0039P", Name = "12-Month Plan", Retired = true, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0039P" },
        new AzureOffer {Id = "MS-AZR-0040P", Name = "12-Month Plan (Prepaid)", Retired = true, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0040P" },
        new AzureOffer {Id = "MS-AZR-0035P", Name = "MPN Action Pack", Retired = true, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0035P" },
        new AzureOffer {Id = "MS-AZR-0061P", Name = "Visual Studio Premium with MSDN (benefit)", Retired = true, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0061P" },
        new AzureOffer {Id = "MS-AZR-0090P", Name = "Backup Storage for Windows Server", Retired = true, Url = "https://azure.microsoft.com/en-us/offers/MS-AZR-0090P" }
      };
    }
  }
}