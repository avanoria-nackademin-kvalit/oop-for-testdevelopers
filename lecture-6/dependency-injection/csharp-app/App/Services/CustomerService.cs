using App.Models;
using App.Repositories;

namespace App.Services;

public class CustomerService(ICustomerRepository customerRepostiory) : ICustomerService
{
    public void AddCustomer(Customer customer)
    {
        customerRepostiory.TryAdd(customer);
    }

    public IReadOnlyList<Customer> GetAllCustomers()
    {
        return customerRepostiory.GetAll();
    }
}