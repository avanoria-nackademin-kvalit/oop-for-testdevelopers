package se.avanoria.javaapp.services;

import se.avanoria.javaapp.models.Customer;

import java.util.List;

public interface CustomerService {
    void addCustomer(Customer customer);
    List<Customer> getAllCustomers();
}
