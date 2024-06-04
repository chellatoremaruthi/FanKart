using FanKart.FanKartDbModels;

namespace FanKart.Services.Interfaces
{
    public interface IAddressService
    {
        public void AddAddress(Address address);
        public List<Address> GetAddresses(string userEmailId);
    }
}
