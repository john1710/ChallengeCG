using API.Data;

namespace API.Interfaces.Services
{
    public interface IAddressService
    {
        Task<AddressViewModel> GetAddressByCep(string cep);
    }
}
