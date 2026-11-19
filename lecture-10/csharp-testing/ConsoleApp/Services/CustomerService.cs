using ConsoleApp.Models;
using ConsoleApp.Repositories;

namespace ConsoleApp.Services;

public class CustomerService(ICustomerRepository repository) : ICustomerService
{
    public CreateCustomerResult CreateCustomer(CreateCustomerDto dto)
    {
        // Normalisera
        var firstName = dto.FirstName.Trim();
        var lastName = dto.LastName.Trim();
        var email = dto.Email.Trim().ToLowerInvariant();

        // Validera
        if (string.IsNullOrWhiteSpace(firstName))
            return new CreateCustomerResult(false, "First name is required", null);

        if (string.IsNullOrWhiteSpace(lastName))
            return new CreateCustomerResult(false, "Last name is required", null);

        if (string.IsNullOrWhiteSpace(email))
            return new CreateCustomerResult(false, "Email is required", null);

        // Skapa + Delegera
        var customer = new Customer
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email
        };

        var createdCustomer = repository.Add(customer); 

        // Verifiera
        if (createdCustomer is null)
            return new CreateCustomerResult(false, "Unable to create customer", null);

        // Retunera
        return new CreateCustomerResult(true, null, customer);
    }

    public GetCustomerResult GetCustomers()
    {
        var customers = repository.GetAll();
        return new GetCustomerResult(true, null, customers);
    }
}
