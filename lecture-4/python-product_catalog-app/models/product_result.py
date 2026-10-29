from models.product import Product

class ProductResult:
    def __init__(self, succeeded: bool, message: str, product: Product):
        self.succeeded: bool = succeeded
        self.message: str = message
        self.product: Product = product