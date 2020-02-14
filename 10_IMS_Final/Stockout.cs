using System;

namespace IMS_Final
{
    class Stockout
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Cust_ID { get; set; }
        public string Cust_Name { get; set; }
        public string Prod_ID { get; set; }
        public string Prod_Name { get; set; }
        public float Units { get; set; }
    }
}
