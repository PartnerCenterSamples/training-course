using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace pcsdk_order.Models {
  public class MyCustomer {
    [ReadOnly(true)]
    public string Id { get; set; }

    [ReadOnly(true)]
    public string TenantId { get; set; }

    [Required]
    [DisplayName("Company Name")]
    public string CompanyName { get; set; }

    [Required]
    public string Domain { get; set; }

    public MyBillingProfile BillingProfile { get; set; }
  }

  public class MyAddress {
    [DisplayName("First Name")]
    public string FirstName { get; set; }

    [DisplayName("Last Name")]
    public string LastName { get; set; }

    [Required]
    [DisplayName("Address (line 1)")]
    public string Address1 { get; set; }

    [DisplayName("Address (line 2)")]
    public string Address2 { get; set; }

    [Required]
    public string City { get; set; }

    public string State { get; set; }

    [DisplayName("Postal Code")]
    public string PostalCode { get; set; }

    [Required]
    public string Country { get; set; }

    [DisplayName("Phone Number")]
    public string PhoneNumber { get; set; }

    public string Region { get; set; }
  }

  public class MyBillingProfile {
    public string Id { get; set; }
    [Required]
    [DisplayName("First Name")]
    public string FirstName { get; set; }

    [Required]
    [DisplayName("Last Name")]
    public string LastName { get; set; }

    public string Email { get; set; }

    [Required]
    [DisplayName("Company Name")]
    public string CompanyName { get; set; }

    public string Language { get; set; }
    public string Culture { get; set; }

    public MyAddress Address { get; set; }
  }
}