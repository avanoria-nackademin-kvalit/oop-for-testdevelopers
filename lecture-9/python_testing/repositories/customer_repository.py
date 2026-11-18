from models.customer import Customer

class CustomerRepository:
    def __init__(self):
        self.__customers: list[Customer] = []

    def get_all(self) -> list[Customer]:
        return self.__customers.copy()    

    def add(self, customer: Customer) -> None:
        if customer:
            self.__customers.append(customer)
