# Module #15: Azure Usage REST API

The Partner Center SDK offers the ability to see Azure usage (*aka: consumption*) details for the current billing period using the Rated Usage endpoint. This endpoint in the Partner Center SDK addresses the majority of the commerce related needs for partners and spares them from having to call another API. In the cases where more detailed consumption data is required, the Usage API should be considered. The Usage API is one of the two endpoints in the Azure Billing API and can be used to look at all consumption data for a given Azure subscription, not just the current billing period, as well as get details on the specific resource in question. While the Azure Billing REST API is not part of the Partner Center SDK, just like the Azure Resource Manager (ARM) APIs covered in another module, this is an important API that you should be aware of for use in your applications.

[Get the presentation](mod-15-azusage.pptx)
