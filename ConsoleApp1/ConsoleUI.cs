
using ConsoleApp1.Entities;
using ConsoleApp1.Repositories;
using ConsoleApp1.Services;
using System.Runtime.InteropServices;

namespace ConsoleApp1;

internal class ConsoleUI
{
    private readonly CompanyService _companyService;
    private readonly NoteService _noteService;
    private readonly ContactPersonService _contactPersonService;
    private readonly RoleService _roleService;

    public ConsoleUI(CompanyService companyService, NoteService noteService, ContactPersonService contactPersonService, RoleService roleService)
    {
        _companyService = companyService;
        _noteService = noteService;
        _contactPersonService = contactPersonService;
        _roleService = roleService;
    }

    public void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("######## Meny ########");
            Console.WriteLine();
            
            Console.WriteLine("0.Lägg Till Företagskund");
            Console.WriteLine("1. Lista Alla Företagskunder");
            Console.WriteLine("2. Sök specifik Företagskund");
            Console.WriteLine("3. Redigera Befintlig Företagskund");
            Console.WriteLine("4. Ta bort Företagskund");

            var option = Console.ReadLine();

            switch (option)
            {
                case "0":
                    CreateCompany_UI();
                    break;

                case "1":
                    GetCompanies_UI();
                    break;

                case "2":
                    FindOneCompany_UI();
                    break;

                case "3":
                    EditCompanyInfo_UI();
                    break;

                case "4":
                    DeleteCompany_UI();
                    break;

                default:
                    Console.Clear(); Console.WriteLine("Felaktigt val, Försök igen!");
                    Console.WriteLine();
                    Console.WriteLine("Tryck på valfri knapp för att återgå till menyn");
                    break;
            }
        }
    }

    public void CreateCompany_UI()
    {
        Console.Clear();
        Console.WriteLine("----- SKAPA NY FÖRETAGSKUND -----");

        Console.WriteLine();
        Console.Write("Företagsnamn: ");
        var companyName = Console.ReadLine()!;
        Console.Write("Webbsida: ");
        var webpage = Console.ReadLine()!;
        Console.Write("Email: ");
        var email = Console.ReadLine()!;
        Console.Write("Telefon: ");
        var phone = Console.ReadLine()!;
        Console.WriteLine();

        Console.WriteLine("--- Adress ---");
        Console.Write("Gatuadress: ");
        var street = Console.ReadLine()!;
        Console.Write("Postnummer: ");
        var postalCode = Console.ReadLine()!;
        Console.Write("Stad: ");
        var city = Console.ReadLine()!;
        Console.WriteLine();

        Console.WriteLine("--- Kontaktperson ---");
        Console.Write("Jobbtitel: ");
        var role = Console.ReadLine()!;
        Console.Write("Förnamn: ");
        var firstName = Console.ReadLine()!;
        Console.Write("Efternamn: ");
        var lastName = Console.ReadLine()!;
        Console.Write("Personlig Email: ");
        var personalEmail = Console.ReadLine()!;
        Console.Write("Direkt nr: ");
        var directPhone = Console.ReadLine()!;
        Console.WriteLine();

        Console.WriteLine("---Anteckningar---");
        Console.Write("Om kund: ");
        var notes = Console.ReadLine()!;



        var result = _companyService.CreateCompany(companyName, webpage, email, phone, street, postalCode, city, role, firstName, lastName, personalEmail, directPhone, notes);
        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("Ny företagskund har skapats");
            Console.WriteLine();
            Console.WriteLine("Tryck på valfri knapp för att återgå till menyn");
            Console.ReadKey();
        }
    }
    public void GetCompanies_UI()
    {
        Console.Clear() ;
        var companies = _companyService.GetAllCompanies();
        foreach (var company in companies)

        {
            Console.WriteLine($"FÖRETAG:  {company.CompanyName}");
            Console.WriteLine($"          {company.Website}");
            Console.WriteLine($"          {company.Phone}");
            Console.WriteLine($"          {company.Email}");
            Console.WriteLine();
            Console.WriteLine($"          {company.Address.Street}");
            Console.WriteLine($"          {company.Address.PostalCode} {company.Address.City}");
            Console.WriteLine();
            Console.WriteLine("        Kontaktperson: ");
            Console.WriteLine($"          {company.ContactPerson.FirstName} {company.ContactPerson.LastName}");
            Console.WriteLine($"          direkt nummer:{company.ContactPerson.DirectPhone}");
            Console.WriteLine($"          personlig email:{company.ContactPerson.PersonalEmail}");
            Console.WriteLine();
            Console.WriteLine("        Anteckningar: ");
            Console.WriteLine($"          {company.Note.Note}");
            Console.WriteLine();
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine("Tryck på valfri knapp för att återgå till menyn");
        Console.ReadKey();
    }

    public void FindOneCompany_UI()
    {
        Console.Clear();
        Console.WriteLine("-----Hitta Företag-----");
        Console.WriteLine();
        Console.Write("Ange företagsnamn: ");
        var name = Console.ReadLine()!;
        var company = _companyService.GetCompanyByName(name);
        if (company == null)
        {
            Console.WriteLine("Inget Företag hittades under detta namn!");
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"FÖRETAG:  {company.CompanyName}");
            Console.WriteLine($"          {company.Website}");
            Console.WriteLine($"          {company.Phone}");
            Console.WriteLine($"          {company.Email}");
            Console.WriteLine();
            Console.WriteLine($"          {company.Address.Street}");
            Console.WriteLine($"          {company.Address.PostalCode} {company.Address.City}");
            Console.WriteLine();
            Console.WriteLine("        Kontaktperson: ");      
            Console.WriteLine($"          {company.ContactPerson.FirstName} {company.ContactPerson.LastName}");
            Console.WriteLine($"          direkt nummer:{company.ContactPerson.DirectPhone}");
            Console.WriteLine($"          personlig email:{company.ContactPerson.PersonalEmail}");
            Console.WriteLine();
            Console.WriteLine("        Anteckningar: ");
            Console.WriteLine($"          {company.Note.Note}");
            Console.WriteLine();
            Console.WriteLine();
        }
        Console.ReadKey();
    }
    public void EditCompanyInfo_UI()
    {
        Console.Clear();
        Console.WriteLine("-----Redigera Företagsinformation-----");
        Console.WriteLine();
        Console.Write("Ange företagsnamn: ");
        var name = Console.ReadLine()!;
        var company = _companyService.GetCompanyByName(name);
        if(company == null)
        {
            Console.WriteLine("Inget Företag hittades under detta namn! Tryck på valfri knapp för att återgå till huvudmenyn");
        }
           else 
        {
            Console.Clear();
            Console.WriteLine($"FÖRETAG:  {company.CompanyName}");
            Console.WriteLine($"          {company.Website}");
            Console.WriteLine($"          {company.Phone}");
            Console.WriteLine($"          {company.Email}");
            Console.WriteLine();
            Console.WriteLine($"          {company.Address.Street}");
            Console.WriteLine($"          {company.Address.PostalCode} {company.Address.City}");
            Console.WriteLine();
            Console.WriteLine("        Kontaktperson: ");
            Console.WriteLine($"          {company.ContactPerson.FirstName} {company.ContactPerson.LastName}");
            Console.WriteLine($"          direkt nummer:{company.ContactPerson.DirectPhone}");
            Console.WriteLine($"          personlig email:{company.ContactPerson.PersonalEmail}");
            Console.WriteLine();
            Console.WriteLine("        Anteckningar: ");
            Console.WriteLine($"          {company.Note.Note}");
            Console.WriteLine();
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("-----ÄNDRINGAR-----");
                Console.WriteLine("Vad ska ändras?");
                Console.WriteLine("0. Företagsnamn");
                Console.WriteLine("1. Webbsida");
                Console.WriteLine("2. Telefonnummer");
                Console.WriteLine("3. Email");
                Console.WriteLine("4. Adress");
                Console.WriteLine("5. Kontakt Person");
                Console.WriteLine("6. Notes") ;
                Console.WriteLine("7. Klar");


                var option = Console.ReadLine();

                switch (option)
                {
                    case "0":
                        Console.Write("Nytt Företagsnamn: ");
                        company.CompanyName = Console.ReadLine()!;
                        var newCompanyName = _companyService.UpdateCompany(company);
                        break;

                    case "1":
                        Console.Write("Ny Webbsida: ");
                        company.Website = Console.ReadLine()!;
                        var newWebsite = _companyService.UpdateCompany(company);
                        break;

                    case "2":
                        Console.Write("Nytt Telefonnummer: ");
                        company.Phone = Console.ReadLine()!;
                        var newPhone = _companyService.UpdateCompany(company);
                        Console.Clear();
                        break;

                    case "3":
                        Console.Write("Ny Email: ");
                        company.Email = Console.ReadLine()!;
                        var newEmail = _companyService.UpdateCompany(company);
                        break;

                    case "4":
                        Console.WriteLine("Fyll I Alla Fält!");
                        Console.WriteLine();
                        Console.Write("Ny Gatuadress: ");
                        company.Address.Street = Console.ReadLine()!;
                        Console.Write("Nytt Postnummer: ");
                        company.Address.PostalCode = Console.ReadLine()!;
                        Console.Write("Ny Stad: ");
                        company.Address.City = Console.ReadLine()!;
                        var newAddress = _companyService.UpdateCompany(company);
                        break;

                    case "5":
                        Console.WriteLine("Fyll I Alla Fält!");
                        Console.WriteLine();
                        Console.Write("Ny Jobbtitel: ");
                        var roleName = Console.ReadLine()!;
                        var roleEntity = _roleService.CreateRole(roleName);
                        company.ContactPerson.RoleId = roleEntity.Id;
                        Console.Write("Nytt Förnamn: ");
                        company.ContactPerson.FirstName = Console.ReadLine()!;
                        Console.Write("Nytt Efternamn: ");
                        company.ContactPerson.LastName = Console.ReadLine()!;
                        Console.Write("Ny Personlig Email: ");
                        company.ContactPerson.PersonalEmail = Console.ReadLine()!;
                        Console.Write("Nytt Direkt nr: ");
                        company.ContactPerson.DirectPhone = Console.ReadLine()!;
                        var newContactPerson = _companyService.UpdateCompany(company);
                        break;

                    case "6":
                        Console.WriteLine("Förändringar i Anteckningar: ");
                        var note = Console.ReadLine()!;
                        var noteEntity = _noteService.CreateNote(note);
                        company.Note.Note = noteEntity.Note;
                        break;

                    case "7":
                        Console.WriteLine("----- ÄNDRINGAR GENOMFÖRDA-----");
                        Console.WriteLine();
                        Console.WriteLine($"FÖRETAG:  {company.CompanyName}");
                        Console.WriteLine($"          {company.Website}");
                        Console.WriteLine($"          {company.Phone}");
                        Console.WriteLine($"          {company.Email}");
                        Console.WriteLine();
                        Console.WriteLine($"          {company.Address.Street}");
                        Console.WriteLine($"          {company.Address.PostalCode} {company.Address.City}");
                        Console.WriteLine();
                        Console.WriteLine("        Kontaktperson: ");
                        Console.WriteLine($"          {company.ContactPerson.FirstName} {company.ContactPerson.LastName}");
                        Console.WriteLine($"          direkt nummer:{company.ContactPerson.DirectPhone}");
                        Console.WriteLine($"          personlig email:{company.ContactPerson.PersonalEmail}");
                        Console.WriteLine();
                        Console.WriteLine("        Anteckningar: ");
                        Console.WriteLine($"          {company.Note.Note}");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.ReadKey();
                        return;

                    default:
                        Console.Clear(); Console.WriteLine("Felaktigt val, Försök igen!");
                        Console.WriteLine();
                        break;
                }
            }         
            
        }
        Console.ReadKey();

    }

    public void DeleteCompany_UI()
    {
        Console.Clear();
        Console.WriteLine("-----TA BORT FÖRETAGSKUND-----");
        Console.WriteLine();
        Console.Write("Ange Företagsnamn: ");
        var name = Console.ReadLine()!;
        var company = _companyService.GetCompanyByName(name);
        if (company == null)
           { Console.WriteLine("Företaget kunde inte hittas. Försök igen"); 
        }
        else 
        {
            Console.Clear();
            Console.WriteLine("Vill du raddera detta företag och all dess Information?");
            Console.WriteLine($"FÖRETAG:  {company.CompanyName}");
            Console.WriteLine($"          {company.Phone}");
            Console.WriteLine($"          {company.Email}");
            Console.WriteLine();
            Console.WriteLine($"          {company.Address.Street}");
            Console.WriteLine($"          {company.Address.PostalCode} {company.Address.City}");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("-----RADDERA-----");
                Console.WriteLine("0.JA");
                Console.WriteLine("1.NEJ");

                var option = Console.ReadLine();
                switch (option)
                {
                    case "0":

                        var companyEntity = _companyService.GetCompanyByName(name);

                        if (companyEntity != null)
                        {
                            _companyService.DeleteCompany(companyEntity.CompanyName);
                            _contactPersonService.DeleteContactPerson(companyEntity.ContactPersonId);
                            _noteService.DeleteNote(companyEntity.NoteId);
                            Console.WriteLine("Företagskund är borttagen");
                        }
                        return;
                        

                    case "1":
                        Console.WriteLine("Inga ändringar gjorda. Tryck på en knapp för att återvända till huvudmenyn.");
                        return;

                    default:
                        Console.Clear(); Console.WriteLine("Felaktigt val, Försök igen!");
                        Console.WriteLine();
                        break;
                }

            }
        }
        
    }
}
