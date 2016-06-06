# Querying Azure Usage Information with the Azure Billing REST API

This demo shows how to get the detailed usage information on Azure resources using the Azure Billing REST API, specifically the Usage endpoint.

## Azure Billing Usage REST API

1. Show the following file for the authentication & setup process:
  - Explore `\Startup.cs` & `\App_Start\Startup.Auth.cs`
  - Explore `\Controllers\AccountController.cs`
1. Show the files used to auth with Azure REST API & show all Subscriptions
  - Explore `\Controllers\SubscriptionsController.cs`
  - Explore `\Models\AzureSubscriptionRepository.cs`
  - Explore `\Utilities\AadAuthHelper.cs`
1. Show the files used to query the Azure Billing REST API & show the results
  - Explore `\Controllers\UsageController.cs`
  - Explore `\Models\AzureUsageRepository.cs`
  - Explore `\Models\AzureUsageHttpResponse.cs`
  - Explore `\Views\Usage\Index.cshtml`

Open the [restapi-trace.saz](restapi-trace.saz) in Fiddler to look at a trace for the REST API call.