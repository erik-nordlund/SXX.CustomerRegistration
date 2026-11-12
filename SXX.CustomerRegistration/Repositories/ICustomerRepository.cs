
using SXX.CustomerRegistration.Models;

namespace SXX.CustomerRegistration.Repositories;

public interface ICustomerRepository
{
    void Add(Customer customer);

    Customer? GetById(Guid id);

    List<Customer> GetAllCustomers();

    bool ExistsByOrganizationNumber(string orgNumber);
}
