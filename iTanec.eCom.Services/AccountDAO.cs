using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIG.Accounting.BusinessObjects;
using UIG.Accounting.CrosscuttingServices.DataManagement;
using UIG.Accounting.CrosscuttingServices.LogManagement;

namespace UIG.Accounting.DataServices
{
    public class AccountDAO
    {
        

        public List<InvoiceModel> InvoiceList(int userId)
        {
            // ProductLogManager.TraceWrite("Authenticate User Data Component");
            List<InvoiceModel> returnList = new List<InvoiceModel>();
            DataSet dsAppData = null;
            try
            {
                int AgentId = userId;
                dsAppData = ProductDB.DBInstance.ExecuteDataSet(StoredProcConstants.GETINVOICEDETAILSLIST, AgentId); //TODO: Implement Stored Procedure and Uncomment me
                if (dsAppData.Tables[0].Rows.Count > 0)
                {
                    returnList = dsAppData.Tables[0].AsEnumerable().Select(x => new InvoiceModel
                    {
                        Premium = Convert.ToDecimal((x["Premium"])),
                        Name = (string)(x["Name"]),
                        EffectiveDate = Convert.ToDateTime((x["EffectiveDate"])),
                        EndDate = Convert.ToDateTime((x["EndDate"])),
                        BranchName = (string)(x["BranchName"]),
                        QuoteId = (Int64)(x["QuoteId"]),
                        AppId = (Int64)(x["AppId"]),
                        PolicyNumber = (string)(x["PolicyNumber"]),
                        EndorseNumber = Convert.ToString(x["EndorseNumber"]),
                        CoverageName = (string)(x["CoverageName"]),
                        CoverageTypeId = (int)(x["CoverageTypeId"])

                    }).ToList();
                }
            }
            catch (SqlException ex)
            {
                ProductLogManager.DebugWrite(ex.Message + " " + ex.ErrorCode + "  " + ex.Number);
                //i = 1;
            }
            catch (Exception e)
            {
                ProductLogManager.DebugWrite(e.Message);
                //i = 1;
            }
            return returnList;
        }

        public int SavePaymentDetails(PaymentModel paymentModel)
        {
            // ProductLogManager.TraceWrite("Authenticate User Data Component");
            int i = 0;
            try
            {

                i = Convert.ToInt32(ProductDB.DBInstance.ExecuteScalar(StoredProcConstants.SAVEPAYMENTDETAILS,paymentModel.PaymentTypeId, paymentModel.InvoiceId, paymentModel.TransactionAmount, paymentModel.PaymentDate, paymentModel.QuoteId, paymentModel.CoverageTypeId, paymentModel.CreatedBy)); //TODO: Implement Stored Procedure and Uncomment me

            }
            catch (SqlException ex)
            {
                ProductLogManager.DebugWrite(ex.Message + " " + ex.ErrorCode + "  " + ex.Number);
                i = 1;
            }
            catch (Exception e)
            {
                ProductLogManager.DebugWrite(e.Message);
                i = 1;
            }
            return i;
        }

        public int SavePaymentAttribute(PaymentModel paymentModel)
        {
            // ProductLogManager.TraceWrite("Authenticate User Data Component");
            int i = 0;
            try
            {
                foreach (var model in paymentModel.AttributeList)
                {
                    i = Convert.ToInt32(ProductDB.DBInstance.ExecuteScalar(StoredProcConstants.SAVEPAYMENTATTRIBUTES, paymentModel.PaymentId, paymentModel.PaymentTypeId, model.AttributeId, model.AttributeValue)); //TODO: Implement Stored Procedure and Uncomment me

                }

            }
            catch (SqlException ex)
            {
                ProductLogManager.DebugWrite(ex.Message + " " + ex.ErrorCode + "  " + ex.Number);
                i = 1;
            }
            catch (Exception e)
            {
                ProductLogManager.DebugWrite(e.Message);
                i = 1;
            }
            return i;
        }

        public List<PaymentDetailModel> PaymentList(int userId)
        {
            // ProductLogManager.TraceWrite("Authenticate User Data Component");
            List<PaymentDetailModel> returnList = new List<PaymentDetailModel>();
            DataSet dsAppData = null;
            try
            {
                int AgentId = userId;
                dsAppData = ProductDB.DBInstance.ExecuteDataSet(StoredProcConstants.GETPAYMENTLIST, AgentId); //TODO: Implement Stored Procedure and Uncomment me
                if (dsAppData.Tables[0].Rows.Count > 0)
                {
                    returnList = dsAppData.Tables[0].AsEnumerable().Select(x => new PaymentDetailModel
                    {
                        Premium = Convert.ToDecimal((x["Premium"])),
                        Name = (string)(x["Name"]),
                        EffectiveDate = Convert.ToDateTime((x["EffectiveDate"])),
                        EndDate = Convert.ToDateTime((x["EndDate"])),
                        BranchName = (string)(x["BranchName"]),
                        QuoteId = (Int64)(x["QuoteId"]),
                        AppId = (Int64)(x["AppId"]),
                        PolicyNumber = (string)(x["PolicyNumber"]),
                        EndorseNumber = Convert.ToString(x["EndorseNumber"]),
                        CoverageName = (string)(x["CoverageName"]),
                        CoverageTypeId = (int)(x["CoverageTypeId"]),
                        TransactionAmount = (decimal)(x["TransactionAmount"]),
                        PaymentDate = Convert.ToDateTime((x["PaymentDate"])),
                        PaymentType = (string)(x["PaymentType"])
                    }).ToList();
                }
            }
            catch (SqlException ex)
            {
                ProductLogManager.DebugWrite(ex.Message + " " + ex.ErrorCode + "  " + ex.Number);
                //i = 1;
            }
            catch (Exception e)
            {
                ProductLogManager.DebugWrite(e.Message);
                //i = 1;
            }
            return returnList;
        }
    }
}
