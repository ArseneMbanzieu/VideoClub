using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using VideoClub.Models;
using VideoClub.ViewModels;

namespace VideoClub.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext context;
        public CustomerController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customers = context.Customers
                                    .Include(c => c.MembershipType)
                                    .ToList();


            return View(customers);
        }


        public ActionResult Details(int id)
        {
            var customer = context.Customers.Include(c => c.MembershipType)
                .SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        private List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer {Id = 1 ,Name = "Sergio Ramos"},
                new Customer { Id = 2, Name = "Gianluigi Buffon"},
                new Customer { Id = 3,Name = "Karim Benzema"}
            };

        }
        public new ActionResult New()
        {
            var membershiTypes = context.MembershipTypes
                                        .ToList();
            var viewmodel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershiTypes
            };
             

            return View("CustomerForm", viewmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = context.MembershipTypes.ToList()

                };
                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
            {
                context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = context.Customers.Single(c => c.Id == customer.Id);
                if (customerInDb != null)
                {
                    customerInDb.Name = customer.Name;
                    customerInDb.MembershipTypeId = customer.MembershipTypeId;
                    customerInDb.Birthdate = customer.Birthdate;
                    customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

                }
            }
            context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(int id)
        {
            var customerInDb = context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CustomerFormViewModel
            {
                Customer = customerInDb,
                MembershipTypes = context.MembershipTypes.ToList()

            };
            return View("CustomerForm", viewModel);
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
    }
}