using System;
namespace IMS_Final
{
    class Stockin
    {
        //public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Sup_ID { get; set; }
        public string Sup_Name { get; set; }
        public string Prod_ID { get; set; }
        public string Prod_Name { get; set; }
        public DateTime Expiry { get; set; }
        public float Units { get; set; }
    }
}
