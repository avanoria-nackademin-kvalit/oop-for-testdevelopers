using App.Dialogs;
using App.Repositories;
using App.Services;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddSingleton<ICustomerRepository, InMemoryCustomerRepository>();
services.AddSingleton<ICustomerService, CustomerService>();
services.AddTransient<CustomerDialog>();

using var serviceProvider = services.BuildServiceProvider();


var customerDialog =  serviceProvider.GetRequiredService<CustomerDialog>();
customerDialog.AddCustomerOption();
customerDialog.ShowCustomersOption();