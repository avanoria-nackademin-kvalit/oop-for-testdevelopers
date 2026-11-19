namespace ConsoleApp.Models;

public record GetCustomerResult
(
    bool Succeeded,
    string? ErrorMessage = null,
    IReadOnlyList<Customer>? Customers = null
);