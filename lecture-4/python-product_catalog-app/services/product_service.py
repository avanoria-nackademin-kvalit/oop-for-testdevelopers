from models.product import Product
from models.product_result import ProductResult

class ProductService:
    def __init__(self):
        self.products: list[Product] = []

    def add_product(self, product: Product) -> ProductResult:
        if not product.id:
            return ProductResult(False, "Product id is required.", None)
        
        if not product.name:
            return ProductResult(False, "Product name is required.", None)

        if not product.price:
            return ProductResult(False, "Product price is required.", None)
        
        self.products.append(product)

        return ProductResult(True, f"Product with id '{product.id}' added successfully.", product)


    def get_products(self) -> list[Product]:
        return self.products.copy()