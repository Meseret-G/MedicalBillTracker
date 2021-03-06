using MedicalBillTracker.Models;

namespace MedicalBillTracker.Repos
{
    public interface IBillRepo
    {
    List<Bill> GetAll();
     Bill? GetBillById(int id);
      void AddBill(Bill bill);
        void UpdateBill(int id, Bill bill);
        void DeleteBill(int id);
        void ArchiveBill(int id, Bill bill);
        public List<Bill> GetArchiveBills();
        void DeleteArchiveBill(int id);

    }

}

