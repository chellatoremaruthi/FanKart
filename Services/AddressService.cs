using FanKart.FanKartDbModels;
using FanKart.Services.Interfaces;

namespace FanKart.Services
{
    public class AddressService : IAddressService
    {
        private readonly FanKartContext _context;
        public AddressService(FanKartContext context)
        {
            _context = context;
        }
        public void AddAddress(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
        }

        public List<Address> GetAddresses(string userEmailId)
        {
            return _context.Addresses.Where(address => address.UserEmailId == userEmailId).ToList();   
        }
    }
}
