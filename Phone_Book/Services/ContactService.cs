using Phone_Book.Controllers;
using Phone_Book.Models;
using Spectre.Console;

namespace Phone_Book.Services
{
    internal class ContactService
    {
        internal void DisplayContacts(List<Models.Contact> contacts)
        {
            var table = new Table();
            table.AddColumn("Name");
            table.AddColumn("Relationship");
            table.AddColumn("Email");
            table.AddColumn("Phone Number");
            foreach (var contact in contacts)
            {
                table.AddRow(contact.name!, contact.relationship!, contact.email!, contact.phoneNumber!);
            }
            AnsiConsole.Write(table);
        }

        internal static void UpdateContact()
        {
            Controllers.ContactController.ViewContacts(false);
            var name = AnsiConsole.Ask<string>("Enter the name of the contact you want to change:");

            var detail = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What do you want to change?")
                    .AddChoices(new[] { "Name", "Relationship", "Email", "Phone Number" }));

            Controllers.ContactController.UpdateContactInformation(name, detail);

        }
        //TODO debug and finish
        internal static Contact GetContactInputList()
        {
            var contacts = ContactController.GetContacts();
            var contactArray = contacts.Select(c => c.name).ToArray();
            var contactName = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select a contact:")
                    .AddChoices(contactArray));
            var id = contacts.Single(c => c.name == contactName)?.ContactID;
            var contact = ContactController.GetContactByID(id);
            return contact;
        }
    }
}
