from models.customer import Customer

class CustomerService:        

    def add_customer(self, customer: Customer) -> None:
        self._repository.try_add(customer)

    def get_all_customers(self) -> list[Customer]:
        return self._repository.get_all()