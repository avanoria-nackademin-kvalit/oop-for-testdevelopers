using ProductCatalogApp.Models;

namespace ProductCatalogApp.Services;

public class ProductService
{
    private List<Product> _products = [];

    public ProductResult AddProduct(Product product)
    {
        if (product.Id == Guid.Empty)
            return new ProductResult(false, "Product id is required", null);

        if (string.IsNullOrWhiteSpace(product.Name))
            return new ProductResult(false, "Product name is required", null);

        if (string.IsNullOrWhiteSpace(product.Price))
            return new ProductResult(false, "Product price is required", null);

        _products.Add(product);

        return new ProductResult(true, $"Product with id '{product.Id}'", product);
    }

    public List<Product> GetProducts()
    {
        return _products;
    }
}
