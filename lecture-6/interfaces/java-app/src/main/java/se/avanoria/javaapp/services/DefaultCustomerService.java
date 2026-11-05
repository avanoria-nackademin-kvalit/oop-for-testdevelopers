package se.avanoria.javaapp.services;

import se.avanoria.javaapp.models.Customer;

import java.util.List;

public class DefaultCustomerService implements  CustomerService {

    @Override
    public void addCustomer(Customer customer) {

    }

    @Override
    public List<Customer> getAllCustomers() {
        return List.of();
    }
}
