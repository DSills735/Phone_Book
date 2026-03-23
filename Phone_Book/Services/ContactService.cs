using Phone_Book.Controllers;
using Phone_Book.Models;
using Spectre.Console;


namespace Phone_Book.Services
{
    internal class ContactService
    {


        internal static void UpdateContact()
        {
            var contact = GetContactInputList();

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("What do you want to update?")
                .AddChoices(new[]
                {
                    "Name",
                    "Relationship",
                    "Email",
                    "Phone Number",
                    "Exit to menu"
                }));

            switch (choice)
            {
                case "Name":
                    var name = AnsiConsole.Ask<string>("[blue]Enter the new name[/]");
                    contact.name = name;
                    ContactController.UpdateContactInformation(contact);
                    break;

                case "Relationship":
                    var relationship = AnsiConsole.Ask<string>("[blue]Enter the new relationship[/]");
                    contact.relationship = relationship;
                    ContactController.UpdateContactInformation(contact);
                    break;

                case "Email":
                    bool valid = false;
                    var email = "";
                    while (!valid)
                    {
                        email = AnsiConsole.Ask<string>("[blue]Enter the new email[/]");
                        valid = Validation.Validation.IsTheEmailValid(email);
                    }

                    contact.email = email;
                    ContactController.UpdateContactInformation(contact);
                    break;

                case "Phone Number":
                    var phoneNumber = "";
                    valid = false;
                    while (!valid)
                    {
                        phoneNumber = AnsiConsole.Ask<string>("[blue]Enter the new phone number (Expected Format: (XXX)XXX-XXXX)[/]");
                        valid = Validation.Validation.IsThePhoneNumberValid(phoneNumber);
                    }
                    contact.phoneNumber = phoneNumber;
                    ContactController.UpdateContactInformation(contact);
                    break;

                case "Exit to menu":
                    Console.Clear();
                    Menus.MainMenu.HomeScreen();
                    break;
            }
        }

        internal static Contact GetContactInputList()
        {
            var contacts = ContactController.GetContacts();
            var contactArray = contacts.Select(x => x.name).ToArray();

            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose contact")
                .AddChoices(contactArray));

            var id = contacts.Single(x => x.name == option).ContactID;

            var contact = ContactController.GetContactByID(id);

            return contact;
        }

        internal static void GetRelationshipInputList()
        {
            var contacts = ContactController.GetContacts();
            var relationshipArray = contacts.Select(x => x.relationship).ToArray();
            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose relationship")
                .AddChoices(relationshipArray));

            var id = contacts.Single(x => x.relationship == option).ContactID;
            var contact = ContactController.GetContactByID(id);

            Menus.UserInterface.ShowContactCard(contact);

        }

        internal static void DeleteContact()
        {
            var contact = GetContactInputList();
            ContactController.DeleteContact(contact);
            AnsiConsole.MarkupLine("[green]Contact successfully deleted[/]");
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()

                    .Title("What next?")
                    .AddChoices(new[]
                    {
                         "Delete another contact",
                         "Home Screen",
                         "Exit"
                    }));
            switch (choice)
            {
                case "Delete another contact":
                    Console.Clear();
                    DeleteContact();
                    break;
                case "Home Screen":
                    Console.Clear();
                    Menus.MainMenu.HomeScreen();
                    break;

                case "Exit":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
