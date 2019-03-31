using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult New()
        {
            var memberShipTypes = _context.MemberShipTypes.ToList();
            var customerFormViewModel = new CustomerFormViewModel
            {
                MemberShipTypes = memberShipTypes
            };

            return View("CustomerForm", customerFormViewModel);
        }

        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MemberShipType).ToList();

            return View(customers);
        }  

        
        public ActionResult Details(int id)
        {
            var customer = _context.Customers
                .Include(c => c.MemberShipType)
                .SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var customerFormViewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MemberShipTypes = _context.MemberShipTypes.ToList()
            };

            return View("CustomerForm", customerFormViewModel);
        }
    }
}