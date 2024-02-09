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
        public List<PhonebookItem> GetAll()
        {
            return _context.PhonebookItems.OrderBy(x => x.Id).ToList();
        }

        public PhonebookItem GetById(int id)
        {
            return _context.PhonebookItems.Where(i => i.Id == id).FirstOrDefault();
        }

        public PhonebookItem GetByItemTag(string itemTag)
        {
            return _context.PhonebookItems.Where(i => i.ItemTag == itemTag).FirstOrDefault();
        }

        public bool ItemExists(int id)
        {
            return _context.PhonebookItems.Any(i => i.Id == id);
        }
    }
}
