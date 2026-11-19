using ConsoleApp.Models;
using ConsoleApp.Repositories;

namespace ConsoleApp.Services;

public class CustomerService(ICustomerRepository repository) : ICustomerService
{
    public string? NormalizeName(string? value)
    {
        return value?.Trim();
    }

    public string? NormalizeEmail(string? value)
    {
        return value?.Trim().ToLowerInvariant();
    }


    public CreateCustomerResult CreateCustomer(CreateCustomerDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        // Normalisera
        var firstName = NormalizeName(dto.FirstName);
        var lastName = NormalizeName(dto.LastName);
        var email = NormalizeEmail(dto.Email);

        // Validera
        if (string.IsNullOrWhiteSpace(firstName))
            return new CreateCustomerResult(false, "First name is required", null);

        if (string.IsNullOrWhiteSpace(lastName))
            return new CreateCustomerResult(false, "Last name is required", null);

        if (string.IsNullOrWhiteSpace(email))
            return new CreateCustomerResult(false, "Email address is required", null);

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
