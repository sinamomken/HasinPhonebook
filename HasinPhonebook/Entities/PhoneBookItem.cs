namespace HasinPhonebook.Entities
{
    public class PhoneBookItem
    {
        public long Id { get; set; }
        public string ItemFirstName { get; set; }
        public string ItemLastName { get; set; }
        public string ItemPhone { get; set; }
        public Phonebook Phonebook { get; set; }
    }
}
