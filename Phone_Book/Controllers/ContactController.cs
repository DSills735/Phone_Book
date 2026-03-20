using Phone_Book.Context;
using Phone_Book.Models;
using Spectre.Console;

namespace Phone_Book.Controllers
{
    internal class ContactController
    {
        internal static void AddContact()
        {
            var name = AnsiConsole.Ask<string>("[blue]Enter full contact name[/]\n");
            var rel = AnsiConsole.Ask<string>("[blue]Enter your relationship. Ex. Work, Family, friend...[/]\n");
            bool valid = false;
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
    }
}
