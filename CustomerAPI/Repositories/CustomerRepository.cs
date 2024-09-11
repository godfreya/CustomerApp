using CustomerAPI.Models;

namespace CustomerAPI.Repositories
{
    public interface ICustomerRepository
    {
        Customer? GetCustomerById(int id);

        IEnumerable<Customer> GetAll();

        Customer CreateCustomer(Customer customer);

        void Update(Customer customer);

        void Delete(int id);
    }

    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        
        public CustomerRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public Customer? GetCustomerById(int id)
        {
            return _context.Customers.Find(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        public void Update(Customer customer)
        {
            var currentCustomer = GetCustomerById(customer.Id);

            currentCustomer.Name = customer.Name;
            currentCustomer.Email = customer.Email;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var customer = _context.Customers.Find(id);

            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }

            _context.SaveChanges();
        }
    }
}
