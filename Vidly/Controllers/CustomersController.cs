using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult All()
        {

            var customers = new List<Customer>(){
                new Customer { Id = 1, Name = "Paweł Kołodziejczyk" },
                new Customer() { Id = 2, Name = "Jan Kowalski" } };

            var customersViewModel = new CustomersViewModel() { Customers = customers };

            return View(customersViewModel);
        }

        public ActionResult Details(int? id)
        {
            var customers = new CustomersViewModel();

            if (id==1)
            {
                customers.Customers = new List<Customer>() {
                new Customer { Id = 1, Name = "Paweł Kołodziejczyk" } };
            }
            else if (id == 2)
            {
                customers.Customers = new List<Customer>() {
                new Customer { Id = 2, Name = "Jan Kowalski" } };
            }
            else
            {
                return new HttpNotFoundResult();
            }
            return View(customers);
        }
    }
}