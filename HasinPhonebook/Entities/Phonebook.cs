namespace HasinPhonebook.Entities
{
    public class Phonebook
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public Customer Customer { get; set; }
        public List<PhonebookItem> PhonebookItems { get; set; }

    }
}
