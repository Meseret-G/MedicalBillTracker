
using MedicalBillTracker.Models;

namespace MedicalBillTracker.Repos
{
    public interface IArchiveItemRepo
    {

        //public List<ArchiveItem> GetAllArchives();

        public List<Bill> GetAllPatientArchives(int PatientId);
         void AddToArchive(int id);

        public void RemoveFromArchive(int billId);
        bool BillExistInArchive(int billId); 


    }
}

