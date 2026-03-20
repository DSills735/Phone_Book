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

            //todo finish this

        }
    }
}
