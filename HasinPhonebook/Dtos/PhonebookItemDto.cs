namespace HasinPhonebook.Dtos
{
    public class PhonebookItemDto
    {
        public long? Id { get; set; }
        public string ItemFirstName { get; set; }
        public string? ItemLastName { get; set; }
        public string ItemPhone { get; set; }
        public string? ItemTag { get; set; }
    }
}
