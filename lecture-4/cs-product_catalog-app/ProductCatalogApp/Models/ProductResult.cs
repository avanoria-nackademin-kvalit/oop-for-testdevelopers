namespace ProductCatalogApp.Models;

public record ProductResult
(
    bool Succeeded, 
    string Message, 
    Product? Product
);