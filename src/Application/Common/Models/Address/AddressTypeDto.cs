using Domain.Enums;

namespace Application.Common.Models.Address;

public class AddressTypeDto
{
    public AddressType AddressType { get; set; }

    public static AddressType ConvertToAddressType(string AddressTypeName)
    {
        switch (AddressTypeName)
        {
            case "business": return AddressType.Business;
            
            case "home": return AddressType.Home;
            
            case "family": return AddressType.Family;
            
            case "friends": return AddressType.Friends;
            
            case "other": return AddressType.Other;
            
            default:
                throw new Exception("AccessType couldn't identified.");
        }
    }

    public static string ConvertToAddressTypeName(AddressType addressType)
    {
        switch (addressType)
        {
            case AddressType.Business: return new string("business");
            
            case AddressType.Home: return new string("home");
            
            case AddressType.Family: return new string("family");
            
            case AddressType.Friends: return new string("friends");
            
            case AddressType.Other: return new string("other");
            
            default:
                throw new Exception("AccessType couldn't identified.");

        }
    }
}