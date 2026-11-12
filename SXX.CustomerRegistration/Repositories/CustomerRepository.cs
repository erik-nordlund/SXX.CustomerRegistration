
using SXX.CustomerRegistration.Models;

namespace SXX.CustomerRegistration.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly List<Customer> _customers = new();

    public void Add(Customer customer)
    {
        _customers.Add(customer);
    }

    public Customer? GetById(Guid id)
    {
        return _customers.FirstOrDefault(
            customer => customer.Id == id);
    }

    public List<Customer> GetAllCustomers()
    {
        return new List<Customer>(_customers);
    }

    public bool ExistsByOrganizationNumber(string orgNumber)
    {
        string normalizedNumber = NormalizeOrgNumber(orgNumber);

        return _customers.Any(customer =>
            customer.IsCompany &&
            customer.OrganizationNumber != null &&
            NormalizeOrgNumber(customer.OrganizationNumber)
                == normalizedNumber);
    }

    private static string NormalizeOrgNumber(string number)
    {
        return number.Trim().Replace("-", "").Replace(" ", "");
    }
}
