using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iceland_shopkeeper.Model
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string Name { get; set; }
        public int QualityInput { get; set; }
        public int NumersOfDaysToSellInput { get; set; }
        public int QualityOutPut { get; set; }
        public int NumersOfDaysToSellOutPut { get; set; }
        public DateTime Item_date { get; set; }


    }
}
