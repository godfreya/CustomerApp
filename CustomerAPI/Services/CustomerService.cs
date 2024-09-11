using CustomerAPI.Models;
using CustomerAPI.Repositories;

namespace CustomerAPI.Services
{
    public interface ICustomerService
    {
        Customer? GetCustomerById(int id);

        IEnumerable<Customer> GetAll();

        Customer CreateCustomer(Customer customer);

        void Update(Customer customer);

        void Delete(int id);
    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _repository = customerRepository;
        }

        public Customer? GetCustomerById(int id)
        {
            return _repository.GetCustomerById(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _repository.GetAll();
        }

        public Customer CreateCustomer(Customer customer)
        {
            return _repository.CreateCustomer(customer);
        }

        public void Update(Customer customer)
        {
            _repository.Update(customer);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
