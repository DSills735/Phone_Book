
using Spectre.Console;
using System.Text.RegularExpressions;

namespace Phone_Book.Validation
{
    public class Validation
    {

        public static bool IsThePhoneNumberValid(string phoneNumber)
        {
            string pattern = @"^\(\d{3}\)\d{3}-\d{4}";

            if (Regex.IsMatch(phoneNumber, pattern))
            {
                return true;
            }
            else
            {
                AnsiConsole.MarkupLine("[red] INVALID PHONE NUMBER. Please enter a valid phone number in the format (XXX)XXX-XXXX[/]");
                return false;
            }


        }

        public static bool IsTheEmailValid(string email)
        {
            
            string pattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                   + "@"
                                   + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z";

            if (Regex.IsMatch(email, pattern))
            {
                return true;
            }
            else
            {
                AnsiConsole.MarkupLine("[red] INVALID EMAIL. Please enter a valid email address.[/]");
                return false;
            }
            
        }

        internal static bool IsTheInputNull(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                AnsiConsole.MarkupLine("[red] INVALID INPUT. Please enter a valid input.[/]");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
