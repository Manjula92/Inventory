using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryModel;
using System.Web;
using InventoryDAC;
using System.Data;

namespace InventoryService
{
    public class InvService
    {
        public List<InvenModel.ResGetInvModel> GetInventoryDetails(InvenModel.ReqGetInvModel oRequest)
        {
            List<InvenModel.ResGetInvModel> lstresInv = new List<InvenModel.ResGetInvModel>();
            try
            {
                InvenModel.ResGetInvModel oInv = null;
                InvDAC objDac = new InvDAC();
                List<InvModel> lstInv = new List<InvModel>();
               
                lstInv = objDac.getInvProduct(oRequest.ProductName);
                for (int i = 0; i < lstInv.Count; i++)
                {
                    oInv = new InvenModel.ResGetInvModel();
                    oInv.InventoryID = lstInv[i].InventoryID;
                    oInv.ProductName = lstInv[i].ProductName;
                    oInv.QtyIn = lstInv[i].QtyIn;
                    oInv.QtyOut = lstInv[i].QtyOut;
                    lstresInv.Add(oInv);
                }
               
            }
            catch (Exception ex)
            {

            }
            return lstresInv;
        }

        public InvenModel.ResGetInvModel PostInv(InvenModel.ResGetInvModel postInput)
        {
            InvenModel.ResGetInvModel ResPost = new InvenModel.ResGetInvModel();
            try
            {
                InvDAC objDac = new InvDAC();
                InvModel objin = new InvModel();
                
                object Result;
                if (postInput != null)
                {

                    objin.ProductName = postInput.ProductName;
                    objin.QtyIn = postInput.QtyIn;
                    objin.QtyOut = postInput.QtyOut;

                }
                ResPost.InventoryID = objDac.pInsertInv(objin, out Result);
            }
            catch (Exception ex)
            {

            }
            return ResPost;
        }

        public InvenModel.ResGetInvModel UpdateInv(InvenModel.ResGetInvModel putInput)
        {
            InvenModel.ResGetInvModel ResPost = new InvenModel.ResGetInvModel();
            try
            {
                InvDAC objDac = new InvDAC();
                InvModel objin = new InvModel();

                object Result;
                if (putInput != null)
                {
                    objin.InventoryID = putInput.InventoryID;
                    objin.ProductName = putInput.ProductName;
                    objin.QtyIn = putInput.QtyIn;
                    objin.QtyOut = putInput.QtyOut;

                }
             //   ResPost.InventoryID = objDac.pInsertInv(objin, out Result);
            }
            catch (Exception ex)
            {

            }
            return ResPost;
        }
    }

}
