using Phone_Book.Context;
using Phone_Book.Models;
using Spectre.Console;

//TODO further testing and debugging.

namespace Phone_Book.Controllers
{
    internal class ContactController
    {
        internal static void AddContact()
        {
            var name = AnsiConsole.Ask<string>("[blue]Enter full contact name[/]\n");
            var rel = AnsiConsole.Ask<string>("[blue]Enter your relationship. Ex. Work, Family, friend...[/]\n");
            bool valid = false;
            var email = AnsiConsole.Ask<string>("[blue]Enter their email[/]\n");

            while (!valid)
            {
                valid = Validation.Validation.IsTheEmailValid(email);
                email = AnsiConsole.Ask<string>("[blue]Enter their email[/]\n");
            }
            valid = false;
            var phoneNumber = AnsiConsole.Ask<string>("[blue]Enter their phone number (Expected Format: (XXX)XXX-XXXX [/]\n");
            while (!valid)

            {
               valid = Validation.Validation.IsThePhoneNumberValid(phoneNumber); 
               phoneNumber = AnsiConsole.Ask<string>("[blue]Enter their phone number (Expected Format: (XXX)XXX-XXXX [/]\n");
                
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
                    "Future option",
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

                case "blank":
                    break;

                case "Exit":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
