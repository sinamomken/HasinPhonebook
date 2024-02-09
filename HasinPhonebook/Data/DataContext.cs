using HasinPhonebook.Entities;
using Microsoft.EntityFrameworkCore;

namespace HasinPhonebook.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<PhonebookItem> PhonebookItems { get; set; }
        public DbSet<Phonebook> Phonebooks { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
