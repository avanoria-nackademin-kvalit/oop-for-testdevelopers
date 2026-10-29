namespace ProductCatalogApp.Models;

public class Product
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Price { get; set; } = string.Empty;
}
