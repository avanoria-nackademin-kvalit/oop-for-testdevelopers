using ProductCatalogApp.Dialogs;
using ProductCatalogApp.Services;
using ProductCatalogApp.Utils;

var productService = new ProductService();
var productDialog = new ProductDialog(productService);


while (true) {

    ConsoleHelper.ClearScreen();

    Console.WriteLine("#### MAIN MENU ####");
    Console.WriteLine("1. Product Management");
    Console.WriteLine("0. Exit");

    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            productDialog.ShowMenu();
            break;
        
        case "0":
            return;

        default:
            Console.WriteLine("Invalid option. Try again.");
            ConsoleHelper.Pause();
            break;
    }
}

