from models.customer import Customer

class CustomerRepository:
    def __init__(self):
        self.__customers: list[Customer] = []

    def get_all(self) -> list[Customer]:
        return self.__customers.copy()    

    def add(self, customer: Customer) -> Customer:
        
        if customer:
            self.__customers.append(customer)
            return customer
        else:
            return None
        
