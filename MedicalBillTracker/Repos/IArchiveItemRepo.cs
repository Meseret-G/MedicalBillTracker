
using MedicalBillTracker.Models;

namespace MedicalBillTracker.Repos
{
    public interface IArchiveItemRepo
    {
        public List<Bill> GetAllItemsByArchiveId(int id); 
        public void AddArchiveItem(ArchiveItem item);
        public void DeleteArchiveItem(int archiveItemId);
        public ArchiveItem ArchiveItemExists(int billId, int archiveId);

    }
}

