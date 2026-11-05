package se.avanoria.javaapp.models;

public class Customer {
    private String customerName;
    private String organizationNumber;
    private String emailAddress;

    public Customer(String customerName, String organizationNumber, String emailAddress) {
        this.customerName = customerName;
        this.organizationNumber = customerName;
        this.emailAddress = emailAddress;
    }

    public String getCustomerName() {
        return customerName;
    }

    public String getOrganizationNumber() {
        return organizationNumber;
    }

    public String getEmailAddress() {
        return emailAddress;
    }
}
