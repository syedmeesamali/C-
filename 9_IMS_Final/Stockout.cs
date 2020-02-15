using System;
using System.ComponentModel.DataAnnotations;


namespace IMS_Final
{
    class Stockout
    {
        [Key]
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Cust_Name { get; set; }
        public string Prod_ID { get; set; }
        public string Prod_Name { get; set; }
        public float Units { get; set; }
    }
}
