using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace p0
{
    class CustomerManager
    {
        private string iFirstName;
        private string iLastName;

        public CustomerManager(string firstName, string lastName)
        {
            this.iFirstName = firstName;
            this.iLastName = lastName;
        }

        public Customer find()
        {
            using (var bc = new BusinessContext())
            {
                return bc.Customers.Where(c => (c.firstName == iFirstName) && (c.lastName == iLastName)).FirstOrDefault();
            }            
        }

        public Customer build()
        {
            using (var bc = new BusinessContext())
            {
                Customer customer =  new Customer { CustomerId = Guid.NewGuid().ToString(), firstName = iFirstName, lastName = iLastName, orders = new List<Order>() };
                bc.Customers.Add(customer);
                bc.SaveChanges();
                return customer;
            }
        }

        // searches for records like first name && last name
        public void search()
        {
            var res = typeof(Customer).GetProperties().Select(property => property.Name).ToArray();
            foreach (string s in res)
            {
                Console.Write("{0}\t", s);
            }
            Console.WriteLine();
            List<Customer> list = getObjects(iFirstName, iLastName);
            foreach (Customer c in list)
            {
                Console.WriteLine(c.CustomerId);
            }
        }

        public List<Customer> getObjects(string firstName, string lastName)
        {
            using (var db = new BusinessContext())
            {
                var result = db.Customers.Where(c => c.firstName == firstName && c.lastName == lastName).ToList();
                return result;
            }
        }
    }
}
