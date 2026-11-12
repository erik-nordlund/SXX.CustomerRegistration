
using SXX.CustomerRegistration.Models;
using SXX.CustomerRegistration.Repositories;

namespace SXX.CustomerRegistration.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public Customer CreateCustomer(
        string customerName,
        string email,
        string phone,
        bool isCompany,
        string? companyName,
        string? orgNumber)
    {
        var customer = new Customer
        {
            CustomerName = customerName.Trim(),
            Email = email.Trim(),
            PhoneNumber = phone.Trim(),
            IsCompany = isCompany,
            CompanyName = isCompany ? companyName?.Trim() : null,
            OrganizationNumber = isCompany ? orgNumber?.Trim() : null
        };

        customer.ValidateCustomer();

        if (customer.IsCompany)
        {
            bool exists = _customerRepository
                .ExistsByOrganizationNumber(
                    customer.OrganizationNumber!);

            if (exists)
            {
                throw new InvalidOperationException(
                    "Organisationsnumret finns redan registrerat.");
            }
        }

        _customerRepository.Add(customer);

        return customer;
    }
}
