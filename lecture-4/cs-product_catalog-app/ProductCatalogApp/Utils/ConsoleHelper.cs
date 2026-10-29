namespace ProductCatalogApp.Utils;

public static class ConsoleHelper
{
    public static void ClearScreen()
    {
        Console.Clear();
    }

    public static void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    public static string RequiredInput(string prompt)
    {
        while(true)
        {
            Console.Write($"{prompt}: ");
            var value = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(value))
                return value;

            Console.WriteLine("This field is required. Try again.\n");
        }
    }
}
