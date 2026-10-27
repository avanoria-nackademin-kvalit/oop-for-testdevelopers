from models.product import Product

class ProductService:
    def __init__(self):
        self.products: list[Product] = []

    def add_product(self, product: Product):
        self.products.append(product)

    def get_products(self) -> list[Product]:
        return self.products.copy()

