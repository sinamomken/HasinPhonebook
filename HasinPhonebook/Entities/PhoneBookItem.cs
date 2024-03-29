﻿namespace HasinPhonebook.Entities
{
    public class PhonebookItem
    {
        public long Id { get; set; }
        public string ItemFirstName { get; set; }
        public string? ItemLastName { get; set; }
        public string ItemPhone { get; set; }
        public string? ItemTag { get; set; }
        public Phonebook Phonebook { get; set; }
    }
}
