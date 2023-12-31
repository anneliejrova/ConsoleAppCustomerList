
using ConsoleAppCustomerList.Models;
using ConsoleAppCustomerList.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleAppCustomerList.Services;

internal class MenuService
{
    internal readonly CustomerService customerService = new CustomerService();
    


    public void ShowMainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("######## Meny ########");
            Console.WriteLine();
            Console.WriteLine("0. OBS! Läs detta först.");
            Console.WriteLine("1. Lägg Till Kund");
            Console.WriteLine("2. Visa Alla Kunder");
            Console.WriteLine("3. Sök kund");
            Console.WriteLine("4. Ta bort kund");

            var option = Console.ReadLine();

            switch (option)
            {
                case "0":
                    Console.Clear();
                    Console.WriteLine("Hej,");
                    Console.WriteLine();
                    Console.WriteLine("Tyvärr har min reumatism ställt till det för mig och jag har haft svårt att hänga med i denna kurs.");
                    Console.WriteLine("Jag har varit i kontakt med Hanna och sist vi pratade var jag fortfarande hoppfull men får nu erkänna");
                    Console.WriteLine("nederlag :-/");
                    Console.WriteLine();
                    Console.WriteLine("Jag har hamnat lite all over the place med att fånga upp och testa den kod som behövs för uppgiften, ");
                    Console.WriteLine("tanken var att klara den nu och plugga in det bättre när jag är frisk och hjärnan är på plats,");
                    Console.WriteLine("men trotts att jag gjort mitt bästa hann jag tyvärr inte i mål. Det jag lämnar in är därför väldigt ");
                    Console.WriteLine("nedbantat, och något 'choppy' då Maui-appen uteslöts i sista stund. Det enda som gäller nu är:");
                    Console.WriteLine("'Gör om gör rätt!' så jag kommer att behöva mer tid för att bli klar och hoppas på överseende med detta.");
                    Console.WriteLine();
                    Console.WriteLine("MVH Annelie");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Tryck på valfri knapp för att återgå till menyn");
                    break;

                case "1":
                    ShowAddMenu();
                    break;

                case "2":
                    ShowAllMenu();
                    break;

                case "3":
                    FindCustomer();
                    break;

                case "4":
                    RemoveCustomer();
                    break;

                default:
                    Console.Clear(); Console.WriteLine("Felaktigt val, Försök igen!");
                    Console.WriteLine();
                    Console.WriteLine("Tryck på valfri knapp för att återgå till menyn");
                    break;
            }

            Console.ReadKey();
        }
    }

    private void ShowAddMenu()
    {
        Console.Clear();
        var customer = new Customer();
        Console.WriteLine("### Lägg till Kund ###");
        Console.WriteLine();

        Console.WriteLine("FÖRETAGS INFORMATION");
        Console.Write("Ange Företagsnamn: ");
        customer.CompanyName = Console.ReadLine()!;
        Console.Write("Ange Telefonnr: ");
        customer.Phone= Console.ReadLine()!;
        Console.Write("Ange Email: ");
        customer.Email = Console.ReadLine()!;
        Console.Write("Ange Gatuadress: ");
        customer.StreetAddress = Console.ReadLine()!;
        Console.Write("Ange Postkod: ");
        customer.PostalCode = Console.ReadLine()!;
        Console.Write("Ange Stad: ");
        customer.City = Console.ReadLine()!;
        Console.WriteLine();
        Console.WriteLine("KONTAKTPERSON INFORMATION");
        Console.Write("Ange Förnamn: ");
        customer.Person.FirstName = Console.ReadLine()!;
        Console.Write("Ange Efternamn: ");
        customer.Person.LastName = Console.ReadLine()!;
        Console.Write("Ange Jobbtitel: ");
        customer.Person.Title = Console.ReadLine()!;
        Console.Write("Ange Direktnummer: ");
        customer.Person.DirectPhone = Console.ReadLine()!;
        Console.Write("Ange Personlig Email: ");
        customer.Person.PersonalEmail= Console.ReadLine()!;
        

        customerService.AddCustomerToList(customer);

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Tryck på valfri knapp för att återgå till menyn");
    }

    private void ShowAllMenu()
    {
        Console.Clear();
        Console.WriteLine("### Lista på Kunder ###");
        var allCustomers = customerService.GetAllCustomers();


        foreach(var customer in allCustomers)
        {
            Console.WriteLine();
            Console.WriteLine($"FÖRETAG:  {customer.CompanyName}");
            Console.WriteLine($"          {customer.Phone}");
            Console.WriteLine($"          {customer.Email}");
            Console.WriteLine();
            Console.WriteLine($"          {customer.StreetAddress}");
            Console.WriteLine($"          {customer.PostalCode} {customer.City}");
            Console.WriteLine();
            Console.WriteLine("          Kontaktperson: ");
            Console.WriteLine($"          {customer.Person.Title}");
            Console.WriteLine($"          {customer.Person.FirstName} {customer.Person.LastName}");
            Console.WriteLine($"          {customer.Person.DirectPhone}");
            Console.WriteLine($"          {customer.Person.PersonalEmail}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Tryck på valfri knapp för att återgå till menyn");
        }

    }

    private void FindCustomer()
    {
        Console.WriteLine("### Sök Kund ###");
        Console.Write("Ange Email:");
        var email = Console.ReadLine()!;
        var customer = customerService.GetCustomerFromList(email);
        Console.WriteLine();
        Console.WriteLine($"FÖRETAG: {customer.CompanyName}");
        Console.WriteLine($"             {customer.Phone}");
        Console.WriteLine($"             {customer.Email}");
        Console.WriteLine();
        Console.WriteLine($"             {customer.StreetAddress}");
        Console.WriteLine($"             {customer.PostalCode} {customer.City}");
        Console.WriteLine();
        Console.WriteLine("             Kontaktperson:");
        Console.WriteLine($"             {customer.Person.Title}");
        Console.WriteLine($"             {customer.Person.FirstName} {customer.Person.LastName}");
        Console.WriteLine($"             {customer.Person.DirectPhone}");
        Console.WriteLine($"             {customer.Person.PersonalEmail}");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Tryck på valfri knapp för att återgå till menyn");

    }

    private void RemoveCustomer()
    {


    }
}
