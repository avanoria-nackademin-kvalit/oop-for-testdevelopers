using ProductCatalogApp.Models;
using ProductCatalogApp.Services;
using ProductCatalogApp.Utils;

namespace ProductCatalogApp.Dialogs;

public class ProductDialog(ProductService productService)
{
    public void ShowMenu()
    {
        while (true)
        {
            ConsoleHelper.ClearScreen();

            Console.WriteLine("#### PRODUCT MANAGEMENT ####");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. List Products");
            Console.WriteLine("3. Find Product");
            Console.WriteLine("4. Update Product");
            Console.WriteLine("5. Delete Product");
            Console.WriteLine("0. Back");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddProduct();
                    break;

                case "2":
                    ListProducts();
                    break;

                case "3":
                    break;

                case "4":
                    break;

                case "5":
                    break;

                case "6":
                    return;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    ConsoleHelper.Pause();
                    break;
            }
        }
    }



    public void AddProduct()
    {
        ConsoleHelper.ClearScreen();

        Console.WriteLine("#### ADD PRODUCT - PRODUCT MANAGEMENT ####");

        var product = new Product();

        product.Name = ConsoleHelper.RequiredInput("Name");
        product.Price = ConsoleHelper.RequiredInput("Price");

        var result = productService.AddProduct(product);

        Console.WriteLine(result.Message);
        ConsoleHelper.Pause();
    }

    public void ListProducts()
    {
        ConsoleHelper.ClearScreen();

        Console.WriteLine("#### PRODUCT LIST - PRODUCT MANAGEMENT ####");

        var products = productService.GetProducts();

        foreach (var product in products)
        {
            Console.WriteLine($"ID: {product.Id}");
            Console.WriteLine($"Name: {product.Name}");
            Console.WriteLine($"Price: {product.Price}");
            Console.WriteLine("");
        }

        ConsoleHelper.Pause();
    }
}
