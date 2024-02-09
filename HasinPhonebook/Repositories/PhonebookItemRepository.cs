using AutoMapper;
using HasinPhonebook.Data;
using HasinPhonebook.Entities;
using HasinPhonebook.Interfaces;

namespace HasinPhonebook.Repositories
{
    public class PhonebookItemRepository : IPhonebookItemRepository
    {
        private readonly DataContext _context;

        public PhonebookItemRepository(DataContext context) {
            _context = context;
        }

        public bool CreatePhonebookItem(long phonebookId, PhonebookItem phonebookItem)
        {
            var phonebook = _context.Phonebooks.Where(p => p.Id == phonebookId).FirstOrDefault();
            phonebookItem.Phonebook = phonebook;
            // Change Tracker
            _context.Add(phonebookItem);
            return Save();
        }

        public bool DeletePhonebookItem(long phonebookId)
        {
            var phonebook = this.GetById(phonebookId);
            _context.Remove(phonebook);
            return Save();
        }

        public List<PhonebookItem> GetAll()
        {
            return _context.PhonebookItems.OrderBy(x => x.Id).ToList();
        }

        public PhonebookItem GetById(long id)
        {
            return _context.PhonebookItems.Where(i => i.Id == id).FirstOrDefault();
        }

        public PhonebookItem GetByItemTag(string itemTag)
        {
            return _context.PhonebookItems.Where(i => i.ItemTag == itemTag).FirstOrDefault();
        }

        public bool ItemExists(long id)
        {
            return _context.PhonebookItems.Any(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePhonebookItem(PhonebookItem phonebookItem)
        {
            _context.Update(phonebookItem);
            return Save();
        }

    }
}
