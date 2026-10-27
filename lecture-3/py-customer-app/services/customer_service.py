from models.customer import Customer

class CustomerService:
    def __init__(self):
        self.customers: list[Customer] = []

    def add_customer(self, first_name: str, last_name: str, email: str) -> Customer:
        
        first_name = first_name.strip()
        last_name = last_name.strip()
        email = email.strip()

        if not first_name:
            raise ValueError("Förnamn måste anges.")

        if not last_name:
            raise ValueError("Efternamn måste anges.")

        if not email:
            raise ValueError("E-postadress måste anges.")

        customer = Customer(first_name, last_name, email)

        self.customers.append(customer)

        return customer