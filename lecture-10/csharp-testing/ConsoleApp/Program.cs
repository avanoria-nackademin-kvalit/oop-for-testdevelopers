using ConsoleApp.Dialogs;
using ConsoleApp.Repositories;
using ConsoleApp.Services;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<ICustomerRepository, CustomerRepository>();
services.AddSingleton<ICustomerService, CustomerService>();
services.AddSingleton<CustomerDialog>();

var sp = services.BuildServiceProvider();

var dialog = sp.GetRequiredService<CustomerDialog>();
dialog.MainMenu();