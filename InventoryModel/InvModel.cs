using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InventoryModel
{
    public class InvenModel
    {
        public class ReqGetInvModel
        {
            public string ProductName { get; set; }
        }

        public class ResGetInvModel
        {
            public int? InventoryID { get; set; }
            public string ProductName { get; set; }
            public decimal? QtyIn { get; set; }
            public decimal? QtyOut { get; set; }
            public List<ResGetInvModel> lstresinv { get; set; }
        }
    }
}
