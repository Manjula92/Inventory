using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InventoryAdapter;
using InventoryService;
using InventoryModel;

namespace Inventory.Controllers
{

    public class InventoryController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet]
        [Route("api/Inventory")]

        public IHttpActionResult GetInventoryDetails([FromUri] Inventory.Models.GetInventoryModel Inventory)
        {
            object objResponse = null;
            InvAdapter oInvAdp = new InvAdapter();
            InvenModel.ReqGetInvModel objInvModel = new InvenModel.ReqGetInvModel();
            if (Inventory != null)
            {
                objInvModel.ProductName = Inventory.ProductName;

            }
            objResponse = oInvAdp.GetInventoryDetails(Request, objInvModel);

            return Content(System.Net.HttpStatusCode.OK, objResponse);

        }

        // POST api/values
        [HttpPost]
        [Route("api/Inventory")]
        public IHttpActionResult PostInventory([FromBody]InvenModel.ResGetInvModel PostInv)
        {
            if (PostInv != null)
            {
                InvAdapter oInvAdp = new InvAdapter();
                var objPostInventory = oInvAdp.PostInv(Request, PostInv);
                return Content(System.Net.HttpStatusCode.Created, objPostInventory);


            }
            return null;
        }

        // PUT api/values/5
        [HttpPut]
        [Route("api/Inventory")]
        public IHttpActionResult PutInventory([FromBody]InvenModel.ResGetInvModel PutInv)
        {
            if (PutInv != null)
            {
                InvAdapter oInvAdp = new InvAdapter();
                var objPostInventory = oInvAdp.PutInv(Request, PutInv);
                return Content(System.Net.HttpStatusCode.NoContent, objPostInventory);


            }
            return null;
        }


    }
}
