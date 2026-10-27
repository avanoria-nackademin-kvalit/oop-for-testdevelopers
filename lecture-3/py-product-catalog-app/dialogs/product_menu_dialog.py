from models.product import Product
from services.product_service import ProductService

class ProductMenuDialog:

    def add_product_menu(self):
        print("")
        print("### ADD PRODUCT ###")

        service = ProductService()

        product = Product()

        product.name = input("Product Name: ")
        product.price = input("Product Price (SEK): ")

        service.add_product(product)
        print(f"Product with id '{product.id}' was added.")

    
    def list_products_menu(self):
        print("")
        print("### PRODUCT LIST ###")

        service = ProductService()
        products = service.get_products()

        for product in products:
            print(f"{product.name} - {product.price} SEK")
