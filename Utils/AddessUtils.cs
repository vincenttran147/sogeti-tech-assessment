using Models;

namespace Utils
{
    public static class AddressUtils
    {
        public static bool CompareAddess(Address address1, Address address2)
        {
            return address1.streetAddess == address2.streetAddess &&
                address1.city == address2.city &&
                address1.state == address2.state &&
                address1.postalCode == address2.postalCode;
        }
    }
}