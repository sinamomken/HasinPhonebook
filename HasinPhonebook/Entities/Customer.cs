namespace HasinPhonebook.Entities
{
    public class Customer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string IdentificationCode { get; set; }
        public List<Phonebook> Phonebooks { get; set; }
    }
}
