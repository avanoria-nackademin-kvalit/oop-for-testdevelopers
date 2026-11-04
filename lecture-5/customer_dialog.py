
class CustomerDialog:
    def __init__(self, customer_service: CustomerService):
        self._customer_service: CustomerService = customer_service

    def show_title(self, title: str, ingress: str):
        print(f"#### {title} - CUSTOMER MANAGEMENT ####")
        print(f"{ingress}\n")
    
    def add_customer_menu(self):
        self.show_title("NEW CUSTOMER", "Follow the wizard to create a new customer")

        customer_registration_dto = CustomerRegistrationDto()

        customer_registration_dto.customer_name = input("Customer Name: ")
        customer_registration_dto.organization_number = input("Organization Number: ")
        customer_registration_dto.email = input("Email Address: ")
        
        registration_result = self._customer_service.register_customer(customer_registration_dto)

        print(registration_result.message)

    def list_customer_menu(self):
        self.show_title("CUSTOMER LIST", "This is the current customer list")