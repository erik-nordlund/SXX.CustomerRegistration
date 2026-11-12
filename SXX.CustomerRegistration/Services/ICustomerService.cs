
using SXX.CustomerRegistration.Models;

namespace SXX.CustomerRegistration.Services;

public interface ICustomerService
{
    Customer CreateCustomer(
        string customerName,
        string email,
        string phone,
        bool isCompany,
        string? companyName,
        string? orgNumber
    );
}
