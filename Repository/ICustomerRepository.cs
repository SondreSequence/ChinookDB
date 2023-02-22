using SuperheroesDb_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroesDb_Project.Repository
{
    public interface ICustomerRepository
    {
        public Customer GetCustomer(int id);
        public List<Customer> GetAllCustomers();
        public string GetCustomersByCountry();
        public string GetCustomersByHighestSpent();

        public bool AddNewCustomer(Customer customer);
        public bool UpdateCustomer(int ID, Customer customer);
        public bool DeleteCustomer(Customer customer);
        public Customer GetCustomer(string name);
        public List<Customer> SelectCustomerPage(int limit, int offset);
    }
}
