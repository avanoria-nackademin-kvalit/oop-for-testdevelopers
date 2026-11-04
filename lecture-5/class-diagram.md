@startuml
title Kundhanteringssystem

skinparam classAttributeIconSize 0

class Customer {
 +id : UUID
 +customerNumber : String
 +organizationNumber : String
}

class CustomerRegistrationDto {
 +organizationNumber : String
}

class CustomerDialog {
 -customerService : CustomerService
 +addCustomerMenu() : void
 +showCustomerListMenu() : void
}

class CustomerService {
 -customerRepository : CustomerRepository
 +registerCustomer(customerRegistrationDto : CustomerRegistrationDto) : RegistrationResult
}

class CustomerRepository {
 -customerList : Customer [0..*]
 +tryAdd(customer : Customer) : boolean
}

class RegistrationResult {
 +succeeded : boolean
 +message : String
 +customer : Customer [0..1]
}

CustomerDialog --> "1" CustomerService : använder
CustomerService --> "1" CustomerRepository : använder
CustomerRepository --> "0..*" Customer : lagrar

CustomerDialog ..> CustomerRegistrationDto : skapar
CustomerService ..> CustomerRegistrationDto : använder
CustomerService ..> Customer : skapar
CustomerService ..> RegistrationResult : skapar och returnerar
CustomerDialog ..> RegistrationResult : använder

RegistrationResult --> "0..1" Customer : customer

@enduml