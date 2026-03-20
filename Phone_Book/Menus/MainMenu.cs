
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
                    "View all contacts",
                    "Exit"
                }));

            switch (choice) 
            {
                case "Add a contact":
                    Controllers.ContactController.AddContact();
                    break;

                case "Update an existing contact":
                    
                    break;

                case "Delete a contact":
                    
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
