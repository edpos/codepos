using UIG.Accounting.BusinessObjects;
using UIG.Accounting.CrosscuttingServices.DataManagement;
using UIG.Accounting.CrosscuttingServices.LogManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace UIG.Accounting.DataServices
{
    /// <summary>
    ///Application Detail DAO class provides all Application Detail module related Data operation
    /// </summary>
    /// <history>
    ///  Author				:	Saravanan R
    ///  Creation Date		:	26/2/2014
    ///  </history>
    public class ApplicationDetailDAO
    {
        /// <summary>
        ///Insert Application Details method accepts Application object  as input and saves it to DB
        /// </summary>
        /// <returns>
        /// 0 if Success, 1 if error
        /// </returns>
        /// <history>
        ///  Author				:	Saravanan R
        ///  Creation Date		:	26/2/2014
        ///  </history>
        //public int InsertApplicationDetails(ApplicationDetails application)
        //{
        //    ProductLogManager.TraceWrite("Save Application Detail Data Component");
        //    int i = 0;

        //    try
        //    {
        //        i = Convert.ToInt32(ProductDB.DBInstance.ExecuteScalar(StoredProcConstants.SAVEAPPLICATIONDETAILS, application.SalesExec, application.Agency, application.SysApplicationNumber, application.ReceivedDate, application.LoginDate, application.CoApplicants, application.SubChannel, application.ApplicationSource, application.ASM, application.RSM,
        //          application.BM, application.ApplicationStatus, application.Branch, application.Region, application.TeleSale, application.IsLocal, application.StaffFlag, application.ReferralFlag,
        //         0, 0, application.City, application.State, application.CreatedBy, application.ApplicationId, application.Channel));
        //    }
        //    catch (SqlException ex)
        //    {
        //        ProductLogManager.DebugWrite(ex.Message + " " + ex.ErrorCode + "  " + ex.Number);
        //        i = 1;
        //    }
        //    catch (Exception e)
        //    {
        //        ProductLogManager.DebugWrite(e.Message);
        //        i = 1;
        //    }
        //    return i;
        //}

        ///// <summary>
        //// ///Update Appication Status method accepts appstatus, appid etc  as input and updates it to DB
        ///// </summary>
        ///// <returns>
        ///// 0 if Success, 1 if error
        ///// </returns>
        ///// <history>
        /////  Author				:	Saravanan R
        /////  Creation Date		:	7/10/2014
        /////  </history>
        //public int UpdateAppStatus(int appStatus, int userId, string action, int applicationId, int newAppStatus, string comments = "")
        //{
        //    ProductLogManager.TraceWrite("Update Application Status Data Component");
        //    int i = 0;
        //    try
        //    {
        //        i = ProductDB.DBInstance.ExecuteNonQuery(StoredProcConstants.UPDATEAPPLICATIONSTATUS, appStatus, applicationId, comments, userId, newAppStatus, action);
        //    }
        //    catch (SqlException ex)
        //    {
        //        ProductLogManager.DebugWrite(ex.Message + " " + ex.ErrorCode + "  " + ex.Number);
        //        i = 1;
        //    }
        //    catch (Exception e)
        //    {
        //        ProductLogManager.DebugWrite(e.Message);
        //        i = 1;
        //    }
        //    return i;
        //}

        ///// <summary>
        //// ///Get Credit Decision based on the application id by updating flag
        ///// </summary>
        ///// <returns>
        ///// 0 if Success, 1 if error
        ///// </returns>
        ///// <history>
        /////  Author				:	Saravanan R
        /////  Creation Date		:	8/10/2014
        /////  </history>
        //public int GetCreditDecision(int applicationId)
        //{
        //    ProductLogManager.TraceWrite("GetCreditDecision Status Data Component");
        //    int i = 0;
        //    try
        //    {
        //        i = ProductDB.DBInstance.ExecuteNonQuery(StoredProcConstants.UPDATEAPPLICATIONCREDIT, applicationId);
        //    }
        //    catch (SqlException ex)
        //    {
        //        ProductLogManager.DebugWrite(ex.Message + " " + ex.ErrorCode + "  " + ex.Number);
        //        i = 1;
        //    }
        //    catch (Exception e)
        //    {
        //        ProductLogManager.DebugWrite(e.Message);
        //        i = 1;
        //    }
        //    return i;
        //}

        ///// <summary>
        /////Update Application Details method accepts Application object  as input and updates it to DB
        ///// </summary>
        ///// <returns>
        ///// 0 if Success, 1 if error
        ///// </returns>
        ///// <history>
        /////  Author				:	Saravanan R
        /////  Creation Date		:	26/8/2014
        /////  </history>
        //public int UpdateApplicationDetails(ApplicationDetails application)
        //{
        //    ProductLogManager.TraceWrite("Update Application Detail Data Component");
        //    int i = 0;

        //    try
        //    {
        //        i = ProductDB.DBInstance.ExecuteNonQuery(StoredProcConstants.UPDATEAPPLICATIONDETAILS, application.SalesExec, application.Agency, application.SysApplicationNumber, application.ReceivedDate, application.LoginDate, application.CoApplicants, application.SubChannel, application.ApplicationSource, application.ASM, application.RSM,
        //          application.BM, application.ApplicationStatus, application.Branch, application.Region, application.TeleSale, application.IsLocal, application.StaffFlag, application.ReferralFlag,
        //           0, 0, application.City, application.State, application.ModifiedBy, application.ApplicationId, application.Channel);
        //    }
        //    catch (SqlException ex)
        //    {
        //        ProductLogManager.DebugWrite(ex.Message + " " + ex.ErrorCode + "  " + ex.Number);
        //        i = 1;
        //    }
        //    catch (Exception e)
        //    {
        //        ProductLogManager.DebugWrite(e.Message);
        //        i = 1;
        //    }
        //    return i;
        //}

        ///// <summary>
        /////Insert Application Product Details method accepts Application object  as input and saves it to DB
        ///// </summary>
        ///// <returns>
        ///// 0 if Success, 1 if error
        ///// </returns>
        ///// <history>
        /////  Author				:	Saravanan R
        /////  Creation Date		:	25/8/2014
        /////  </history>
        //public int InsertApplicationProductDetails(ProductDetails application)
        //{
        //    ProductLogManager.TraceWrite("Save Application Product Detail Data Component");
        //    int i = 0;
        //    try
        //    {
        //        i = ProductDB.DBInstance.ExecuteNonQuery(StoredProcConstants.SAVEAPPLICATIONPRODUCTDETAILS, application.ProductId, application.SubProductId, application.CustomerId,
        //            application.SalesCampaign, application.MarketingCamapaign, application.SalesSubProm, application.SrcRefNo, application.EStmt, application.EmailStmt, application.AccNo,
        //            application.LoanAmount, application.StmtAddress, application.DueAmount, application.LoyaltyProgram, application.LoyaltyProgramNo, application.IscreditShield,
        //            application.RepaymentMode, application.MinDue, application.Topups, application.SalesProm, application.CreatedBy, application.ApplicationId, application.Tenor, application.RepaymentFreq, application.Interest);
        //    }
        //    catch (SqlException ex)
        //    {
        //        ProductLogManager.DebugWrite(ex.Message + " " + ex.ErrorCode + "  " + ex.Number);
        //        i = 1;
        //    }
        //    catch (Exception e)
        //    {
        //        ProductLogManager.DebugWrite(e.Message);
        //        i = 1;
        //    }
        //    return i;
        //}

        ///// <summary>
        /////Update Application Product Details method accepts Application object  as input and saves it to DB
        ///// </summary>
        ///// <returns>
        ///// 0 if Success, 1 if error
        ///// </returns>
        ///// <history>
        /////  Author				:	Saravanan R
        /////  Creation Date		:	26/8/2014
        /////  </history>
        //public int UpdateApplicationProductDetails(ProductDetails application)
        //{
        //    ProductLogManager.TraceWrite("Update Application Product Detail Data Component");
        //    int i = 0;
        //    try
        //    {
        //        i = ProductDB.DBInstance.ExecuteNonQuery(StoredProcConstants.UPDATEAPPLICATIONPRODUCTDETAILS, application.ProductId, application.SubProductId, application.CustomerId,
        //            application.SalesCampaign, application.MarketingCamapaign, application.SalesSubProm, application.SrcRefNo, application.EStmt, application.EmailStmt, application.AccNo,
        //            application.LoanAmount, application.StmtAddress, application.DueAmount, application.LoyaltyProgram, application.LoyaltyProgramNo, application.IscreditShield,
        //            application.RepaymentMode, application.MinDue, application.Topups, application.SalesProm, application.CreatedBy, application.ApplicationId, application.AppProdId, application.Tenor, application.RepaymentFreq, application.Interest);
        //    }
        //    catch (SqlException ex)
        //    {
        //        ProductLogManager.DebugWrite(ex.Message + " " + ex.ErrorCode + "  " + ex.Number);
        //        i = 1;
        //    }
        //    catch (Exception e)
        //    {
        //        ProductLogManager.DebugWrite(e.Message);
        //        i = 1;
        //    }
        //    return i;
        //}

        ///// <summary>
        /////Save Eligiblity Check Details method accepts Array list consists of Min DE details  as input and saves it to DB
        ///// </summary>
        ///// <returns>
        ///// generic list of integer that contains application id and customer id
        ///// </returns>
        ///// <history>
        /////  Author				:	Saravanan R
        /////  Creation Date		:	22/5/2014
        /////  </history>
        //public List<int> SaveEligiblityCheck(ArrayList list)
        //{
        //    ProductLogManager.TraceWrite("Save Min DE Detail Data Component");
        //    List<int> i = new List<int>();
        //    int customerId = 0;
        //    int applicationId = 0;

        //    EligiblityPersonal personal = null;
        //    personal = (EligiblityPersonal)list[0];
        //    DataSet dsAppData = null;
        //    try
        //    {
        //        dsAppData = ProductDB.DBInstance.ExecuteDataSet(StoredProcConstants.SAVEELIGIBLITYDETAILS, personal.FName, personal.LName, personal.DateofBirth, personal.Gender, personal.MaritalStatus, personal.Nationality, personal.Id1Type, personal.Id1, personal.Id1Expiry, personal.CreatedBy, personal.AddressLine1, personal.AddressLine2, personal.AddressLine3, personal.City, personal.Country, personal.Postal, personal.Phone1, personal.Phone2, personal.Installments, personal.OSBalance, personal.Worth, personal.Assets, personal.AppType, personal.EmploymentType, personal.ProspectId, personal.AddrType);

        //        if (dsAppData.Tables[0].Rows.Count > 0)
        //        {
        //            customerId = Convert.ToInt32(dsAppData.Tables[0].Rows[0]["CustomerId"]);
        //            applicationId = Convert.ToInt32(dsAppData.Tables[0].Rows[0]["AppId"]);
        //        }

        //        if (personal.EmploymentType > 0 && personal.EmploymentType != 1)
        //        {
        //            EligiblityEmployment emp = new EligiblityEmployment();
        //            emp = personal.Employment;
        //            int j = ProductDB.DBInstance.ExecuteNonQuery(StoredProcConstants.SAVEELIGIBLITYEMPLOYMENTDETAILS, emp.Assets, emp.AvgCashflow, emp.BusinessTime, emp.BusType,
        //                emp.CashDays, emp.CreatedBy, emp.EntityType, emp.GrossMargin, emp.IncorporationDate, emp.IndusClass, emp.IndusMargin, emp.IndusMarginInternal, emp.InterestService,
        //                emp.IsAudited, emp.Liabs, emp.LoanPurpose, emp.NetMargin, emp.NetProfit, emp.NoofEmp, emp.Profit, customerId, applicationId, emp.Ratio, emp.SalesCurrYear,
        //                emp.SalesPrevPrevYr, emp.SalesPrevYear, emp.LendRelation, emp.BusinessSegment, emp.TotalDebts, emp.ShareEquity, emp.DebtRatio);
        //        }
        //        i.Add(customerId);
        //        i.Add(applicationId);
        //    }
        //    catch (SqlException ex)
        //    {
        //        ProductLogManager.DebugWrite(ex.Message + " " + ex.ErrorCode + "  " + ex.Number);
        //    }
        //    catch (Exception e)
        //    {
        //        ProductLogManager.DebugWrite(e.Message);
        //    }
        //    return i;
        //}

        ///// <summary>
        /////ConvertProspectToApplication method accepts application Id and user id  as input and calls SP to perform conversion
        ///// </summary>
        ///// <returns>
        ///// generic list of integer that contains application id and customer id
        ///// </returns>
        ///// <history>
        /////  Author				:	Saravanan R
        /////  Creation Date		:	11/9/2014
        /////  </history>
        //public List<int> ConvertProspectToApplication(int prospectId, int userId)
        //{
        //    ProductLogManager.TraceWrite("Convert Prospect to application data Component");
        //    List<int> i = new List<int>();
        //    int customerId = 0;
        //    int applicationId = 0;

        //    DataSet dsAppData = null;
        //    try
        //    {
        //        dsAppData = ProductDB.DBInstance.ExecuteDataSet(StoredProcConstants.CONVERTPROSPECTTOAPPLICATION, prospectId, userId);

        //        if (dsAppData.Tables[0].Rows.Count > 0)
        //        {
        //            customerId = Convert.ToInt32(dsAppData.Tables[0].Rows[0]["CustomerId"]);
        //            applicationId = Convert.ToInt32(dsAppData.Tables[0].Rows[0]["AppId"]);
        //        }
        //        i.Add(customerId);
        //        i.Add(applicationId);
        //    }
        //    catch (SqlException ex)
        //    {
        //        ProductLogManager.DebugWrite(ex.Message + " " + ex.ErrorCode + "  " + ex.Number);
        //    }
        //    catch (Exception e)
        //    {
        //        ProductLogManager.DebugWrite(e.Message);
        //    }
        //    return i;
        //}

        ///// <summary>
        /////Save Eligiblity Product Details method accepts ProductDetails   as input and saves it to DB
        ///// </summary>
        ///// <returns>
        ///// -1 if Success, 1 if error
        ///// </returns>
        ///// <history>
        /////  Author				:	Saravanan R
        /////  Creation Date		:	5/9/2014
        /////  </history>
        //public int SaveEligiblityProductDetails(EligiblityProductDetails product)
        //{
        //    ProductLogManager.TraceWrite("Save  Eligiblity Product Details Data Component");
        //    int i = 0;

        //    try
        //    {
        //        i = Convert.ToInt32(ProductDB.DBInstance.ExecuteScalar(StoredProcConstants.SAVEELIGIBLITYPRODUCTDETAILS, product.ProductId, product.DueAmount, product.MinDue, product.LoanAmount, product.ApplicationId, product.Tenor, product.Interest, product.CreatedBy, product.RepaymentFreq));

        //        if (i > 0 && product.ProductId == (int)(ProdEnum.ProductCategory)ProdEnum.ProductCategory.AutoLoan)
        //        {
        //            EligiblityAuto auto = product.AutoDetails;
        //            i = ProductDB.DBInstance.ExecuteNonQuery(StoredProcConstants.SAVEELIGIBLITYAUTODETAILS, auto.BBLTVPct, auto.Category, auto.CreatedBy, auto.DownPayment, auto.Finance,
        //                auto.FinanceType, auto.HistoricalLGDPct, auto.InvoiceVal, auto.KMs, auto.LeaseRate, auto.LoanType, auto.LTVPct, auto.LTVPctBaseCost, auto.Manufacturer, auto.Model, auto.ModelYear, auto.MonthsUse, auto.PreApproved, i, auto.RepaymentFreq, auto.Staff, auto.Tenor, auto.VehicleVariant, auto.ProspectId);
        //        }
        //        if (i > 0 && product.ProductId == (int)(ProdEnum.ProductCategory)ProdEnum.ProductCategory.MortgageLoan)
        //        {
        //            EligiblityMortgage mortgage = product.MortgageDetails;
        //            i = ProductDB.DBInstance.ExecuteNonQuery(StoredProcConstants.SAVEELIGIBLITYMORTGAGEDETAILS, mortgage.ProspectId, mortgage.Builder, mortgage.BuilderCode, mortgage.CreatedBy, mortgage.DownPayment, mortgage.Finance, mortgage.FinanceType, mortgage.IntRate, mortgage.Invoice, mortgage.MonthsUse, mortgage.OSBalance, mortgage.PreApproved, mortgage.ProjectName, mortgage.PropertyStatus, mortgage.PropertyType, mortgage.PurchasePrice,
        //                mortgage.RepaymentFreq, mortgage.Staff, mortgage.Tenor, i);
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ProductLogManager.DebugWrite(ex.Message + " " + ex.ErrorCode + "  " + ex.Number);
        //    }
        //    catch (Exception e)
        //    {
        //        ProductLogManager.DebugWrite(e.Message);
        //    }
        //    return i;
        //}

        ///// <summary>
        /////Save Eligiblity Product Details method accepts ProductDetails   as input and saves it to DB
        ///// </summary>
        ///// <returns>
        ///// -1 if Success, 1 if error
        ///// </returns>
        ///// <history>
        /////  Author				:	Saravanan R
        /////  Creation Date		:	5/9/2014
        /////  </history>
        //public int UpdateEligiblityProductDetails(EligiblityProductDetails product)
        //{
        //    ProductLogManager.TraceWrite("Update  Eligiblity Product Details Data Component");
        //    int i = 0;
        //    try
        //    {
        //        i = ProductDB.DBInstance.ExecuteNonQuery(StoredProcConstants.UPDATEELIGIBLITYPRODUCTDETAILS, product.ProductId, product.DueAmount, product.MinDue, product.LoanAmount,
        //            product.ApplicationId, product.Tenor, product.Interest, product.ModifiedBy, product.AppProdId, product.RepaymentFreq);

        //        if (product.ProductId == (int)(ProdEnum.ProductCategory)ProdEnum.ProductCategory.AutoLoan)
        //        {
        //            EligiblityAuto auto = product.AutoDetails;
        //            i = ProductDB.DBInstance.ExecuteNonQuery(StoredProcConstants.UPDATEELIGIBLITYAUTODETAILS, auto.BBLTVPct, auto.Category, auto.CreatedBy, auto.DownPayment, auto.Finance,
        //                auto.FinanceType, auto.HistoricalLGDPct, auto.InvoiceVal, auto.KMs, auto.LeaseRate, auto.LoanType, auto.LTVPct, auto.LTVPctBaseCost, auto.Manufacturer, auto.Model, auto.ModelYear, auto.MonthsUse, auto.PreApproved, product.AppProdId, auto.RepaymentFreq, auto.Staff, auto.Tenor, auto.VehicleVariant, product.ApplicationId);
        //        }
        //        if (product.ProductId == (int)(ProdEnum.ProductCategory)ProdEnum.ProductCategory.MortgageLoan)
        //        {
        //            EligiblityMortgage mortgage = product.MortgageDetails;
        //            i = ProductDB.DBInstance.ExecuteNonQuery(StoredProcConstants.UPDATEELIGIBLITYMORTGAGEDETAILS, mortgage.ProspectId, mortgage.Builder, mortgage.BuilderCode, mortgage.CreatedBy, mortgage.DownPayment, mortgage.Finance, mortgage.FinanceType, mortgage.IntRate, mortgage.Invoice, mortgage.MonthsUse, mortgage.OSBalance, mortgage.PreApproved, mortgage.ProjectName, mortgage.PropertyStatus, mortgage.PropertyType, mortgage.PurchasePrice,
        //                mortgage.RepaymentFreq, mortgage.Staff, mortgage.Tenor, product.AppProdId);
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ProductLogManager.DebugWrite(ex.Message + " " + ex.ErrorCode + "  " + ex.Number);
        //    }
        //    catch (Exception e)
        //    {
        //        ProductLogManager.DebugWrite(e.Message);
        //    }
        //    return i;
        //}

        ///// <summary>
        /////Update Eligiblity Check Details method accepts Array list consists of Min DE details  as input and updates it to DB
        ///// </summary>
        ///// <returns>
        ///// -1 if Success, 1 if error
        ///// </returns>
        ///// <history>
        /////  Author				:	Saravanan R
        /////  Creation Date		:	4/9/2014
        /////  </history>
        //public List<int> UpdateEligiblityCheck(ArrayList list)
        //{
        //    ProductLogManager.TraceWrite("Update Min DE Detail Data Component");
        //    List<int> i = new List<int>();
        //    int customerId = 0;
        //    int applicationId = 0;

        //    EligiblityPersonal personal = null;
        //    personal = (EligiblityPersonal)list[0];

        //    DataSet dsAppData = null;
        //    try
        //    {
        //        dsAppData = ProductDB.DBInstance.ExecuteDataSet(StoredProcConstants.UPDATEELIGIBLITYDETAILS, personal.FName, personal.LName, personal.DateofBirth, personal.Gender, personal.MaritalStatus, personal.Nationality, personal.Id1Type, personal.Id1, personal.Id1Expiry, personal.ModifiedBy, personal.AddressLine1, personal.AddressLine2, personal.AddressLine3, personal.City, personal.Country, personal.Postal, personal.Phone1, personal.Phone2, personal.Installments, personal.OSBalance, personal.Worth, personal.Assets, personal.AppType, personal.EmploymentType, personal.ProspectId, personal.CustomerId, personal.AddrType);

        //        if (dsAppData.Tables[0].Rows.Count > 0)
        //        {
        //            customerId = Convert.ToInt32(dsAppData.Tables[0].Rows[0]["CustomerId"]);
        //            applicationId = Convert.ToInt32(dsAppData.Tables[0].Rows[0]["AppId"]);
        //        }

        //        if (personal.EmploymentType > 0 && personal.EmploymentType != 1)
        //        {
        //            EligiblityEmployment emp = new EligiblityEmployment();
        //            emp = personal.Employment;
        //            int j = ProductDB.DBInstance.ExecuteNonQuery(StoredProcConstants.UPDATEELIGIBLITYEMPLOYMENTDETAILS, emp.Assets, emp.AvgCashflow, emp.BusinessTime, emp.BusType,
        //                emp.CashDays, emp.ModifiedBy, emp.EntityType, emp.GrossMargin, emp.IncorporationDate, emp.IndusClass, emp.IndusMargin, emp.IndusMarginInternal, emp.InterestService,
        //                emp.IsAudited, emp.Liabs, emp.LoanPurpose, emp.NetMargin, emp.NetProfit, emp.NoofEmp, emp.Profit, customerId, applicationId, emp.Ratio, emp.SalesCurrYear,
        //                emp.SalesPrevPrevYr, emp.SalesPrevYear, emp.LendRelation, emp.BusinessSegment, emp.TotalDebts, emp.ShareEquity, emp.DebtRatio, emp.CreatedBy);
        //        }
        //        i.Add(customerId);
        //        i.Add(applicationId);
        //    }
        //    catch (SqlException ex)
        //    {
        //        ProductLogManager.DebugWrite(ex.Message + " " + ex.ErrorCode + "  " + ex.Number);
        //    }
        //    catch (Exception e)
        //    {
        //        ProductLogManager.DebugWrite(e.Message);
        //    }
        //    return i;
        //}

        ///// <summary>
        /////Get Search Details method returns searched data based on search parameter and value
        ///// </summary>
        ///// <returns>
        ///// generic list of searchresult
        ///// </returns>
        ///// <history>
        /////  Author				:	Saravanan R
        /////  Creation Date		:	4/4/2014
        /////  </history>
        //public List<SearchResult> GetSearchResults(int searchOption = 0, int productId = 0, string searchValue = "", string userId = "")
        //{
        //    ProductLogManager.TraceWrite("Get Search Results Data Component");
        //    List<SearchResult> searchResults = null;
        //    DataSet dsSearchResults = null;
        //    ProductLogManager.TraceWrite("UserId " + userId);
        //    try
        //    {
        //        if (searchValue != "" && productId != 99)
        //            dsSearchResults = ProductDB.DBInstance.ExecuteDataSet(StoredProcConstants.GETSEARCHRESULT, productId, searchValue, searchOption, Convert.ToInt32(userId));
        //        else if (productId == 99 && searchValue != "")
        //            dsSearchResults = ProductDB.DBInstance.ExecuteDataSet(StoredProcConstants.GETCUSTOMERSEARCH, searchValue, searchOption);
        //        searchResults = dsSearchResults.Tables[0].AsEnumerable().Select(x => new SearchResult
        //        {
        //            FirstName = (string)(x["FName"]),
        //            MiddleName = !string.IsNullOrEmpty(x["MName"].ToString()) ? (x["MName"].ToString()) : "",
        //            LastName = (string)(x["LName"]),
        //            ApplicationId = (Int32)(x["ApplicationId"]),
        //            ApplicationStatus = (Int16)(x["ApplicationStatus"]),
        //            ApplicationNumber = (string)(x["SysApplicationNumber"]),
        //            //       Category = (Int16)(x["Category"]),
        //            BusinessName = !string.IsNullOrEmpty(x["BusinessName"].ToString()) ? (x["BusinessName"].ToString()) : "",
        //            Id = !string.IsNullOrEmpty(x["OtherId1"].ToString()) ? (x["OtherId1"].ToString()) : "",
        //            DOB = (DateTime)((!string.IsNullOrEmpty(x["DOB"].ToString()) ? x["DOB"] : null)),
        //            MobileNo = !string.IsNullOrEmpty(x["MobileNo"].ToString()) ? (x["MobileNo"].ToString()) : "",
        //            CustomerId = (Int32)(x["CustomerId"]),
        //            PassportNo = !string.IsNullOrEmpty(x["PassportNo"].ToString()) ? (x["PassportNo"].ToString()) : "",
        //            UpdatedOn = (DateTime?)((!string.IsNullOrEmpty(x["UpdatedOn"].ToString()) ? x["UpdatedOn"] : null)),
        //        }
        //            ).ToList();
        //    }
        //    catch (SqlException ex)
        //    {
        //        ProductLogManager.DebugWrite(ex.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        ProductLogManager.DebugWrite(e.Message);
        //    }
        //    return searchResults;
        //}

        ///// <summary>
        /////Get Eligiblity Product Details method accepts prospectId as input and returns matches
        ///// </summary>
        ///// <returns>
        ///// generic list of product Details
        ///// </returns>
        ///// <history>
        /////  Author				:	Saravanan R
        /////  Creation Date		:	5/9/2014
        /////  </history>
        //public List<EligiblityProductDetails> GetEligiblityProductDetails(int prospectId)
        //{
        //    ProductLogManager.TraceWrite("Get Eligiblity Product details Data Component");
        //    List<EligiblityProductDetails> eligiblityProdDetails = null;
        //    List<EligiblityAuto> autoDetails = null;
        //    List<EligiblityMortgage> mortgageDetails = null;
        //    DataSet dsEligiblityDetails = null;
        //    try
        //    {
        //        dsEligiblityDetails = ProductDB.DBInstance.ExecuteDataSet(StoredProcConstants.GETELIGIBLITYPRODUCTDETAILBYPROSPECTID, prospectId);
        //        if (dsEligiblityDetails != null && dsEligiblityDetails.Tables.Count > 0)
        //        {
        //            eligiblityProdDetails = dsEligiblityDetails.Tables[0].AsEnumerable().Select(x => new EligiblityProductDetails
        //            {
        //                ApplicationId = (Int32)(x["ProspectId"]),
        //                ProductId = (Int16)(x["ProductType"]),
        //                AppProdId = (Int32)(x["ProspectProductRef"]),
        //                Interest = !string.IsNullOrEmpty(x["Interest"].ToString()) ? (decimal?)(x["Interest"]) : null,
        //                DueAmount = !string.IsNullOrEmpty(x["InstallmentAmount"].ToString()) ? (decimal?)(x["InstallmentAmount"]) : null,
        //                MinDue = !string.IsNullOrEmpty(x["DownPayment"].ToString()) ? (decimal?)(x["DownPayment"]) : null,
        //                Tenor = !string.IsNullOrEmpty(x["Tenor"].ToString()) ? (Int16?)(x["Tenor"]) : null,
        //                LoanAmount = !string.IsNullOrEmpty(x["LoanAmount"].ToString()) ? (decimal?)(x["LoanAmount"]) : null,
        //                CreatedOn = (DateTime)(x["CreatedOn"]),
        //                CreatedBy = Convert.ToString(x["CreatedBy"]),
        //            }
        //            ).ToList();
        //            if (dsEligiblityDetails.Tables.Count > 1 && dsEligiblityDetails.Tables[1].Rows.Count > 0)
        //            {
        //                autoDetails = dsEligiblityDetails.Tables[1].AsEnumerable().Select(z => new EligiblityAuto
        //                {
        //                    ProspectProductRef = (Int32)(z["ProspectProductRef"]),
        //                    Finance = !string.IsNullOrWhiteSpace(z["Finance"].ToString()) ? Convert.ToDecimal(z["Finance"]) : (decimal?)null,
        //                    Manufacturer = !string.IsNullOrWhiteSpace(z["Manufacturer"].ToString()) ? Convert.ToInt16(z["Manufacturer"]) : (Int16?)null,
        //                    Category = !string.IsNullOrWhiteSpace(z["Category"].ToString()) ? Convert.ToInt16(z["Category"]) : (Int16?)null,
        //                    Model = !string.IsNullOrWhiteSpace(z["Model"].ToString()) ? Convert.ToInt16(z["Model"]) : (Int16?)null,
        //                    Tenor = !string.IsNullOrWhiteSpace(z["Tenor"].ToString()) ? Convert.ToInt16(z["Tenor"]) : (Int16?)null,
        //                    VehicleVariant = !string.IsNullOrWhiteSpace(z["VehicleVariant"].ToString()) ? Convert.ToInt16(z["VehicleVariant"]) : (Int16?)null,
        //                    DownPayment = !string.IsNullOrWhiteSpace(z["DownPayment"].ToString()) ? Convert.ToDecimal(z["DownPayment"]) : (decimal?)null,
        //                    LoanType = !string.IsNullOrWhiteSpace(z["LoanType"].ToString()) ? Convert.ToInt16(z["LoanType"]) : (Int16?)null,
        //                    LTVPct = !string.IsNullOrWhiteSpace(z["LTVPct"].ToString()) ? Convert.ToDecimal(z["LTVPct"]) : (decimal?)null,
        //                    BBLTVPct = !string.IsNullOrWhiteSpace(z["BBLTVPct"].ToString()) ? Convert.ToDecimal(z["BBLTVPct"]) : (decimal?)null,
        //                    KMs = !string.IsNullOrWhiteSpace(z["Kms"].ToString()) ? Convert.ToInt16(z["Kms"]) : (Int16?)null,
        //                    LTVPctBaseCost = !string.IsNullOrWhiteSpace(z["LTVPctBaseCost"].ToString()) ? Convert.ToDecimal(z["LTVPctBaseCost"]) : (decimal?)null,
        //                    HistoricalLGDPct = !string.IsNullOrWhiteSpace(z["HistoricalLGDPct"].ToString()) ? Convert.ToDecimal(z["HistoricalLGDPct"]) : (decimal?)null,
        //                    ModelYear = !string.IsNullOrWhiteSpace(z["ModelYear"].ToString()) ? Convert.ToInt16(z["ModelYear"]) : (Int16?)null,
        //                    Staff = !string.IsNullOrWhiteSpace(z["Staff"].ToString()) ? Convert.ToInt16(z["Staff"]) : (Int16?)null,
        //                    FinanceType = !string.IsNullOrWhiteSpace(z["FinanceType"].ToString()) ? Convert.ToInt16(z["FinanceType"]) : (Int16?)null,
        //                    MonthsUse = !string.IsNullOrWhiteSpace(z["MonthsUse"].ToString()) ? Convert.ToInt16(z["MonthsUse"]) : (Int16?)null,
        //                    RepaymentFreq = !string.IsNullOrWhiteSpace(z["RepaymentFreq"].ToString()) ? Convert.ToInt16(z["RepaymentFreq"]) : (Int16?)null,
        //                    InvoiceVal = !string.IsNullOrWhiteSpace(z["InvoiceVal"].ToString()) ? Convert.ToDecimal(z["InvoiceVal"]) : (decimal?)null,
        //                    PreApproved = !string.IsNullOrWhiteSpace(z["Preapproved"].ToString()) ? Convert.ToInt16(z["Preapproved"]) : (Int16?)null,
        //                    LeaseRate = !string.IsNullOrWhiteSpace(z["LeaseRate"].ToString()) ? Convert.ToDecimal(z["LeaseRate"]) : (decimal?)null,
        //                }
        //                ).ToList();
        //            }
        //            if (dsEligiblityDetails.Tables.Count > 2 && dsEligiblityDetails.Tables[2].Rows.Count > 0)
        //            {
        //                mortgageDetails = dsEligiblityDetails.Tables[2].AsEnumerable().Select(z => new EligiblityMortgage
        //                {
        //                    ProspectProductRef = (Int32)(z["ProspectProductRef"]),
        //                    ProspectId = (Int32)(z["ProspectId"]),
        //                    Finance = !string.IsNullOrWhiteSpace(z["Finance"].ToString()) ? Convert.ToDecimal(z["Finance"]) : (decimal?)null,
        //                    Builder = !string.IsNullOrWhiteSpace(z["Builder"].ToString()) ? Convert.ToInt16(z["Builder"]) : (Int16?)null,
        //                    PropertyStatus = !string.IsNullOrWhiteSpace(z["PropertyStatus"].ToString()) ? Convert.ToInt16(z["PropertyStatus"]) : (Int16?)null,
        //                    PropertyType = !string.IsNullOrWhiteSpace(z["PropertyType"].ToString()) ? Convert.ToInt16(z["PropertyType"]) : (Int16?)null,
        //                    Tenor = !string.IsNullOrWhiteSpace(z["Tenor"].ToString()) ? Convert.ToInt16(z["Tenor"]) : (Int16?)null,
        //                    DownPayment = !string.IsNullOrWhiteSpace(z["DownPayment"].ToString()) ? Convert.ToDecimal(z["DownPayment"]) : (decimal?)null,
        //                    PurchasePrice = !string.IsNullOrWhiteSpace(z["PurchasePrice"].ToString()) ? Convert.ToDecimal(z["PurchasePrice"]) : (decimal?)null,
        //                    OSBalance = !string.IsNullOrWhiteSpace(z["OSPrice"].ToString()) ? Convert.ToDecimal(z["OSPrice"]) : (decimal?)null,
        //                    MonthsUse = !string.IsNullOrWhiteSpace(z["MonthsUse"].ToString()) ? Convert.ToInt16(z["MonthsUse"]) : (Int16?)null,
        //                    Staff = !string.IsNullOrWhiteSpace(z["Staff"].ToString()) ? Convert.ToInt16(z["Staff"]) : (Int16?)null,
        //                    FinanceType = !string.IsNullOrWhiteSpace(z["FinanceType"].ToString()) ? Convert.ToInt16(z["FinanceType"]) : (Int16?)null,
        //                    RepaymentFreq = !string.IsNullOrWhiteSpace(z["RepaymentFreq"].ToString()) ? Convert.ToInt16(z["RepaymentFreq"]) : (Int16?)null,
        //                    Invoice = !string.IsNullOrWhiteSpace(z["InvoiceVal"].ToString()) ? Convert.ToDecimal(z["InvoiceVal"]) : (decimal?)null,
        //                    PreApproved = !string.IsNullOrWhiteSpace(z["Preapproved"].ToString()) ? Convert.ToInt16(z["Preapproved"]) : (Int16?)null,
        //                    IntRate = !string.IsNullOrWhiteSpace(z["IntRate"].ToString()) ? Convert.ToDecimal(z["IntRate"]) : (decimal?)null,
        //                    ProjectName = (z["ProjectName"].ToString()),
        //                    BuilderCode = (z["Builder"].ToString()),
        //                }
        //                ).ToList();
        //            }
        //            foreach (EligiblityProductDetails prod in eligiblityProdDetails)
        //            {
        //                if (autoDetails != null)
        //                    prod.AutoDetails = autoDetails
        //                            .Where(x => x.ProspectProductRef == prod.AppProdId).FirstOrDefault();
        //                if (mortgageDetails != null)
        //                    prod.MortgageDetails = mortgageDetails
        //                           .Where(y => y.ProspectProductRef == prod.AppProdId).FirstOrDefault();
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ProductLogManager.DebugWrite(ex.Message + ex.InnerException + ex.StackTrace);
        //    }
        //    catch (Exception e)
        //    {
        //        ProductLogManager.DebugWrite(e.Message + e.InnerException + e.StackTrace);
        //    }
        //    return eligiblityProdDetails;
        //}

        ///// <summary>
        /////Get Eligiblity Details method returns  data based on prospect id
        ///// </summary>
        ///// <returns>
        /////instance of Eligiblity Details
        ///// </returns>
        ///// <history>
        /////  Author				:	Saravanan R
        /////  Creation Date		:	4/9/2014
        /////  </history>
        //public EligiblityDetails GetEligiblityDetailById(int prospectId)
        //{
        //    ProductLogManager.TraceWrite("Get Eligiblity details by id Data Component");
        //    EligiblityDetails eligiblityDetails = new EligiblityDetails();
        //    List<EligiblityPersonal> personals = null;
        //    List<EligiblityEmployment> employments = new List<EligiblityEmployment>();
        //    DataSet dsEligiblityDetails = null;
        //    try
        //    {
        //        dsEligiblityDetails = ProductDB.DBInstance.ExecuteDataSet(StoredProcConstants.GETELIGIBLITYDETAILBYID, prospectId);
        //        if (dsEligiblityDetails != null && dsEligiblityDetails.Tables.Count > 0)
        //        {
        //            eligiblityDetails = new EligiblityDetails
        //            {
        //                SalesExec = !string.IsNullOrEmpty(dsEligiblityDetails.Tables[0].Rows[0]["SalesExecId"].ToString()) ? (Int16?)(dsEligiblityDetails.Tables[0].Rows[0]["SalesExecId"]) : null,
        //                Agency = !string.IsNullOrEmpty(dsEligiblityDetails.Tables[0].Rows[0]["AgencyId"].ToString()) ? (Int16?)(dsEligiblityDetails.Tables[0].Rows[0]["AgencyId"]) : null,
        //                NoofApp = !string.IsNullOrEmpty(dsEligiblityDetails.Tables[0].Rows[0]["Noofapplicants"].ToString()) ? (Int16?)(dsEligiblityDetails.Tables[0].Rows[0]["Noofapplicants"]) : null,
        //                ReceivedDate = (DateTime?)((!string.IsNullOrEmpty(dsEligiblityDetails.Tables[0].Rows[0]["ReceivedDate"].ToString()) ? dsEligiblityDetails.Tables[0].Rows[0]["ReceivedDate"] : null)),
        //                ModifiedOn = (DateTime?)((!string.IsNullOrEmpty(dsEligiblityDetails.Tables[0].Rows[0]["UpdatedOn"].ToString()) ? dsEligiblityDetails.Tables[0].Rows[0]["UpdatedOn"] : null)),
        //                CreatedOn = (DateTime)((!string.IsNullOrEmpty(dsEligiblityDetails.Tables[0].Rows[0]["CreatedOn"].ToString()) ? dsEligiblityDetails.Tables[0].Rows[0]["CreatedOn"] : null)),
        //                CreatedBy = !string.IsNullOrEmpty(dsEligiblityDetails.Tables[0].Rows[0]["CreatedBy"].ToString()) ? (dsEligiblityDetails.Tables[0].Rows[0]["CreatedBy"].ToString()) : "",
        //                ModifiedBy = !string.IsNullOrEmpty(dsEligiblityDetails.Tables[0].Rows[0]["UpdatedBy"].ToString()) ? (dsEligiblityDetails.Tables[0].Rows[0]["UpdatedBy"].ToString()) : "",
        //                IsAppConverted = Convert.ToBoolean(dsEligiblityDetails.Tables[0].Rows[0]["IsAppConverted"].ToString()),
        //                IsCredit = Convert.ToBoolean(dsEligiblityDetails.Tables[0].Rows[0]["IsCreditValidated"].ToString()),
        //            };
        //            if (dsEligiblityDetails.Tables.Count > 1 && dsEligiblityDetails.Tables[1].Rows.Count > 0)
        //            {
        //                personals = dsEligiblityDetails.Tables[1].AsEnumerable().Select(x => new EligiblityPersonal
        //                {
        //                    CustomerId = (Int32)(x["ProspectCustomerRef"]),
        //                    ProspectId = (Int32)(x["ProspectId"]),
        //                    FName = !string.IsNullOrEmpty(x["FName"].ToString()) ? (x["FName"].ToString()) : "",
        //                    LName = !string.IsNullOrEmpty(x["LName"].ToString()) ? (x["LName"].ToString()) : "",
        //                    Gender = !string.IsNullOrEmpty(x["Gender"].ToString()) ? (x["Gender"].ToString()) : "",
        //                    Id1Type = (Int16)(x["IdType"]),
        //                    Nationality = !string.IsNullOrEmpty(x["Nationality"].ToString()) ? (Int16?)(x["Nationality"]) : null,
        //                    EmploymentType = !string.IsNullOrEmpty(x["EmploymentType"].ToString()) ? (Int16?)(x["EmploymentType"]) : null,
        //                    AppType = !string.IsNullOrEmpty(x["ApplicantType"].ToString()) ? (Int16?)(x["ApplicantType"]) : null,
        //                    DateofBirth = !string.IsNullOrEmpty(x["DOB"].ToString()) ? (DateTime?)(x["DOB"]) : null,
        //                    MaritalStatus = !string.IsNullOrEmpty(x["MaritalStatus"].ToString()) ? (Int16?)(x["MaritalStatus"]) : null,
        //                    Id1 = !string.IsNullOrEmpty(x["IdNo"].ToString()) ? (x["IdNo"].ToString()) : "",
        //                    Id1Expiry = !string.IsNullOrEmpty(x["IdExpiry"].ToString()) ? (DateTime?)(x["IdExpiry"]) : null,
        //                    Assets = !string.IsNullOrEmpty(x["Assets"].ToString()) ? (decimal?)(x["Assets"]) : null,
        //                    Worth = !string.IsNullOrEmpty(x["Worth"].ToString()) ? (decimal?)(x["Worth"]) : null,
        //                    OSBalance = !string.IsNullOrEmpty(x["OSBalance"].ToString()) ? (decimal?)(x["OSBalance"]) : null,
        //                    Installments = !string.IsNullOrEmpty(x["Installments"].ToString()) ? (decimal?)(x["Installments"]) : null,
        //                    AddressLine1 = !string.IsNullOrEmpty(x["AddressLine1"].ToString()) ? (x["AddressLine1"].ToString()) : "",
        //                    AddressLine2 = !string.IsNullOrEmpty(x["AddressLine2"].ToString()) ? (x["AddressLine2"].ToString()) : "",
        //                    AddressLine3 = !string.IsNullOrEmpty(x["AddressLine3"].ToString()) ? (x["AddressLine3"].ToString()) : "",
        //                    AddrType = !string.IsNullOrEmpty(x["AddressType"].ToString()) ? (x["AddressType"].ToString()) : "",
        //                    Postal = !string.IsNullOrEmpty(x["Postal"].ToString()) ? (x["Postal"].ToString()) : "",
        //                    Country = (Int16?)((!string.IsNullOrEmpty(x["Country"].ToString()) ? x["Country"] : null)),
        //                    City = (Int16?)((!string.IsNullOrEmpty(x["City"].ToString()) ? x["City"] : null)),
        //                    CreatedOn = (DateTime)(x["CreatedOn"]),
        //                    CreatedBy = Convert.ToString(x["CreatedBy"]),
        //                    Phone1 = !string.IsNullOrEmpty(x["Phone1"].ToString()) ? (x["Phone1"].ToString()) : "",
        //                    Phone2 = !string.IsNullOrEmpty(x["Phone2"].ToString()) ? (x["Phone2"].ToString()) : "",
        //                }
        //                ).ToList();
        //            }
        //            if (dsEligiblityDetails.Tables.Count > 2 && dsEligiblityDetails.Tables[2].Rows.Count > 0)
        //            {
        //                employments = dsEligiblityDetails.Tables[2].AsEnumerable().Select(z => new EligiblityEmployment
        //                {
        //                    ProspectCustomerRef = (Int32)(z["ProspectCustomerRef"]),
        //                    ProspectId = (Int32)(z["ProspectCustomerRef"]),
        //                    Assets = !string.IsNullOrWhiteSpace(z["Assets"].ToString()) ? Convert.ToDecimal(z["Assets"]) : (decimal?)null,
        //                    AvgCashflow = !string.IsNullOrWhiteSpace(z["AvgCashflow"].ToString()) ? Convert.ToDecimal(z["AvgCashflow"]) : (decimal?)null,
        //                    BusinessTime = !string.IsNullOrWhiteSpace(z["BusinessTime"].ToString()) ? Convert.ToInt16(z["BusinessTime"]) : (Int16?)null,
        //                    BusType = !string.IsNullOrWhiteSpace(z["BusType"].ToString()) ? Convert.ToInt16(z["BusType"]) : (Int16?)null,
        //                    CashDays = !string.IsNullOrWhiteSpace(z["CashDays"].ToString()) ? Convert.ToInt16(z["CashDays"]) : (Int16?)null,
        //                    EntityType = !string.IsNullOrWhiteSpace(z["EntityType"].ToString()) ? Convert.ToInt16(z["EntityType"]) : (Int16?)null,
        //                    GrossMargin = !string.IsNullOrWhiteSpace(z["GrossMargin"].ToString()) ? Convert.ToDecimal(z["GrossMargin"]) : (decimal?)null,
        //                    IncorporationDate = !string.IsNullOrWhiteSpace(z["IncorporationDate"].ToString()) ? Convert.ToDateTime(z["IncorporationDate"]) : (DateTime?)null,
        //                    IndusClass = !string.IsNullOrWhiteSpace(z["IndusClass"].ToString()) ? Convert.ToInt16(z["IndusClass"]) : (Int16?)null,
        //                    IndusMargin = !string.IsNullOrWhiteSpace(z["IndusMargin"].ToString()) ? Convert.ToDecimal(z["IndusMargin"]) : (decimal?)null,
        //                    IndusMarginInternal = !string.IsNullOrWhiteSpace(z["IndusMarginInternal"].ToString()) ? Convert.ToDecimal(z["IndusMarginInternal"]) : (decimal?)null,
        //                    InterestService = z["InterestService"].ToString(),
        //                    IsAudited = !string.IsNullOrWhiteSpace(z["AuditedFinancial"].ToString()) ? Convert.ToBoolean(z["AuditedFinancial"]) : (bool?)null,
        //                    Liabs = !string.IsNullOrWhiteSpace(z["Liabs"].ToString()) ? Convert.ToDecimal(z["Liabs"]) : (decimal?)null,
        //                    LoanPurpose = !string.IsNullOrWhiteSpace(z["LoanPurpose"].ToString()) ? Convert.ToInt16(z["LoanPurpose"]) : (Int16?)null,
        //                    NetMargin = !string.IsNullOrWhiteSpace(z["NetMargin"].ToString()) ? Convert.ToDecimal(z["NetMargin"]) : (decimal?)null,
        //                    NetProfit = !string.IsNullOrWhiteSpace(z["NetProfit"].ToString()) ? Convert.ToDecimal(z["NetProfit"]) : (decimal?)null,
        //                    NoofEmp = !string.IsNullOrWhiteSpace(z["NoofEmp"].ToString()) ? Convert.ToInt16(z["NoofEmp"]) : (Int16?)null,
        //                    Profit = !string.IsNullOrWhiteSpace(z["Profit"].ToString()) ? Convert.ToDecimal(z["Profit"]) : (decimal?)null,
        //                    Ratio = !string.IsNullOrWhiteSpace(z["Ratio"].ToString()) ? Convert.ToDecimal(z["Ratio"]) : (decimal?)null,
        //                    SalesCurrYear = !string.IsNullOrWhiteSpace(z["SalesCurrYear"].ToString()) ? Convert.ToDecimal(z["SalesCurrYear"]) : (decimal?)null,
        //                    SalesPrevPrevYr = !string.IsNullOrWhiteSpace(z["SalesPrevPrevYr"].ToString()) ? Convert.ToDecimal(z["SalesPrevPrevYr"]) : (decimal?)null,
        //                    SalesPrevYear = !string.IsNullOrWhiteSpace(z["SalesPrevYear"].ToString()) ? Convert.ToDecimal(z["SalesPrevYear"]) : (decimal?)null,
        //                    DebtRatio = !string.IsNullOrWhiteSpace(z["DebtRatio"].ToString()) ? Convert.ToDecimal(z["DebtRatio"]) : (decimal?)null,
        //                    ShareEquity = !string.IsNullOrWhiteSpace(z["ShareEquity"].ToString()) ? Convert.ToDecimal(z["ShareEquity"]) : (decimal?)null,
        //                    TotalDebts = !string.IsNullOrWhiteSpace(z["TotalDebts"].ToString()) ? Convert.ToDecimal(z["TotalDebts"]) : (decimal?)null,
        //                    BusinessSegment = !string.IsNullOrWhiteSpace(z["BusinessSegment"].ToString()) ? Convert.ToInt16(z["BusinessSegment"]) : (Int16?)null,
        //                    LendRelation = !string.IsNullOrWhiteSpace(z["LendRelation"].ToString()) ? Convert.ToInt16(z["LendRelation"]) : (Int16?)null,
        //                }
        //                ).ToList();
        //            }

        //            foreach (EligiblityPersonal personal in personals)
        //            {
        //                personal.Employment = employments
        //                        .Where(x => x.ProspectCustomerRef == personal.CustomerId).FirstOrDefault();
        //            }

        //            eligiblityDetails.Applicants = personals;
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ProductLogManager.DebugWrite(ex.Message + ex.InnerException + ex.StackTrace);
        //    }
        //    catch (Exception e)
        //    {
        //        ProductLogManager.DebugWrite(e.Message + e.InnerException + e.StackTrace);
        //    }
        //    return eligiblityDetails;
        //}

        ///// <summary>
        /////Get Eligiblity Details method returns  data based on user id
        ///// </summary>
        ///// <returns>
        /////generic list of Eligiblity Details
        ///// </returns>
        ///// <history>
        /////  Author				:	Saravanan R
        /////  Creation Date		:	10/9/2014
        /////  </history>
        //public List<EligiblityDetails> GetEligiblityDetails(int userId)
        //{
        //    ProductLogManager.TraceWrite("Get Eligiblity details Data Component");
        //    List<EligiblityDetails> eligiblityDetails = new List<EligiblityDetails>();
        //    DataSet dsEligiblityDetails = null;
        //    try
        //    {
        //        dsEligiblityDetails = ProductDB.DBInstance.ExecuteDataSet(StoredProcConstants.GETELIGIBLITYDETAILS, userId);
        //        if (dsEligiblityDetails != null)
        //        {
        //            eligiblityDetails = dsEligiblityDetails.Tables[0].AsEnumerable().Select(x => new EligiblityDetails
        //            {
        //                ProspectId = (Int32)(x["ProspectId"]),
        //                SalesExec = !string.IsNullOrEmpty(x["SalesExecId"].ToString()) ? (Int16?)(x["SalesExecId"]) : null,
        //                Agency = !string.IsNullOrEmpty(x["AgencyId"].ToString()) ? (Int16?)(x["AgencyId"]) : null,
        //                NoofApp = !string.IsNullOrEmpty(x["Noofapplicants"].ToString()) ? (Int16?)(x["Noofapplicants"]) : null,
        //                ReceivedDate = (DateTime?)((!string.IsNullOrEmpty(x["ReceivedDate"].ToString()) ? x["ReceivedDate"] : null)),
        //                IsAppConverted = Convert.ToBoolean(x["IsAppConverted"].ToString()),
        //                IsCredit = Convert.ToBoolean(x["IsCreditValidated"].ToString()),
        //                ModifiedOn = (DateTime?)((!string.IsNullOrEmpty(x["UpdatedOn"].ToString()) ? x["UpdatedOn"] : null)),
        //                CreatedOn = (DateTime)((!string.IsNullOrEmpty(x["CreatedOn"].ToString()) ? x["CreatedOn"] : null)),
        //                CreatedBy = !string.IsNullOrEmpty(x["CreatedBy"].ToString()) ? (x["CreatedBy"].ToString()) : "",
        //                ModifiedBy = !string.IsNullOrEmpty(x["UpdatedBy"].ToString()) ? (x["UpdatedBy"].ToString()) : "",
        //            }).ToList();
        //            List<EligiblityPersonal> customers = null;
        //            List<EligiblityProductDetails> products = null;
        //            if (dsEligiblityDetails.Tables.Count > 1)
        //            {
        //                customers = dsEligiblityDetails.Tables[1].AsEnumerable().Select(y => new EligiblityPersonal
        //               {
        //                   ProspectId = (Int32)(y["ProspectId"]),
        //                   CustomerId = (Int32)(y["ProspectCustomerRef"]),
        //                   FName = (string)(y["FName"]),
        //                   LName = (string)(y["LName"] ?? ""),
        //               }).ToList();
        //            }
        //            if (dsEligiblityDetails.Tables.Count > 2)
        //            {
        //                products = dsEligiblityDetails.Tables[2].AsEnumerable().Select(z => new EligiblityProductDetails
        //               {
        //                   ApplicationId = (Int32)(z["ProspectId"]),
        //                   ProductId = (Int16)(z["ProductType"]),
        //                   AppProdId = (Int32)(z["ProspectProductRef"]),
        //               }
        //             ).ToList();
        //            }
        //            foreach (EligiblityDetails result in eligiblityDetails)
        //            {
        //                if (customers != null)
        //                {
        //                    result.Applicants = customers.AsEnumerable()
        //                            .Where(x => x.ProspectId == result.ProspectId)
        //                            .Select(y => new EligiblityPersonal { FName = y.FName, LName = y.LName, ProspectId = y.ProspectId, CustomerId = y.CustomerId })
        //                            .ToList();
        //                }
        //                if (products != null)
        //                {
        //                    result.Products = products.AsEnumerable()
        //                            .Where(x => x.ApplicationId == result.ProspectId)
        //                            .Select(y => new EligiblityProductDetails { ProductId = y.ProductId, AppProdId = y.AppProdId }).ToList();
        //                }
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ProductLogManager.DebugWrite(ex.Message + ex.InnerException + ex.StackTrace);
        //    }
        //    catch (Exception e)
        //    {
        //        ProductLogManager.DebugWrite(e.Message + e.InnerException + e.StackTrace);
        //    }
        //    return eligiblityDetails;
        //}

        ///// <summary>
        /////Get Search Details method returns searched data based on search parameter and value
        ///// </summary>
        ///// <returns>
        ///// generic list of searchresult
        ///// </returns>
        ///// <history>
        /////  Author				:	Saravanan R
        /////  Creation Date		:	4/4/2014
        /////  </history>
        //public List<SearchResult> GetAppHistory(string userId)
        //{
        //    ProductLogManager.TraceWrite("Get App History Results Data Component");
        //    List<SearchResult> searchResults = null;
        //    DataSet dsSearchResults = null;
        //    ProductLogManager.TraceWrite("UserId " + userId);
        //    List<CustomerDetails> customers = null;
        //    List<ProductDetails> products = null;
        //    try
        //    {
        //        dsSearchResults = ProductDB.DBInstance.ExecuteDataSet(StoredProcConstants.GETAPPHISTORY, Convert.ToInt32(userId));
        //        if (dsSearchResults.Tables.Count > 0)
        //        {
        //            searchResults = dsSearchResults.Tables[0].AsEnumerable().Select(x => new SearchResult
        //            {
        //                ApplicationStatusDesc = (string)(x["Description"]),
        //                ApplicationId = (Int32)(x["ApplicationId"]),
        //                ApplicationStatus = (Int16)(x["ApplicationStatus"]),
        //                UpdatedOn = (DateTime?)((!string.IsNullOrEmpty(x["UpdatedOn"].ToString()) ? x["UpdatedOn"] : null)),
        //                CreatedBy = (int?)((!string.IsNullOrEmpty(x["CreatedBy"].ToString()) ? x["CreatedBy"] : null)),
        //                UpdatedBy = (int?)((!string.IsNullOrEmpty(x["Updatedby"].ToString()) ? x["Updatedby"] : null)),
        //                ApplicationNumber = !string.IsNullOrEmpty(x["SysApplicationNumber"].ToString()) ? x["SysApplicationNumber"].ToString() : null,
        //                CreatedOn = (DateTime?)((!string.IsNullOrEmpty(x["CreatedOn"].ToString()) ? x["CreatedOn"] : null)),
        //                ReceivedDate = (DateTime?)((!string.IsNullOrEmpty(x["ReceivedDate"].ToString()) ? x["ReceivedDate"] : null)),
        //            }
        //                ).ToList();
        //            if (dsSearchResults.Tables.Count > 1 && dsSearchResults.Tables[1].Rows.Count > 0)
        //            {
        //                customers = dsSearchResults.Tables[1].AsEnumerable().Select(y => new CustomerDetails
        //               {
        //                   ApplicationId = (Int32)(y["ApplicationId"]),
        //                   CustomerId = (Int32)(y["CustomerId"]),
        //                   FName = (string)(y["FName"]),
        //                   LName = (string)(y["LName"] ?? ""),
        //               }
        //              ).ToList();
        //            }
        //            if (dsSearchResults.Tables.Count > 2 && dsSearchResults.Tables[2].Rows.Count > 0)
        //            {
        //                products = dsSearchResults.Tables[2].AsEnumerable().Select(z => new ProductDetails
        //               {
        //                   ApplicationId = (Int32)(z["ApplicationId"]),
        //                   ProductId = (Int32)(z["Productid"]),
        //               }
        //             ).ToList();
        //            }

        //            var appHistory = dsSearchResults.Tables[3].AsEnumerable().Select(a => new
        //            {
        //                ApplicationId = (Int32)(a["ApplicationId"]),
        //                AppStatus = (Int32)(a["ApplicationStatus"]),
        //                StatusBy = (Int32?)((!string.IsNullOrEmpty(a["CreatedBy"].ToString()) ? a["CreatedBy"] : null)),
        //                StatusDesc = !string.IsNullOrEmpty(a["DisplayValue"].ToString()) ? a["DisplayValue"].ToString() : null,
        //                StatusByUser = !string.IsNullOrEmpty(a["UserName"].ToString()) ? a["UserName"].ToString() : null,
        //                StatusOn = (DateTime?)((!string.IsNullOrEmpty(a["CreatedON"].ToString()) ? a["CreatedON"] : null)),
        //            }
        //          ).ToList();

        //            foreach (SearchResult result in searchResults)
        //            {
        //                result.Customers = customers.AsEnumerable()
        //                        .Where(x => x.ApplicationId == result.ApplicationId)
        //                        .Select(y => new CustomerDetails { FName = y.FName, LName = y.LName, ApplicationId = y.ApplicationId, CustomerId = y.CustomerId })
        //                        .ToList();
        //                result.StatusHistory = appHistory.AsEnumerable()
        //                     .Where(x => x.ApplicationId == result.ApplicationId)
        //                     .Select(y => new ApplicationHistory
        //                     {
        //                         ApplicationId = y.ApplicationId,
        //                         AppStatus = y.AppStatus,
        //                         StatusBy = y.StatusBy,
        //                         StatusDesc = y.StatusDesc,
        //                         StatusByUser = y.StatusByUser,
        //                         StatusOn = y.StatusOn
        //                     })
        //                     .ToList();
        //                result.Category = products.AsEnumerable()
        //                        .Where(x => x.ApplicationId == result.ApplicationId)
        //                        .Select(y => new ProductDetails { ProductId = y.ProductId }).ToList();
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ProductLogManager.DebugWrite(ex.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        ProductLogManager.DebugWrite(e.Message);
        //    }
        //    return searchResults;
        //}

        ///// <summary>
        /////Get GetCustomersByApplication method returns customer data based on applicationid
        ///// </summary>
        ///// <returns>
        ///// generic list of customer details
        ///// </returns>
        ///// <history>
        /////  Author				:	Saravanan R
        /////  Creation Date		:	4/4/2014
        /////  </history>
        //public List<CustomerDetails> GetCustomersByApplication(int applicationId)
        //{
        //    ProductLogManager.TraceWrite("Get Customers by application Details  Data Component");
        //    List<CustomerDetails> customers = null;
        //    DataSet dsCustomers = null;

        //    try
        //    {
        //        dsCustomers = ProductDB.DBInstance.ExecuteDataSet(StoredProcConstants.GETCUSTOMERBYAPPID, applicationId);

        //        customers = dsCustomers.Tables[0].AsEnumerable().Select(x => new CustomerDetails
        //        {
        //            FName = (string)(x["FName"]),
        //            ApplicationId = (Int32)(x["ApplicationId"]),
        //            CustomerId = (Int32)(x["CustomerId"]),
        //            AppType = (Int16?)((!string.IsNullOrEmpty(x["ApplicantType"].ToString()) ? x["ApplicantType"] : null)),
        //            EmpType = (Int16?)((!string.IsNullOrEmpty(x["EmploymentType"].ToString()) ? x["EmploymentType"] : null)),
        //        }
        //            ).ToList();
        //    }
        //    catch (SqlException ex)
        //    {
        //        ProductLogManager.DebugWrite(ex.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        ProductLogManager.DebugWrite(e.Message);
        //    }
        //    return customers;
        //}

        //// <summary>
        /////Get HeaderInfo  method accepts applicationId and customerid as input and returns information by calling DB
        ///// </summary>
        ///// <returns>
        /////instance of Header Info
        ///// </returns>
        ///// <history>
        /////  Author				:	Saravanan R
        /////  Creation Date		:	28/5/2014
        /////  </history>
        //public HeaderInfo GetHeaderInformation(int applicationId, int customerId)
        //{
        //    ProductLogManager.TraceWrite("Get HeaderInfo Data Component");
        //    HeaderInfo headerInfo = null;
        //    DataSet dsHeaderInfo = null;
        //    try
        //    {
        //        dsHeaderInfo = ProductDB.DBInstance.ExecuteDataSet(StoredProcConstants.GETHEADERINFO, applicationId, customerId);
        //        if (dsHeaderInfo != null)
        //        {
        //            headerInfo = new HeaderInfo
        //            {
        //                CustomerId = (Int32)(dsHeaderInfo.Tables[0].Rows[0]["CustomerId"]),
        //                //  ProdCategory = (Int32)(dsHeaderInfo.Tables[0].Rows[0]["ProductId"]),
        //                ApplicationId = (Int32)(dsHeaderInfo.Tables[0].Rows[0]["ApplicationId"]),
        //                FName = !string.IsNullOrEmpty(dsHeaderInfo.Tables[0].Rows[0]["FName"].ToString()) ? (dsHeaderInfo.Tables[0].Rows[0]["FName"].ToString()) : "",
        //                MName = !string.IsNullOrEmpty(dsHeaderInfo.Tables[0].Rows[0]["MName"].ToString()) ? (dsHeaderInfo.Tables[0].Rows[0]["MName"].ToString()) : "",
        //                LName = !string.IsNullOrEmpty(dsHeaderInfo.Tables[0].Rows[0]["LName"].ToString()) ? (dsHeaderInfo.Tables[0].Rows[0]["LName"].ToString()) : "",
        //                BusinessName = !string.IsNullOrEmpty(dsHeaderInfo.Tables[0].Rows[0]["BusinessName"].ToString()) ? (dsHeaderInfo.Tables[0].Rows[0]["BusinessName"].ToString()) : "",
        //                Nationality = !string.IsNullOrEmpty(dsHeaderInfo.Tables[0].Rows[0]["Nationality"].ToString()) ? (dsHeaderInfo.Tables[0].Rows[0]["Nationality"]).ToString() : "",
        //                EligibleIncome = !string.IsNullOrEmpty(dsHeaderInfo.Tables[0].Rows[0]["TotalIncome"].ToString()) ? (decimal?)(dsHeaderInfo.Tables[0].Rows[0]["TotalIncome"]) : null,
        //                LOS = !string.IsNullOrEmpty(dsHeaderInfo.Tables[0].Rows[0]["LOS"].ToString()) ? (Int16?)(dsHeaderInfo.Tables[0].Rows[0]["LOS"]) : null,
        //            };
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ProductLogManager.DebugWrite(ex.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        ProductLogManager.DebugWrite(e.Message);
        //    }
        //    return headerInfo;
        //}

        ///// <summary>
        /////Get ApplicationDetails along with Additional details based on the application id by calling DB
        ///// </summary>
        ///// <returns>
        ///// instance of application details
        ///// </returns>
        ///// <history>
        /////  Author				:	Saravanan R
        /////  Creation Date		:	30/5/2014
        /////  </history>
        //public ApplicationDetails GetApplicationDetails(int applicationId)
        //{
        //    ProductLogManager.TraceWrite("Get Application Details Data Component");
        //    ApplicationDetails appDetails = null;
        //    DataSet dsAppDetails = null;
        //    ProductLogManager.TraceWrite("Appid " + applicationId);
        //    try
        //    {
        //        dsAppDetails = ProductDB.DBInstance.ExecuteDataSet(StoredProcConstants.GETAPPDETAILS, applicationId);
        //        if (dsAppDetails.Tables.Count > 0)
        //        {
        //            appDetails = new ApplicationDetails
        //            {
        //                ApplicationId = (Int32)(dsAppDetails.Tables[0].Rows[0]["ApplicationId"]),
        //                SalesExec = !string.IsNullOrEmpty(dsAppDetails.Tables[0].Rows[0]["SalesExecId"].ToString()) ? (Int32?)(dsAppDetails.Tables[0].Rows[0]["SalesExecId"]) : null,
        //                Agency = !string.IsNullOrEmpty(dsAppDetails.Tables[0].Rows[0]["AgencyId"].ToString()) ? (Int32?)(dsAppDetails.Tables[0].Rows[0]["AgencyId"]) : null,
        //                Branch = !string.IsNullOrEmpty(dsAppDetails.Tables[0].Rows[0]["Branch"].ToString()) ? (Int16?)(dsAppDetails.Tables[0].Rows[0]["Branch"]) : null,
        //                City = !string.IsNullOrEmpty(dsAppDetails.Tables[0].Rows[0]["BranchCity"].ToString()) ? (dsAppDetails.Tables[0].Rows[0]["BranchCity"].ToString()) : "",
        //                State = !string.IsNullOrEmpty(dsAppDetails.Tables[0].Rows[0]["Province"].ToString()) ? (dsAppDetails.Tables[0].Rows[0]["Province"].ToString()) : "",
        //                Channel = !string.IsNullOrEmpty(dsAppDetails.Tables[0].Rows[0]["ApplicationChannel"].ToString()) ? (Int16?)(dsAppDetails.Tables[0].Rows[0]["ApplicationChannel"]) : null,
        //                SubChannel = !string.IsNullOrEmpty(dsAppDetails.Tables[0].Rows[0]["ApplicationSubChannel"].ToString()) ? (Int16?)(dsAppDetails.Tables[0].Rows[0]["ApplicationSubChannel"]) : null,
        //                SysApplicationNumber = !string.IsNullOrEmpty(dsAppDetails.Tables[0].Rows[0]["SysApplicationNumber"].ToString()) ? (dsAppDetails.Tables[0].Rows[0]["SysApplicationNumber"].ToString()) : "",
        //                CoApplicants = !string.IsNullOrEmpty(dsAppDetails.Tables[0].Rows[0]["Noofapplicants"].ToString()) ? (Int16?)(dsAppDetails.Tables[0].Rows[0]["Noofapplicants"]) : null,
        //                //   SuppCards = !string.IsNullOrEmpty(dsAppDetails.Tables[0].Rows[0]["NoofSuppCards"].ToString()) ? (Int16?)(dsAppDetails.Tables[0].Rows[0]["NoofSuppCards"]) : null,
        //                ApplicationSource = !string.IsNullOrEmpty(dsAppDetails.Tables[0].Rows[0]["ApplicationSource"].ToString()) ? (Int16?)(dsAppDetails.Tables[0].Rows[0]["ApplicationSource"]) : null,
        //                IsLocal = !string.IsNullOrEmpty(dsAppDetails.Tables[0].Rows[0]["IsLocal"].ToString()) ? (Boolean?)(dsAppDetails.Tables[0].Rows[0]["IsLocal"]) : null,
        //                StaffFlag = !string.IsNullOrEmpty(dsAppDetails.Tables[0].Rows[0]["StaffFlag"].ToString()) ? (Boolean?)(dsAppDetails.Tables[0].Rows[0]["StaffFlag"]) : null,
        //                ReferralFlag = !string.IsNullOrEmpty(dsAppDetails.Tables[0].Rows[0]["StaffReferralFlag"].ToString()) ? (Boolean?)(dsAppDetails.Tables[0].Rows[0]["StaffReferralFlag"]) : null,
        //                Region = !string.IsNullOrEmpty(dsAppDetails.Tables[0].Rows[0]["Region"].ToString()) ? (Int16?)(dsAppDetails.Tables[0].Rows[0]["Region"]) : null,
        //                TeleSale = !string.IsNullOrEmpty(dsAppDetails.Tables[0].Rows[0]["TeleSale"].ToString()) ? (Int16?)(dsAppDetails.Tables[0].Rows[0]["TeleSale"]) : null,
        //                BM = !string.IsNullOrEmpty(dsAppDetails.Tables[0].Rows[0]["BM"].ToString()) ? (Int16?)(dsAppDetails.Tables[0].Rows[0]["BM"]) : null,
        //                RSM = !string.IsNullOrEmpty(dsAppDetails.Tables[0].Rows[0]["RSM"].ToString()) ? (Int16?)(dsAppDetails.Tables[0].Rows[0]["RSM"]) : null,
        //                ASM = !string.IsNullOrEmpty(dsAppDetails.Tables[0].Rows[0]["ASM"].ToString()) ? (Int16?)(dsAppDetails.Tables[0].Rows[0]["ASM"]) : null,
        //                ApplicationStatus = !string.IsNullOrEmpty(dsAppDetails.Tables[0].Rows[0]["ApplicationStatus"].ToString()) ? (Int16?)(dsAppDetails.Tables[0].Rows[0]["ApplicationStatus"]) : null,
        //                CreatedBy = Convert.ToString(dsAppDetails.Tables[0].Rows[0]["CreatedBy"]),
        //                ReceivedDate = !string.IsNullOrEmpty(dsAppDetails.Tables[0].Rows[0]["ReceivedDate"].ToString()) ? (DateTime?)(dsAppDetails.Tables[0].Rows[0]["ReceivedDate"]) : null,
        //                LoginDate = !string.IsNullOrEmpty(dsAppDetails.Tables[0].Rows[0]["ProcessDate"].ToString()) ? (DateTime?)(dsAppDetails.Tables[0].Rows[0]["ProcessDate"]) : null,
        //            };
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ProductLogManager.DebugWrite(ex.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        ProductLogManager.DebugWrite(e.Message);
        //    }
        //    return appDetails;
        //}

        ///// <summary>
        /////Get ApplicationProductDetails along with Additional details based on the application id by calling DB
        ///// </summary>
        ///// <returns>
        ///// instance of ProductDetails
        ///// </returns>
        ///// <history>
        /////  Author				:	Saravanan R
        /////  Creation Date		:	25/8/2014
        /////  </history>
        //public List<ProductDetails> GetApplicationProductDetails(int applicationId)
        //{
        //    ProductLogManager.TraceWrite("Get Application Product Details Data Component");
        //    List<ProductDetails> appDetails = null;
        //    DataSet dsAppDetails = null;
        //    ProductLogManager.TraceWrite("Appid " + applicationId);
        //    try
        //    {
        //        dsAppDetails = ProductDB.DBInstance.ExecuteDataSet(StoredProcConstants.GETAPPPRODDETAILS, applicationId);
        //        if (dsAppDetails != null)
        //        {
        //            appDetails = dsAppDetails.Tables[0].AsEnumerable().Select(x => new ProductDetails
        //            {
        //                AppProdId = (Int32)(x["ApplicationProductId"]),
        //                ApplicationId = (Int32)(x["ApplicationId"]),
        //                ProductId = (Int32)(x["Productid"]),
        //                SubProductId = !string.IsNullOrEmpty(x["SubProduct"].ToString()) ? (Int16?)(x["SubProduct"]) : null,
        //                CustomerId = !string.IsNullOrEmpty(x["Customerid"].ToString()) ? (Int32?)(x["Customerid"]) : null,
        //                LoanAmount = !string.IsNullOrEmpty(x["LoanAmount"].ToString()) ? (decimal?)(x["LoanAmount"]) : null,
        //                EStmt = !string.IsNullOrEmpty(x["IsEStmt"].ToString()) ? (Boolean?)(x["IsEStmt"]) : null,
        //                EmailStmt = !string.IsNullOrEmpty(x["IsEmailStmt"].ToString()) ? (Boolean?)(x["IsEmailStmt"]) : null,
        //                IscreditShield = !string.IsNullOrEmpty(x["CreditShield"].ToString()) ? (Boolean?)(x["CreditShield"]) : null,
        //                IsCredit = !string.IsNullOrEmpty(x["IsCredit"].ToString()) ? (Boolean?)(x["IsCredit"]) : false,
        //                StmtAddress = !string.IsNullOrEmpty(x["StmtAddress"].ToString()) ? (x["StmtAddress"].ToString()) : "",
        //                LoyaltyProgram = !string.IsNullOrEmpty(x["LoyalityProgram"].ToString()) ? (x["LoyalityProgram"].ToString()) : "",
        //                LoyaltyProgramNo = !string.IsNullOrEmpty(x["LoyalityProgramNumber"].ToString()) ? (x["LoyalityProgramNumber"].ToString()) : "",
        //                DueAmount = !string.IsNullOrEmpty(x["PrefPayment"].ToString()) ? (decimal?)(x["PrefPayment"]) : null,
        //                MinDue = !string.IsNullOrEmpty(x["MinDueRequested"].ToString()) ? (decimal?)(x["MinDueRequested"]) : null,
        //                RepaymentMode = !string.IsNullOrEmpty(x["RepaymentMode"].ToString()) ? (Int16?)(x["RepaymentMode"]) : null,
        //                SalesCampaign = !string.IsNullOrEmpty(x["SalesCampaign"].ToString()) ? (Int16?)(x["SalesCampaign"]) : null,
        //                MarketingCamapaign = !string.IsNullOrEmpty(x["MarketingCampaign"].ToString()) ? (Int16?)(x["MarketingCampaign"]) : null,
        //                AccNo = !string.IsNullOrEmpty(x["Accountnumber"].ToString()) ? (x["Accountnumber"].ToString()) : "",
        //                SalesSubProm = !string.IsNullOrEmpty(x["SalesSubPromotion"].ToString()) ? (Int16?)(x["SalesSubPromotion"]) : null,
        //                SalesProm = !string.IsNullOrEmpty(x["SalesProm"].ToString()) ? (Int32?)(x["SalesProm"]) : null,
        //                SrcRefNo = !string.IsNullOrEmpty(x["SrcRefNo"].ToString()) ? (x["SrcRefNo"].ToString()) : "",
        //                CreatedBy = Convert.ToString(x["CreatedBy"]),
        //                Topups = !string.IsNullOrEmpty(x["Topup"].ToString()) ? (Int32?)(x["Topup"]) : null,
        //                RepaymentFreq = !string.IsNullOrEmpty(x["RepaymentFreq"].ToString()) ? (Int16?)(x["RepaymentFreq"]) : null,
        //                Tenor = !string.IsNullOrEmpty(x["Tenor"].ToString()) ? (Int16?)(x["Tenor"]) : null,
        //                Interest = !string.IsNullOrEmpty(x["InterestRate"].ToString()) ? (decimal?)(x["InterestRate"]) : null,
        //            }).ToList();
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ProductLogManager.DebugWrite(ex.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        ProductLogManager.DebugWrite(e.Message);
        //    }
        //    return appDetails;
        //}
    }
}