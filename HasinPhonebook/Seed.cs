using HasinPhonebook.Data;
using HasinPhonebook.Entities;

namespace HasinPhonebook
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if(!dataContext.Customers.Any())
            {
                var customers = new List<Customer>()
                {
                    new Customer()
                    {
                        IdentificationCode = "0080310842",
                        Name = "Sina Momken",
                        Phonebooks = new List<Phonebook>() {
                            new Phonebook() {
                                Name = "Friends",
                                PhonebookItems = new List<PhonebookItem>() {
                                    new PhonebookItem()
                                    {
                                        ItemFirstName = "Farzan",
                                        ItemLastName = "Falahat",
                                        ItemPhone = "09121234567",
                                        ItemTag = "close friend"
                                    },
                                    new PhonebookItem()
                                    {
                                        ItemFirstName = "Aboozar",
                                        ItemLastName = "Noori",
                                        ItemPhone = "09127654321",
                                        ItemTag = "acquaintance"
                                    },
                                    new PhonebookItem()
                                    {
                                        ItemFirstName = "Pooya",
                                        ItemLastName = "Momken",
                                        ItemPhone = "09126191488",
                                        ItemTag = "brother",
                                    },
                                    new PhonebookItem()
                                    {
                                        ItemFirstName = "Hadi",
                                        ItemLastName = "Momken",
                                        ItemPhone = "09121830014",
                                        ItemTag = null
                                    }
                                }
                            }
                        }
                    }
                };
                dataContext.Customers.AddRange(customers);
                dataContext.SaveChanges();
            }
        }
    }
}
