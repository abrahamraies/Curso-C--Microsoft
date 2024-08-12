using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var corporateContacts = new List<(string firstName, string lastName)>
        {
            ("Robert", "Bavin"),
            ("Simon", "Bright"),
            ("Kim", "Sinclair"),
            ("Aashrita", "Kamath"),
            ("Sarah", "Delucchi"),
            ("Sinan", "Ali")
        };

        var externalContacts = new List<(string firstName, string lastName)>
        {
            ("Vinnie", "Ashton"),
            ("Cody", "Dysart"),
            ("Shay", "Lawrence"),
            ("Daren", "Valdes")
        };

        const string externalDomain = "hayworth.com";

        DisplayEmails(corporateContacts);
        DisplayEmails(externalContacts, externalDomain);
    }

    static void DisplayEmails(List<(string firstName, string lastName)> contacts, string domain = "contoso.com")
    {
        foreach (var (firstName, lastName) in contacts)
        {
            DisplayEmail(firstName, lastName, domain);
        }
    }

    static void DisplayEmail(string firstName, string lastName, string domain)
    {
        string email = $"{firstName.Substring(0, 2).ToLower()}{lastName.ToLower()}@{domain}";
        Console.WriteLine(email);
    }
}