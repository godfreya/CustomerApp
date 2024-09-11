using CustomerAPI.Models;
using Newtonsoft.Json;

namespace CustomerApp.Services
{
    public interface ICustomerService
    {
        Task<Customer?> GetCustomerById(int id);

        Task<IEnumerable<Customer>> GetCustomers();

        Task<Customer> CreateCustomer(Customer customer);

        Task<Customer> Update(Customer customer);

        Task<bool> Delete(int id);
    }

    public class CustomerService : ICustomerService
    {
        static readonly HttpClient client = new HttpClient();

        private readonly string _webApiBase;

        public CustomerService(IConfiguration configuration)
        {
            _webApiBase = configuration["WebAPI"];
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            using HttpResponseMessage response = await client.GetAsync(_webApiBase + "api/customer/" + id);
            
            string apiResponse = await response.Content.ReadAsStringAsync();
            var customer = JsonConvert.DeserializeObject<Customer>(apiResponse);

            return customer;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var customers = new List<Customer>();
            using (HttpResponseMessage response = await client.GetAsync(_webApiBase + "api/customers"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                customers = JsonConvert.DeserializeObject<List<Customer>>(apiResponse);
            }

            return customers;
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            using HttpResponseMessage response = await client.PostAsJsonAsync(_webApiBase + "api/customer", customer);
                
            string apiResponse = await response.Content.ReadAsStringAsync();
            var newCustomer = JsonConvert.DeserializeObject<Customer>(apiResponse);

            return newCustomer;
        }

        public async Task<Customer> Update(Customer customer)
        {
            using HttpResponseMessage response = await client.PutAsJsonAsync(_webApiBase + "api/customer", customer);

            string apiResponse = await response.Content.ReadAsStringAsync();
            var updatedCustomer = JsonConvert.DeserializeObject<Customer>(apiResponse);

            return updatedCustomer;
        }

        public async Task<bool> Delete(int id)
        {
            using HttpResponseMessage response = await client.DeleteAsync(_webApiBase + "api/customer/" + id);

            return response.IsSuccessStatusCode;
        }
    }
}
