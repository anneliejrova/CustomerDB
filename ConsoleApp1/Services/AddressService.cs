
using ConsoleApp1.Entities;
using ConsoleApp1.Repositories;

namespace ConsoleApp1.Services;

internal class AddressService
{
    private readonly AddressRepository _addressRepository;

    public AddressService(AddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public AddressEntity CreateAddress(string street, string postalCode, string city)
    {
        var addressEntity = _addressRepository.Get(x => x.Street == street && x.PostalCode == postalCode && x.City == city);
        addressEntity ??= _addressRepository.Create(new AddressEntity { Street = street, PostalCode = postalCode, City = city });

        return addressEntity;
    }

    public AddressEntity GetAddress(string street, string postalCode, string city)
    {
        var addressEntity = _addressRepository.Get(x => x.Street == street && x.PostalCode == postalCode && x.City == city);
        return addressEntity;
    }

    public AddressEntity GetAddressById(int id)
    {
        var addressEntity = _addressRepository.Get(x => x.Id == id);
        return addressEntity;
    }

    public IEnumerable<AddressEntity> GetAllAddresses()
    {
        var addresses = _addressRepository.GetAll();
        return addresses;
    }


    public AddressEntity UpdateAddress(AddressEntity addressEntity)
    {
        var updatedAddressEntity = _addressRepository.Update(x => x.Id == addressEntity.Id, addressEntity);
        return updatedAddressEntity;
    }

    public void DeleteAddress(string street, string postalCode, string city)
    {
        _addressRepository.Delete(x => x.Street == street && x.PostalCode == postalCode && x.City == city);
    }
}
