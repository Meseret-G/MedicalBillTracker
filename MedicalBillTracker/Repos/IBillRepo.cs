using MedicalBillTracker.Models;

namespace MedicalBillTracker.Repos
{
    public interface IBillRepo
    {
    List<Bill> GetAll();
     Bill? GetById(int id);
      void AddBill(Bill bill);

    }
}
