
using ConsoleApp1.Services;

namespace ConsoleApp1
{
    internal class ConsoleUI
    {
        private readonly CompanyService _companyService;

        public ConsoleUI(CompanyService companyService)
        {
            _companyService = companyService;
        }

        public void CreateCompany_UI()
        {
            Console.Clear();
            Console.WriteLine("----- SKAPA NY FÖRETAGSKUND -----");

            Console.WriteLine();
            Console.Write("Företagsnamn: ");
            var companyName = Console.ReadLine()!;
            Console.Write("Webbsida :");
            var webpage = Console.ReadLine()!;
            Console.Write("Email :");
            var email = Console.ReadLine()!;
            Console.Write("Telefon :");
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
            Console.Write("Jobbtitel:");
            var role = Console.ReadLine()!;
            Console.Write("Förnamn: ");
            var firstName = Console.ReadLine()!;
            Console.Write("Efternamn: ");
            var lastName = Console.ReadLine()!;
            Console.Write("Personlig Email: ");
            var personalEmail = Console.ReadLine()!;
            Console.Write("Direkt nr:");
            var directPhone = Console.ReadLine()!;
            Console.WriteLine();

            Console.WriteLine("---Info---");
            Console.Write("Anteckningar om kund:");
            var notes = Console.ReadLine()!;



            var result = _companyService.CreateCompany(companyName, webpage, email, phone, street, postalCode, city, role, firstName, lastName, personalEmail, directPhone, notes);
            if (result != null)
            {
                Console.Clear();
                Console.WriteLine("Ny företagskund har skapats");
                Console.ReadKey();
            }
        }
    }
}
