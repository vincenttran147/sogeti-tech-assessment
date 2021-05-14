using Models;

namespace Utils
{
    public static class CustomerUtils
    {
        public static bool CompareCustomer(Customer customer1, Customer customer2)
        {
            return customer1.firstName == customer2.firstName &&
                customer1.lastName == customer2.lastName &&
                AddressUtils.CompareAddress(customer1.address, customer2.address) &&
                customer1.phoneNumber == customer2.phoneNumber;
        }
    }
}