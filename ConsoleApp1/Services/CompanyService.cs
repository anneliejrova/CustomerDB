

using ConsoleApp1.Entities;
using ConsoleApp1.Repositories;
using System.IO;

namespace ConsoleApp1.Services;

internal class CompanyService
{
    private readonly CompanyRepository _companyRepository;
    private readonly AddressService _addressService;
    private readonly ContactPersonService _contactPersonService;
    private readonly NoteService _noteService;

    public CompanyService(CompanyRepository companyRepository, AddressService addressService, ContactPersonService contactPersonService, NoteService noteService)
    {
        _companyRepository = companyRepository;
        _addressService = addressService;
        _contactPersonService = contactPersonService;
        _noteService = noteService;
    }

    public CompanyEntity CreateCompany(string companyName, string website, string email, string phone, string street, string postalCode, string city, string firstName, string lastName, string personalEmail, string directPhone, string role, string note)
    {
        var addressEntity = _addressService.CreateAddress(street, postalCode, city);
        var contactPersonEntity = _contactPersonService.CreateContactPerson(firstName, lastName, personalEmail, directPhone, role);
        var noteEntity = _noteService.CreateNote(note);

        var companyEntity = new CompanyEntity()
        {
            CompanyName = companyName,
            Website = website,
            Email = email,
            Phone = phone,
            AddressId = addressEntity.Id,
            ContactPersonId = contactPersonEntity.Id,
            NoteId = noteEntity.Id,
        };

        companyEntity = _companyRepository.Create(companyEntity);
        return companyEntity;

    }

    public CompanyEntity GetCompanyByName(string companyName)
    {
        var companyEntity = _companyRepository.Get(x => x.CompanyName == companyName);
        return companyEntity;
    }

    public CompanyEntity GetCompanyById(int id)
    {
        var companyEntity = _companyRepository.Get(x => x.Id == id);
        return companyEntity;
    }

    public IEnumerable<CompanyEntity> GetAllCompanies()
    {
        var companies = _companyRepository.GetAll();
        return companies;
    }


    public CompanyEntity UpdateCompany(CompanyEntity companyEntity)
    {
        var updatedCompanyEntity = _companyRepository.Update(x => x == companyEntity, companyEntity);
        return updatedCompanyEntity;
    }

    public void DeleteCompany(int id)
    {
        _companyRepository.Delete(x => x.Id == id);
    }
}
