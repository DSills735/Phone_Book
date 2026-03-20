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
            Visualizations.TableVisualizer tableVisualizer = new Visualizations.TableVisualizer();
            tableVisualizer.DisplayContacts(contacts);

            if(menu)
            {
                Console.WriteLine("Press any key to return to the home screen...");
                Console.ReadKey();
                Console.Clear();
                Menus.MainMenu.HomeScreen();
            }
        }
    }
}
