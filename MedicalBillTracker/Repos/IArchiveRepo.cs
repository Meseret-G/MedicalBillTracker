using MedicalBillTracker.Models;

namespace MedicalBillTracker.Repos
{
    public interface IArchiveRepo
    {

        public List<Archive> GetAllArchivesByUID(string uid);
        public List<Archive> GetAllArchives();
        public int AddNewArchive(string patientId);
        public Archive? GetOpenArchiveByUID(string uid);
        public void CloseArchive(int archiveId);

    }
}
