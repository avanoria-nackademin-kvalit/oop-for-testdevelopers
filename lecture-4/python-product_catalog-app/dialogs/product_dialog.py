from utils.console_helper import clear_screen, pause, required_input
from models.product import Product
from services.product_service import ProductService

class ProductDialog:
    def __init__(self, product_service: ProductService):
        self.product_service: ProductService = product_service

    def add_product(self):
        clear_screen()
        print("#### NEW PRODUCT - PRODUCT MANAGEMENT ####")
        print("To create a new product enter following information\n")

        product = Product()
        product.name = required_input("Name")
        product.price = required_input("Price")

        result = self.product_service.add_product(product)

        print(result.message)
        pause()


    def list_products(self):
        clear_screen()
        print("#### PRODUCT LIST - PRODUCT MANAGEMENT ####")

        products = self.product_service.get_products()

        for product in products:
            print(f"ID: {product.id}")
            print(f"Name: {product.name}")
            print(f"Price: {product.price} SEK")
            print(f"")  
        pause()


    def show_menu(self):
        while True:
            clear_screen()

            print("#### PRODUCT MANAGEMENT ####")
            print("1. Add Product")
            print("2. List Products")
            print("3. Find Product")
            print("4. Update Product")
            print("5. Delete Product")
            print("0. Back")

            option = input("Choose an option: ").strip()

            match option:
                case "1":
                    self.add_product()
                case "2":
                    self.list_products()
                case "3":
                    return
                case "4":
                    return
                case "5":
                    return
                case "0":
                    return
                case _:
                    print("Invalid option, try again!")
                    pause()

                
                        

    