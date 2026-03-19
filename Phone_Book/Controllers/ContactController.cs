using Spectre.Console;

namespace Phone_Book.Controllers
{
    internal class ContactController
    {
        internal static void AddContact()
        {
            var name = AnsiConsole.Ask<string>("Enter full contact name");
            var email = AnsiConsole.Ask<string>("Enter their email");
            var phoneNumber = AnsiConsole.Ask<string>("Enter their phone number");
        }
    }
}
