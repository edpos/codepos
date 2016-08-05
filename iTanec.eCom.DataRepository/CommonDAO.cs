using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTanec.eCom.Services.DataManagement;
using iTanec.eCom.Services.LogManagement;

namespace iTanec.eCom.Services.Services
{
    public class CommonDAO
    {
        private const string APPID = "application_id";

        // public List<PaymentType> PaymentTypeList()
        //{
        //    // ProductLogManager.TraceWrite("Authenticate User Data Component");
        //    List<PaymentType> typeList = new List<PaymentType>();
        //    DataSet dsAppData = null;
        //    try
        //    {
        //        dsAppData = ProductDB.DBInstance.ExecuteDataSet("Sp_TEST");

        //        if (dsAppData.Tables[0].Rows.Count > 0)
        //        {
        //            typeList = dsAppData.Tables[0].AsEnumerable().Select(x => new PaymentType
        //         {
        //             PaymentTermId =(int)(x["PaymentTermId"]),
        //             PaymentTerm = (string)(x["PaymentTerm"])
        //         }).ToList();
        //        }

        //    }
        //    catch (SqlException ex)
        //    {
        //        ProductLogManager.DebugWrite(ex.Message + " " + ex.ErrorCode + "  " + ex.Number);
        //        //i = 1;
        //    }
        //    catch (Exception e)
        //    {
        //        ProductLogManager.DebugWrite(e.Message);
        //        //i = 1;
        //    }
        //    return typeList;
        //}

        //public List<PaymentAttributeModel> PaymentAttributeList(int paymentTypeId)
        //{
        //    // ProductLogManager.TraceWrite("Authenticate User Data Component");
        //    List<PaymentAttributeModel> attributeList = new List<PaymentAttributeModel>();
        //    DataSet dsAppData = null;
        //    try
        //    {
        //        dsAppData = ProductDB.DBInstance.ExecuteDataSet("Sp_TEST", paymentTypeId);

        //        if (dsAppData.Tables[0].Rows.Count > 0)
        //        {
        //            attributeList = dsAppData.Tables[0].AsEnumerable().Select(x => new PaymentAttributeModel
        //            {
        //                AttributeId = (int)(x["AttributeId"]),
        //                AttributeName = (string)(x["AttributeName"])
        //            }).ToList();
        //        }

        //    }
        //    catch (SqlException ex)
        //    {
        //        ProductLogManager.DebugWrite(ex.Message + " " + ex.ErrorCode + "  " + ex.Number);
        //        //i = 1;
        //    }
        //    catch (Exception e)
        //    {
        //        ProductLogManager.DebugWrite(e.Message);
        //        //i = 1;
        //    }
        //    return attributeList;
        //}
    }
}
