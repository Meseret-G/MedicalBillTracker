namespace MedicalBillTracker.Models
{
    public class Invoice
    {

        public int InvoiceId { get; set; }
        public string Title { get; set; }
        public string Provider { get; set; }
        public string ImageURL { get; set; }
        public decimal OutOfPocket { get; set; }
        public string Description { get; set; }

    }
}
