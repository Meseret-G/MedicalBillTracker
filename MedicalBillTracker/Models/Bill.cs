﻿namespace MedicalBillTracker.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Provider { get; set; }
        public string ImageURL { get; set; }
        public decimal OutOfPocket { get; set; }
        public DateTime BillDate { get; set; }
        public bool IsOpen { get; set; }
        public int PatientId { get; set; }

        //public int PatientId { get; set; }
    }
}
