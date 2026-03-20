using Spectre.Console;

namespace Phone_Book.Visualizations
{
    internal class TableVisualizer
    {

        internal void DisplayContacts(List<Models.Contact> contacts)
        {
            var table = new Spectre.Console.Table();
            table.AddColumn("Name");
            table.AddColumn("Relationship");
            table.AddColumn("Email");
            table.AddColumn("Phone Number");
            foreach (var contact in contacts)
            {
                table.AddRow(contact.name!, contact.relationship!, contact.email!, contact.phoneNumber!);
            }
            Spectre.Console.AnsiConsole.Write(table);
        }
    }
}
