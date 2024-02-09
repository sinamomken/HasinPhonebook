using HasinPhonebook.Entities;

namespace HasinPhonebook.Interfaces
{
    public interface IPhonebookItemRepository
    {
        List<PhonebookItem> GetAll();
        PhonebookItem GetById(long id);
        PhonebookItem GetByItemTag(string itemTag);
        bool ItemExists(long id);
        bool CreatePhonebookItem(long phonebookId, PhonebookItem phonebookItem);
        bool UpdatePhonebookItem(PhonebookItem phonebookItem);
        bool DeletePhonebookItem(long phonebookId);
        bool Save();
    }
}
