using Microsoft.EntityFrameworkCore;
using Phone_Book.Models;


namespace Phone_Book.Context
{
    internal class ContactContext : DbContext
    {
        public DbSet<Contact> contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\PhoneBook");
        }

    }
}
