using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data;

namespace InventoryDAC
{
    public class InvDAC
    {
        public List<InvModel> getInvProduct(string Name)
        {
            string strcon = "Data Source=CSCINDAE752836\\SQLEXPRESS;Initial Catalog=MC_90_June;User ID=sa;Password=password-1";
            using (SqlConnection connection = new SqlConnection(strcon))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "Inventory";
                cmd.Parameters.Add("@mode", SqlDbType.Int);
                cmd.Parameters.Add("@ProductName", SqlDbType.VarChar);
                cmd.Parameters["@mode"].Value = 1;
                cmd.Parameters["@ProductName"].Value = (!string.IsNullOrEmpty(Name)) ? Name : Convert.DBNull;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                List<InvModel> lstInv = new List<InvModel>();
                DataSet ds = new DataSet();
                da.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    InvModel objinv = new InvModel();
                    objinv.ProductName = ds.Tables[0].Rows[i]["Product_Name"].ToString();
                    objinv.InventoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["Inventory_ID"]);
                    objinv.QtyIn = Convert.ToDecimal(ds.Tables[0].Rows[i]["QuantityIn"]);
                    objinv.QtyOut = Convert.ToDecimal(ds.Tables[0].Rows[i]["QuantityOut"]);
                    lstInv.Add(objinv);
                }

                return lstInv;
            }

        }
        public int pInsertInv(InvModel invdet, out object oResult)
        {
            int lnResult = 0;
            oResult = null;

            string strcon = "Data Source=CSCINDAE752836\\SQLEXPRESS;Initial Catalog=MC_90_June;User ID=sa;Password=password-1";

            using (SqlConnection sqlcon = new SqlConnection(strcon))
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand(strcon, sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Inventory";
                cmd.Parameters.Add("@mode", SqlDbType.Int);
                cmd.Parameters.Add("@ProductName", SqlDbType.VarChar);
                cmd.Parameters.Add("@QtyIn", SqlDbType.Decimal);
                cmd.Parameters.Add("@QtyOut", SqlDbType.Decimal);
                cmd.Parameters.Add("@DateCreated", SqlDbType.DateTime);
                cmd.Parameters["@mode"].Value = 2;
                cmd.Parameters["@ProductName"].Value = (!string.IsNullOrEmpty(invdet.ProductName)) ? invdet.ProductName : Convert.DBNull;
                cmd.Parameters["@QtyIn"].Value = (invdet.QtyIn.HasValue) ? invdet.QtyIn : Convert.DBNull;
                cmd.Parameters["@QtyOut"].Value = (invdet.QtyOut.HasValue) ? invdet.QtyIn : Convert.DBNull;
                cmd.Parameters["@DateCreated"].Value = DateTime.Now;



                cmd.Parameters["@InvID"].Direction = ParameterDirection.Output;



                lnResult = cmd.ExecuteNonQuery();

                if (lnResult != 0)
                {
                    oResult = cmd.Parameters["@InvID"].Value;
                }

            }



            return lnResult;
        }

        public int pUpdateInv(InvModel invdet, out object oResult)
        {
            int lnResult = 0;
            oResult = null;

            string strcon = "Data Source=CSCINDAE752836\\SQLEXPRESS;Initial Catalog=MC_90_June;User ID=sa;Password=password-1";

            using (SqlConnection sqlcon = new SqlConnection(strcon))
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand(strcon, sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Inventory";
                cmd.Parameters.Add("@mode", SqlDbType.Int);
                cmd.Parameters.Add("@InvID", SqlDbType.Int);
                cmd.Parameters.Add("@ProductName", SqlDbType.VarChar);
                cmd.Parameters.Add("@QtyIn", SqlDbType.Decimal);
                cmd.Parameters.Add("@QtyOut", SqlDbType.Decimal);
                cmd.Parameters.Add("@DateCreated", SqlDbType.DateTime);
                cmd.Parameters["@mode"].Value = 3;
                cmd.Parameters["@mode"].Value = invdet.InventoryID.HasValue ? invdet.InventoryID : Convert.DBNull;
                cmd.Parameters["@ProductName"].Value = (!string.IsNullOrEmpty(invdet.ProductName)) ? invdet.ProductName : Convert.DBNull;
                cmd.Parameters["@QtyIn"].Value = (invdet.QtyIn.HasValue) ? invdet.QtyIn : Convert.DBNull;
                cmd.Parameters["@QtyOut"].Value = (invdet.QtyOut.HasValue) ? invdet.QtyIn : Convert.DBNull;
                cmd.Parameters["@DateCreated"].Value = DateTime.Now;



                



                lnResult = cmd.ExecuteNonQuery();

                if (lnResult != 0)
                {
                    oResult = cmd.Parameters["@InvID"].Value;
                }

            }



            return lnResult;
        }
    }
}
