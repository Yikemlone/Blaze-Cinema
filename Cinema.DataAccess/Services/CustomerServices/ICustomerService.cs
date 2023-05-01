using Cinema.Shared.DTO;

namespace Cinema.DataAccess.Services.CustomerServices
{
    public interface ICustomerService
    {
        public Task<List<CustomerDTO>> GetCustomersAsync();
        public Task<CustomerDTO> GetCustomerAsync(int customerID);
        public Task DeleteCustomerAsync(int customerID);
        public Task UpdateCustomerAsync(CustomerDTO customer);

    }
}
