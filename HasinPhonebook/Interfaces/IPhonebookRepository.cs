using HasinPhonebook.Entities;

namespace HasinPhonebook.Interfaces
{
    public interface IPhonebookRepository
    {
        List<Phonebook> GetAll();
        Phonebook GetById(long id);
        bool Exists(long id);
    }
}
