using MedicalBillTracker.Models;

namespace medicalbilltracker.models
{
    public class BillArchiveItem : Bill
    {
        public int BillReceived { get; internal set; }
    }
}
