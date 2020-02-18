using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoClub.Dtos;
using VideoClub.Models;

namespace VideoClub.Controllers.Api
{
    public class CustomerController : ApiController
    {
        private ApplicationDbContext context;
        public CustomerController()
        {
            context = new ApplicationDbContext();
        }
        //GET /api/Customer
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        //GET /api/customer/1
        public CustomerDto GetCustomer(int id)
        {
            var customer = context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return  Mapper.Map<Customer, CustomerDto>(customer);
        }
        // POST /api/customer
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            context.Customers.Add(customer);
            context.SaveChanges();
            customerDto.Id = customer.Id;
            return customerDto;
        }
        // PUT /api/customer/1
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);

            }
            var customerInDB = context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map(customerDto, customerInDB);
            //customerInDB.Name = customer.Name;
            //customerInDB.Birthdate = customer.Birthdate;
            //customerInDB.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            //customerInDB.MembershipTypeId = customer.MembershipTypeId;

            context.SaveChanges();
        }

        // DELETE /api/customer/1
        public void DeleteCustomer(int id)
        {
            var customerInDB = context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            context.Customers.Remove(customerInDB);
            context.SaveChanges();
        }

    }
}
