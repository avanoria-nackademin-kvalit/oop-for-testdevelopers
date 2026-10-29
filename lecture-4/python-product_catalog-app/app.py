from utils.console_helper import clear_screen, pause
from dialogs.product_dialog import ProductDialog
from services.product_service import ProductService

def main():
    product_service = ProductService()
    product_dialog = ProductDialog(product_service)

    while True:
        clear_screen()

        print("#### MAIN MENU ####")
        print("1. Product Management")
        print("0. Exit")

        option = input("Choose an option: ").strip()

        match option:
            case "1":
                product_dialog.show_menu()

            case "0":
                return

            case _:
                print("Invalid option. Try again!")
                pause()

if __name__ == "__main__":
    main()