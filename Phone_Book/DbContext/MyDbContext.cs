
using Microsoft.EntityFrameworkCore;
using Phone_Book.Models;

namespace Phone_Book.DbContext
{
    internal class MyDbContext 
    {
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\PhoneBook;Database=EFConsoleDemo;Trusted_Connection=True;");
        }
    }
}
