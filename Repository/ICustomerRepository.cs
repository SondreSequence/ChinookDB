using SuperheroesDb_Project.Models;

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
        
        public string GetCustomerFavoriteGenre(int id);
    }
}
