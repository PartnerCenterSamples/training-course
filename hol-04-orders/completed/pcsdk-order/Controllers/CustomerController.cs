using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using pcsdk_order.Models;

namespace pcsdk_order.Controllers {
  public class CustomerController : Controller {
    // GET: Customer
    public async Task<ActionResult> Index() {
      CustomerViewModel viewModel = new CustomerViewModel();
      viewModel.Customers = await MyCustomerRepository.GetCustomers();
      return View(viewModel);
    }

    // GET: Customer/Details/5
    public ActionResult Details(int id) {
      return View();
    }

    // GET: Customer/Create
    public ActionResult Create() {
      return View();
    }

    // POST: Customer/Create
    [HttpPost]
    public ActionResult Create(FormCollection collection) {
      try {
        // TODO: Add insert logic here

        return RedirectToAction("Index");
      } catch {
        return View();
      }
    }

    // GET: Customer/Edit/5
    public ActionResult Edit(int id) {
      return View();
    }

    // POST: Customer/Edit/5
    [HttpPost]
    public ActionResult Edit(int id, FormCollection collection) {
      try {
        // TODO: Add update logic here

        return RedirectToAction("Index");
      } catch {
        return View();
      }
    }

    // GET: Customer/Delete/5
    public ActionResult Delete(int id) {
      return View();
    }

    // POST: Customer/Delete/5
    [HttpPost]
    public ActionResult Delete(int id, FormCollection collection) {
      try {
        // TODO: Add delete logic here

        return RedirectToAction("Index");
      } catch {
        return View();
      }
    }
  }
}
