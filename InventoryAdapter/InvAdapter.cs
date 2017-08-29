using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using InventoryModel;
using InventoryService;
namespace InventoryAdapter
{
    public class InvAdapter
    {
        public object GetInventoryDetails(System.Net.Http.HttpRequestMessage httpRequest, InvenModel.ReqGetInvModel objReqInv)
        {
            List<InvenModel.ResGetInvModel> lstresInv = null;
            try
            {

                InvService objser = new InvService();
                lstresInv = objser.GetInventoryDetails(objReqInv);

            }
            catch (Exception ex)
            {

            }
            return lstresInv;
        }
        public object PostInv(System.Net.Http.HttpRequestMessage httpRequest, InvenModel.ResGetInvModel postinput)
        {
            InvenModel.ResGetInvModel oPostInv = null;
            try
            {
                InvService objser = new InvService();
                oPostInv = objser.PostInv(postinput);
            }

            catch (Exception ex)
            {

            }
            return oPostInv;
        }

        public object PutInv(System.Net.Http.HttpRequestMessage httpRequest, InvenModel.ResGetInvModel postinput)
        {
            InvenModel.ResGetInvModel oPutInv = null;
            try
            {
                InvService objser = new InvService();
                oPutInv = objser.UpdateInv(postinput);
            }

            catch (Exception ex)
            {

            }
            return oPutInv;
        }
    }
}
