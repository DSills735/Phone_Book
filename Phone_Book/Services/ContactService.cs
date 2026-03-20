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
    }
}
