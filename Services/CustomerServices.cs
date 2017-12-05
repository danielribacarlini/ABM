using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess1;
using Services.Model;

namespace Services
{
    public class CustomerServices
    {
        private Repository<Customer> _customerRepository;

        public CustomerServices()
        {
            _customerRepository = new Repository<Customer>();
        }

        public List<Customer> GetAll()
        {
            
                var customers = _customerRepository.Set().Select(c=> new Customer
                {
                    CustomerID = c.CustomerID,
                    CompanyName = c.CompanyName,
                    ContactName = c.ContactName,
                    City = c.City
                }).ToList();
                return customers;
            
        }

        public Customer GetOne(string id)
        {
          
                var customers = _customerRepository.Set().FirstOrDefault(c => c.CustomerID == id);
                var customer = new Customer
                {
                    CustomerID = customers.CustomerID,
                    CompanyName = customers.CompanyName,
                    ContactName = customers.CompanyName,
                    City = customers.City
                };

                return customer;
                        
        }

        public void Update(Customer customerM)
        {
            
                var customers = _customerRepository.Set().FirstOrDefault(c => c.CustomerID == customerM.CustomerID);

                customers.CustomerID = customerM.CustomerID;
                customers.CompanyName = customerM.CompanyName;
                customers.ContactName = customerM.ContactName;
                customers.City = customerM.City;

                _customerRepository.SaveChanges();
        }

        

        public bool Delete(string id)
        {
            
                var customer = _customerRepository.Set().FirstOrDefault(c => c.CustomerID == id);

                if (customer == null)
                {
                    return false;
                }
                else
                {
                    if (context.Orders.Any(p => p.CustomerID == id))
                    {
                        return false;
                    }
                    else
                    {
                        context.Customers.Remove(customer);
                        context.SaveChanges();
                        return true;
                    }
                }
            
        }

        public void Save(Customer newCustomer)
        {
            using(var context = new Context())
            {
                var customer = new Customers
                {
                    CustomerID = newCustomer.CustomerID,
                    CompanyName = newCustomer.CompanyName,
                    ContactName = newCustomer.ContactName,
                    ContactTitle = "",
                    Address = "",
                    City = newCustomer.City,
                    Region = "",
                    PostalCode = "",
                    Country = "",
                    Phone = "",
                    Fax = ""

                };

                try
                {
                    context.Customers.Add(customer);
                    context.SaveChanges();
                  
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
    }
}
