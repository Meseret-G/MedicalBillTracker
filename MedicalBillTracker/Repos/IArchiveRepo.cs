using MedicalBillTracker.Models;

namespace MedicalBillTracker.Repos
{
    public interface IArchiveRepo
    {
        // Archive Bill
        void ArchiveBills(int id);

        // Get archives bills
        List<Bill> GetArchiveBills();
    }
}
