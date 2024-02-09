
using ConsoleApp1.Entities;
using ConsoleApp1.Repositories;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.Services;

internal class ContactPersonService
{
    private readonly ContactPersonRepository _contactPersonRepository;
    private readonly RoleService _roleService;

    public ContactPersonService(ContactPersonRepository contactPersonRepository, RoleService roleService)
    {
        _contactPersonRepository = contactPersonRepository;
        _roleService = roleService;
    }

    public ContactPersonEntity CreateContactPerson(string role, string firstName, string lastName, string personalEmail, string directPhone)
    {
        var roleEntity = _roleService.CreateRole(role);
        var contactPersonEntity = new ContactPersonEntity()
        {
            FirstName = firstName,
            LastName = lastName,
            PersonalEmail = personalEmail,
            DirectPhone = directPhone,
            Role = roleEntity
        };

        _contactPersonRepository.Create(contactPersonEntity);

        return contactPersonEntity;
    }

    public ContactPersonEntity GetContactPersonByName(string firstName, string lastName)
    {
        var contactPersonEntity = _contactPersonRepository.Get(x => x.FirstName == firstName && x.LastName == lastName);
        return contactPersonEntity;
    }

    public ContactPersonEntity GetContactPersonByEmail(string personalEmail)
    {
        var contactPersonEntity = _contactPersonRepository.Get(x => x.PersonalEmail == personalEmail);
        return contactPersonEntity;
    }


    public IEnumerable<ContactPersonEntity> GetAllContactPersons()
    {
        var contactPersons = _contactPersonRepository.GetAll();
        return contactPersons;
    }

    public ContactPersonEntity UpdateContactPerson(ContactPersonEntity contactPersonEntity)
    {
        var updatedContactPersonEntity = _contactPersonRepository.Update(x => x.Id == contactPersonEntity.Id, contactPersonEntity);
        return updatedContactPersonEntity;
    }

    public void DeleteContactPerson(int id)
    {
        _contactPersonRepository.Delete(x => x.Id == id);
    }
}
