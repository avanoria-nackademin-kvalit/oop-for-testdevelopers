from dialogs.product_menu_dialog import ProductMenuDialog

def main():
    product_menu_dialog = ProductMenuDialog()

    product_menu_dialog.add_product_menu()

    product_menu_dialog.list_products_menu()


if __name__ == "__main__":
    main()