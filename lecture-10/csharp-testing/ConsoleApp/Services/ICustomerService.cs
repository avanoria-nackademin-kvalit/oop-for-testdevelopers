using ConsoleApp.Models;

namespace ConsoleApp.Services;

public interface ICustomerService
{
    CreateCustomerResult CreateCustomer(CreateCustomerDto dto);
    GetCustomerResult GetCustomers();
}