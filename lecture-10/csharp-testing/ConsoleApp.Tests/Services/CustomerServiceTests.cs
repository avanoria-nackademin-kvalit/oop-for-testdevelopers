using ConsoleApp.Models;
using ConsoleApp.Repositories;
using ConsoleApp.Services;
using NSubstitute;

namespace ConsoleApp.Tests.Services;

public class CustomerServiceTests
{
    private readonly ICustomerRepository _repository = Substitute.For<ICustomerRepository>();
    private readonly CustomerService _service;

    public CustomerServiceTests()
    {
        _service = new CustomerService(_repository);
    }



    [Fact]
    public void GetCustomers__Should_ReturnSuccessfulWithEmptyList_WhenNoCustomersIsAdded()
    {
        // Arrange
        _repository.GetAll().Returns([]);

        // Act
        var result = _service.GetCustomers();

        // Assert
        Assert.True(result.Succeeded);
        Assert.Null(result.ErrorMessage);
        Assert.NotNull(result.Customers);
        Assert.Empty(result.Customers);
    }


    [Fact]
    public void GetCustomers__Should_ReturnSuccessfulWithCustomers_WhenCustomersExists()
    {
        // Arrange
        var customer = new Customer
        {
            FirstName = "Hans",
            LastName = "Mattin-Lassei",
            Email = "hans@domain.com"
        };

        _repository.GetAll().Returns([customer]);


        // Act
        var result = _service.GetCustomers();

        //Assert
        Assert.True(result.Succeeded);
        Assert.Null(result.ErrorMessage);
        Assert.NotNull(result.Customers);
        Assert.Same(customer, Assert.Single(result.Customers));
    }


    [Fact]
    public void CreateCustomer__Should_ReturnFailureWithErrorMessage_WhenCustomerIsNull()
    {
        // Arrange
        var dto = new CreateCustomerDto("Hans", "Mattin-Lassei", "hans@domain.com");
        _repository.Add(Arg.Any<Customer>()).Returns((Customer?)null);

        // Act
        var result = _service.CreateCustomer(dto);

        // Assert
        Assert.False(result.Succeeded);
        Assert.Equal("Unable to create customer", result.ErrorMessage);
        Assert.Null(result.Customer);
        _repository.Received(1).Add(Arg.Any<Customer>());
    }

    [Theory]
    [InlineData(null, "Mattin-Lassei", "hans@example.com", "First name is required")]
    [InlineData("   ", "Mattin-Lassei", "hans@example.com", "First name is required")]
    [InlineData("", "Mattin-Lassei", "hans@example.com", "First name is required")]
    [InlineData("Hans", null, "hans@example.com", "Last name is required")]
    [InlineData("Hans", "   ", "hans@example.com", "Last name is required")]
    [InlineData("Hans", "", "hans@example.com", "Last name is required")]
    [InlineData("Hans", "Mattin-Lassei", null, "Email address is required")]
    [InlineData("Hans", "Mattin-Lassei", "   ", "Email address is required")]
    [InlineData("Hans", "Mattin-Lassei", "", "Email address is required")]
    public void CreateCustomer__Should_WhenRequiredFieldIsMissing_DoesNotSaveCustomer(string? firstName, string? lastName, string? email, string expectedError)
    {
        // Arrange
        var dto = new CreateCustomerDto(firstName!, lastName!, email!);

        // Act
        var result = _service.CreateCustomer(dto);

        // Assert
        Assert.False(result.Succeeded);
        Assert.Equal(expectedError, result.ErrorMessage);
        Assert.Null(result.Customer);
        _repository.DidNotReceive().Add(Arg.Any<Customer>());
    }


    [Fact]
    public void NormalizeName__Should_ReturnNormalizedValue()
    {
        // Arrange
        var name = " Hans ";

        // Act
        var normalizedName = _service.NormalizeName(name);

        // Assert
        Assert.Equal("Hans", normalizedName);
    }

    [Fact]
    public void NormalizeEmail__Should_ReturnNormalizedEmail()
    {
        // Arrange
        var email = " HANS@Domain.Com ";

        // Act
        var normalizedEmail = _service.NormalizeEmail(email);

        // Assert
        Assert.Equal("hans@domain.com", normalizedEmail);
    }
}
