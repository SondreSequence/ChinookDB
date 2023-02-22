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
        public bool AddNewCustomer(int id);
        public bool UpdateCustomer(Customer customer);
        public bool DeleteCustomer(Customer customer);

    }
}
