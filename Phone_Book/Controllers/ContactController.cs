using Microsoft.EntityFrameworkCore;
using Phone_Book.Context;
using Phone_Book.Models;
using Spectre.Console;

namespace Phone_Book.Controllers
{
    internal class ContactController
    {
        internal static void AddContact()
        {
            bool valid = false;
            var name = "";
            while (!valid)
            {
                name = AnsiConsole.Ask<string>("[blue]Enter full contact name[/]\n");
                valid = Validation.Validation.IsTheInputNull(name);
            }
            valid = false;
            string rel = "";
            while (!valid)
            {
                rel = AnsiConsole.Ask<string>("[blue]Enter your relationship. Ex. Work, Family, friend...[/]\n");
                valid = Validation.Validation.IsTheInputNull(rel);
            }

            valid = false;
            var email = "";
            while (!valid)
            {
                email = AnsiConsole.Ask<string>("[blue]Enter their email[/]\n");
                valid = Validation.Validation.IsTheEmailValid(email);

            }

            valid = false;
            var phoneNumber = "";
            while (!valid)

            {
                phoneNumber = AnsiConsole.Ask<string>("[blue]Enter their phone number (Expected Format: (XXX)XXX-XXXX [/]\n");
                valid = Validation.Validation.IsThePhoneNumberValid(phoneNumber);

            }

            using var db = new ContactContext();

            db.Add(new Contact
            {
                name = name,
                relationship = rel,
                email = email,
                phoneNumber = phoneNumber
            });

            AnsiConsole.Status()
                         .Start("Saving contact...", ctx =>
                         {
                             ctx.Spinner(Spinner.Known.Aesthetic);
                             db.SaveChanges();
                             Thread.Sleep(3000);
                         });

            AnsiConsole.MarkupLine("[green]Contact successfully added[/]");
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("What next?")
                .AddChoices(new[]
                {
                    "Add another contact",
                    "Home Screen",
                    "Future option -- NOT FUNCTIONAL",
                    "Exit"
                }));

            switch (choice)
            {

                case "Add another contact":
                    Console.Clear();
                    AddContact();
                    break;

                case "Home Screen":
                    Console.Clear();
                    Menus.MainMenu.HomeScreen();
                    break;

                case "Save for future menu option":
                    break;

                case "Exit":
                    Environment.Exit(0);
                    break;
            }
        }
        internal static void ViewContacts(bool menu)
        {
            Contact contact = new Contact();
            using var db = new ContactContext();
            var contacts = db.contacts.ToList();
            Services.ContactService contactService = new Services.ContactService();
            contactService.DisplayContacts(contacts);

            if(menu)
            {
                Console.WriteLine("Press any key to return to the home screen...");
                Console.ReadKey();
                Console.Clear();
                Menus.MainMenu.HomeScreen();
            }
        }
        internal static void UpdateContactInformation(string info, string detail)
        {
            using var db = new ContactContext();
            Contact contact = new Contact();
            

            switch (detail)
            {
                case "Name":
                    var name = AnsiConsole.Ask<string>("[blue]Enter the new name[/]\n");
                    if (name != null)
                    {
                        db.Update(contact.name = name);
                    }
                    break;

                case "Relationship":
                    var rel = AnsiConsole.Ask<string>("[blue]Enter your relationship with this contact[/]\n");
                    if (rel != null)
                    {
                        db.Update(contact.relationship = rel);
                    }
                    break;

                case "Phone Number":
                    bool valid = false;
                    var num = "";
                    while (!valid)
                    {
                        num = AnsiConsole.Ask<string>("[blue]Enter the new phone number. Format: (xxx)xxx-xxxx [/]\n");
                        if (num != null)
                        {
                            db.Update(contact.phoneNumber = num);
                        }
                    }

                    break;
                case "Email":
                    var email = "";
                    valid = false;

                    while (!valid)
                    {
                        email = AnsiConsole.Ask<string>("[blue]Enter the new name[/]\n");
                        if (email != null)
                        {
                            db.Update(contact.name = email);
                        }
                    }
                    break;
            }

            db.SaveChanges();

        }
        internal static void GetContactByID(int id)
        {
            using var db = new ContactContext();
            var contact = db.contacts.SingleOrDefault(c => c.ContactID == id);
            if (contact != null)
            {
                AnsiConsole.MarkupLine($"[blue]Name:[/] {contact.name}");
                AnsiConsole.MarkupLine($"[blue]Relationship:[/] {contact.relationship}");
                AnsiConsole.MarkupLine($"[blue]Email:[/] {contact.email}");
                AnsiConsole.MarkupLine($"[blue]Phone Number:[/] {contact.phoneNumber}");
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Contact not found.[/]");
            }
        }
        internal static List<Contact> GetContacts()
        {
            using var db = new ContactContext();

            var contacts = db.contacts.ToList();

            return contacts;
        }
    }
}
