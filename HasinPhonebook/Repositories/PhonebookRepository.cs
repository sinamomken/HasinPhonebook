using HasinPhonebook.Data;
using HasinPhonebook.Entities;
using HasinPhonebook.Interfaces;

namespace HasinPhonebook.Repositories
{
    public class PhonebookRepository : IPhonebookRepository
    {
        private readonly DataContext _context;
        public PhonebookRepository(DataContext context){
            _context = context;
        }

        public List<Phonebook> GetAll()
        {
            return _context.Phonebooks.OrderBy(x => x.Id).ToList();
        }

        public Phonebook GetById(long id)
        {
            return _context.Phonebooks.Where(p => p.Id == id).FirstOrDefault();
        }

        public bool Exists(long id)
        {
            return _context.Phonebooks.Any(i => i.Id == id);
        }
    }
}
