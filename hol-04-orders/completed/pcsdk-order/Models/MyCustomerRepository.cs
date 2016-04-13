using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Store.PartnerCenter.Models;
using Microsoft.Store.PartnerCenter.Models.Customers;
using pcsdk_order.Utilities;

namespace pcsdk_order.Models {
  public class MyCustomerRepository {
    public static async Task<List<MyCustomer>> GetCustomers() {
      var partner = await PcAuthHelper.GetPartnerCenterOps();

      // get list of customers from PC
      var pcCustomers = partner.Customers.Get();
      // convert customers to local model
      var customers = new List<MyCustomer>();
      foreach (var pcCustomer in pcCustomers.Items) {
        var customer = ConvertCustomer(pcCustomer);
        customers.Add(customer);
      }

      return customers.ToList();
    }
    public static async Task<MyCustomer> GetCustomer(string customerId) {
      var partner = await PcAuthHelper.GetPartnerCenterOps();

      // get customer from PC & convert to local model
      var pcCustomer = await partner.Customers.ById(customerId).GetAsync();
      var customer = ConvertCustomer(pcCustomer);

      return customer;
    }

    private static MyCustomer ConvertCustomer(Customer pcCustomer) {
      var customer = new MyCustomer {
        Id = pcCustomer.Id,
        TenantId = pcCustomer.CompanyProfile.TenantId,
        Domain = pcCustomer.CompanyProfile.Domain,
        CompanyName = pcCustomer.CompanyProfile.CompanyName
      };

      // if billing profile specified...
      if (pcCustomer.BillingProfile != null) {
        customer.BillingProfile = new MyBillingProfile {
          Id = pcCustomer.BillingProfile.Id,
          CompanyName = pcCustomer.BillingProfile.CompanyName,
          FirstName = pcCustomer.BillingProfile.FirstName,
          LastName = pcCustomer.BillingProfile.LastName,
          Email = pcCustomer.BillingProfile.Email,
          Culture = pcCustomer.BillingProfile.Culture,
          Language = pcCustomer.BillingProfile.Language,
          Address = new MyAddress {
            FirstName = pcCustomer.BillingProfile.DefaultAddress.FirstName,
            LastName = pcCustomer.BillingProfile.DefaultAddress.LastName,
            PhoneNumber = pcCustomer.BillingProfile.DefaultAddress.PhoneNumber,
            Address1 = pcCustomer.BillingProfile.DefaultAddress.AddressLine1,
            Address2 = pcCustomer.BillingProfile.DefaultAddress.AddressLine2,
            City = pcCustomer.BillingProfile.DefaultAddress.City,
            State = pcCustomer.BillingProfile.DefaultAddress.State,
            PostalCode = pcCustomer.BillingProfile.DefaultAddress.PostalCode,
            Region = pcCustomer.BillingProfile.DefaultAddress.Region,
            Country = pcCustomer.BillingProfile.DefaultAddress.Country
          }
        };
      }

      return customer;
    }

    private static Customer ConvertCustomer(MyCustomer myCustomer) {
      var customer = new Customer {
        Id = myCustomer.Id,
        CompanyProfile = new CustomerCompanyProfile {
          TenantId = myCustomer.TenantId,
          CompanyName = myCustomer.CompanyName,
          Domain = myCustomer.Domain
        },
        BillingProfile = new CustomerBillingProfile {
          Id = myCustomer.BillingProfile.Id,
          CompanyName = myCustomer.BillingProfile.CompanyName,
          FirstName = myCustomer.BillingProfile.FirstName,
          LastName = myCustomer.BillingProfile.LastName,
          Email = myCustomer.BillingProfile.Email,
          Culture = myCustomer.BillingProfile.Culture,
          Language = myCustomer.BillingProfile.Language,
          DefaultAddress = new Address {
            FirstName = myCustomer.BillingProfile.FirstName,
            LastName = myCustomer.BillingProfile.LastName,
            PhoneNumber = myCustomer.BillingProfile.Address.PhoneNumber,
            AddressLine1 = myCustomer.BillingProfile.Address.Address1,
            AddressLine2 = myCustomer.BillingProfile.Address.Address2,
            City = myCustomer.BillingProfile.Address.City,
            State = myCustomer.BillingProfile.Address.State,
            PostalCode = myCustomer.BillingProfile.Address.PostalCode,
            Region = myCustomer.BillingProfile.Address.Region,
            Country = myCustomer.BillingProfile.Address.Country
          }
        }
      };

      return customer;
    }
  }
}