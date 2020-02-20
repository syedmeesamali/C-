using System;

namespace IMS_Final
{
    class Stockout
    {
        //public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Cust_Name { get; set; }
        public string Prod_ID { get; set; }
        public string Prod_Name { get; set; }
        public float Boxes { get; set; }
        public float Pcs { get; set; }
        public float Price { get; set; }
    }
}
