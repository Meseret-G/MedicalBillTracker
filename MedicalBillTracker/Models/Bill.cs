namespace MedicalBillTracker.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Provider { get; set; }
        public string ImageURL { get; set; }
        public decimal OutOfPocket { get; set; }
        public bool IsArchived { get; set; }
        //public int PatientId { get; set; }

    }
}
