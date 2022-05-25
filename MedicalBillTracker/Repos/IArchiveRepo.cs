using MedicalBillTracker.Models;

namespace MedicalBillTracker.Repos
{
    public interface IArchiveRepo
    {

        public List<Archive> GetAllArchivesByUID(string uid);
        public List<Archive> GetAllArchives();
    }
}
