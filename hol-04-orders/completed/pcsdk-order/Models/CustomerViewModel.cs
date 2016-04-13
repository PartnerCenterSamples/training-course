using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pcsdk_order.Models {
  public class CustomerViewModel {
    public List<MyCustomer> Customers { get; set; }

    public MyCustomer Customer { get; set; }

    public IEnumerable<SelectListItem> Countries { get; set; }

    public IEnumerable<string> ValidationErrors { get; set; }
    public CustomerViewModel() {
      ValidationErrors = new List<string>();
    }

    public CustomerViewModel(MyCustomer customer) {
      Customer = customer;
      ValidationErrors = new List<string>();
    }
  }
}