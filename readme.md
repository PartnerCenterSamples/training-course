# CSP - Partner Center SDK Developer Course

This course is for Microsoft partners who are in the **[Cloud Solution Provider (CSP)](https://mspartner.microsoft.com/en/us/pages/solutions/cloud-reseller-overview.aspx)** program and who are interested in the **Partner Center SDK**, including both the managed API and REST API. This includes partners who have been using the initial CREST API.

The course consists of multiple lectures and demos that are roughly 45-60 minutes in duration, each comprised of a module. It also includes a number of self-paced hands-on-labs for course participants.

Pre-requisites for the course are that the viewer already has experience as a developer, and they should have prior familiarity with the REST protocol. During the training a viewer will learn about using the Partner Center SDK for a variety of scenarios such that they can implement integration of sales and billing systems for a Microsoft Cloud Solution Provider partner.

## Modules - Lectures & Demos

> The modules in this course have been recorded and are available in the **[Cloud Solution Provider Developers](https://channel9.msdn.com/Series/cspdev)** series on Channel9.

1. **[Introductory System Concepts and Getting Started with the Partner Center SDK](mod-01-overview)**

  This module provides an overview for the course. We will talk about key concepts and the technical actors involved in the Partner Center SDK. It includes a brief overview of Azure AD tenants, and of how CREST API users can work with the Partner Center SDK. It also covers the basics of the object model in the Partner Center SDK.

1. **[Authentication for Partner Center SDK](mod-02-azuread)**

  This module describes how the Partner Center SDK uses Azure AD directories. It includes how to manage the partner tenant with an Azure subscription. It also goes into detail of how to authenticate from code to that tenant using the App+User and the App-Only models.

1. **[Understanding how Partner Center SDK works with CREST API](mod-03-api-ops)**

  This module describes how to use the Partner Center SDK with existing code that uses the CREST API. It will talk about the new features available in the Partner Center SDK that are not available in CREST. It will teach how to use Partner Center REST API calls in the same application as CREST API calls and how to manage authentication. And it will show demos of working in a console application that calls CREST and the Partner Center REST APIs.

1. **[REST and JSON Primer & Debugging API Calls](mod-04-rest)**

  This module describes REST and JSON since those are the protocols that the Partner Center SDK uses to communicate with Microsoft. Whether you are programming at the REST layer or using the Partner Center SDK, it’s really valuable to be able to see what's happening on the wire. This module covers these core protocols and also shows how to code against the REST APIs and how to debug with them.

1. **[Getting Started with the Sample Code](mod-05-samplecode)**

  This module shows how to obtain and compile and use the three sample applications. It shows the CREST sample code. It shows the Partner Center SDK sample console application. And it shows the Partner Center SDK sample web application.

1. **[Managing Customers](mod-06-customers)**

  This module walks through various scenarios for working with customer records in the Partner Center SDK. This includes getting a partner's customers, creating customers, deleting customers, getting a customer profile, managing customers, and getting a customer subscriptions and orders. It also discusses some common issues with creating customer records.

1. **[Office 365 Subscriptions](mod-07-o365)**

  This module walks through scenarios in the Partner Center SDK related to Offers, Add-Ons, Subscriptions, and Orders. It shows how to work with each of those data types in the Partner Center SDK and discusses common issues encountered when creating orders including address validation and MPN ID validation.

1. **[Managing Invoices](mod-08-invoices)**

  This module goes into detail about access to a partners invoices using the Partner Center SDK. It shows how to download invoices and how to access and read invoice line items which were previously known as the reconciliation file. Each type of line item is described.

1. **[Microsoft Azure - Managing Users & Resources with Azure Resource Manager](mod-09-azure)**

  This module provides an overview of Azure subscriptions from the Partner Center SDK. It shows how to create Azure subscriptions in the Partner Center SDK, and also how to add users to those subscriptions. It also shows how to use Azure Resource Manager to add Azure resources to the subscription.

1. **[Managing Support Tickets](mod-10-support)**

  This module provides an overview of a partners access to both partner and customer service requests through the Partner Center SDK. This includes searching and updating service requests. It also shows how to create service requests through the SDK.

1. **[Admin on Behalf of (AOBO)](mod-11-aobo)**

  Admin on behalf of (AOBO) is where an application created by the partner and registered in the Partner’s Azure AD tenant that can perform administrative tasks on the customer’s Azure AD tenant on behalf of the customer. For Office 365 this simply means that the partner can log in as themselves and have administrative access to their customers Office 365 tenant. This module describes how this works for Office 365 and for Microsoft Azure.

1. **[Office Subscription Transitions](mod-12-o365transition)**

  This module talks about how an Office 365 customer can transition their subscription to a new Office 365 offer. It shows you how to use the Partner Center SDK to list the available subscription offers that a customer can move to, and how to submit the request.

1. **[Reviewing Azure Usage Information](mod-13-usage)**

  This module describes the new Rated Usage feature available in the Partner Center SDK. It shows how to utilize the new customer spending budget which provides an email notification to the partner. It describes working with the usage summary, setting the usage budget, and accessing information about the usage detail.

1. **[Azure Resource Pricing with the Azure Billing API](mod-14-azratecard)**

  In this module you will learn how to use the RateCard API, one of the two endpoints in the Azure Billing API. This API allows developers to get access to all pricing information for all Azure resources, including the detailed tiered pricing. While the Azure Billing REST API is not part of the Partner Center SDK, just like the Azure Resource Manager (ARM) APIs covered in another module, this is an important API that you should be aware of for use in your applications.

1. **[Azure Usage Details with the Azure Billing API](mod-15-azusage)**

  The Partner Center SDK offers the ability to see Azure usage (*aka: consumption*) details for the current billing period using the Rated Usage endpoint. This endpoint in the Partner Center SDK addresses the majority of the commerce related needs for partners and spares them from having to call another API. In the cases where more detailed consumption data is required, the Usage API should be considered. The Usage API is one of the two endpoints in the Azure Billing API and can be used to look at all consumption data for a given Azure subscription, not just the current billing period, as well as get details on the specific resource in question. While the Azure Billing REST API is not part of the Partner Center SDK, just like the Azure Resource Manager (ARM) APIs covered in another module, this is an important API that you should be aware of for use in your applications.

## Hands-On Labs

*The hands-on labs in this course have a few prerequisites what you will need in order to complete the exercises. These prerequisites are detailed in [Hands-On Lab Prerequisites](hol-prereqs.md).*

The labs are written for developers using the .NET Framework in C# using Visual Studio 2015 with Update 1 on Windows 10.

1. **[Introduction to the Partner Center SDK](hol-01-intro-pcsdk)**
1. **[Using the Partner Center SDK with an Existing CREST API Based Application](hol-02-pcapi-crest)**
1. **[Implementing Parameter Validation for Managing Customers](hol-03-validation)**
1. **[Avoiding Common Order Submission Issues](hol-04-orders)**
1. **[Adding Resources to a new Azure Subscription](hol-05-arm)**

## Revision History

| Date | Comment |
| ----: | ------- |
| June 10, 2016 | Added modules 14 & 15 on Azure Billing REST API. |
| May 31, 2016 | Update module 13 with UX from Partner Center dashboard for Azure spending limit. |
| April 27, 2016 | Added HOL #5. |
| April 19, 2016 | Added HOL #4. |
| April 18, 2016 | Typo fix in HOL#1 for Partner Center SDK endpoint. |
| April 14, 2016 | Add HOL #3 & module recording links |
| March 17, 2016 | Added HOL #1, #2. |
| March 15, 2016 | Initial version. |
