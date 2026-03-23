
using Phone_Book.Services;
using Spectre.Console;

namespace Phone_Book.Menus
{
    internal class MainMenu
    {
        public static void HomeScreen()
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Welcome to the Phone book. Please use the arrow keys to select an option.")
                .AddChoices(new[]
                {
                    "Add a contact",
                    "Update an existing contact",
                    "Delete a contact",
                    "View a single contact card",
                    "View all contacts",
                    "View contacts by relationship",
                    "Exit"
                }));

            switch (choice) 
            {
                case "Add a contact":
                    Controllers.ContactController.AddContact();
                    break;

                case "Update an existing contact":
                    Services.ContactService.UpdateContact();
                    break;

                case "Delete a contact":
                    ContactService.DeleteContact();
                    break;
                case "View a single contact card":
                    var contact = Services.ContactService.GetContactInputList();
                    UserInterface.ShowContactCard(contact);
                    break;
                case "View contacts by relationship":
                    Services.ContactService.GetRelationshipInputList();
                    break;

                case "View all contacts":
                    Controllers.ContactController.ViewContacts(true);
                    break;

                case "Exit":
                    Environment.Exit(0);
                    break;
              
            }

        }
    }
}
