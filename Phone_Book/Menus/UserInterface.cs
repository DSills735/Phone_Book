using Phone_Book.Models;
using Spectre.Console;


namespace Phone_Book.Menus
{
    internal class UserInterface
    {
        internal static void ShowProductCard(Contact contact)
        {
            //dont fix this formatting, it is intentional
            var panel = new Panel($@"Name: {contact.name}
Relationship: {contact.relationship}
Phone Number: {contact.phoneNumber}
Email: {contact.email}");
            panel.Header = new PanelHeader($"Contact Information for {contact.name}");
            panel.Padding = new Padding(2, 2, 2, 2);

            AnsiConsole.Write(panel);

            Console.WriteLine("Press any key to return to the home screen...");
            Console.ReadKey();
            Console.Clear();
            MainMenu.HomeScreen();
        }

        internal static void DisplayContacts(List<Contact> contacts)
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
