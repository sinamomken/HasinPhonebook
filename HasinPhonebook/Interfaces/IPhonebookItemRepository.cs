using HasinPhonebook.Entities;

namespace HasinPhonebook.Interfaces
{
    public interface IPhonebookItemRepository
    {
        List<PhonebookItem> GetAll();
        PhonebookItem GetById(int id);
        PhonebookItem GetByItemTag(string itemTag);
        bool ItemExists(int id);
    }
}
