

namespace Phone_Book.Models
{
     public class Contact
    {
        public int ContactID { get; set; }
        public required string name { get; set; }
        public string? email { get; set; }
        public string? phoneNumber { get; set; }

    }
}
