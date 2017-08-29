using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDAC
{
    public class InvModel
    {
        public int? InventoryID { get; set; }
        public string ProductName { get; set; }
        public decimal? QtyIn { get; set; }
        public decimal? QtyOut { get; set; }
        //public DateTime createddate { get; set; }
        public List<InvModel> lstInv { get; set; }

    }
}
