namespace ConsoleApp.Models;

public record CreateCustomerResult
(
    bool Succeeded,
    string? ErrorMessage = null,
    Customer? Customer = null
);
