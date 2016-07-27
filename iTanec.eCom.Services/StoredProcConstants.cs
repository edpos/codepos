namespace UIG.Accounting.DataServices
{
    /// <summary>
    ///Stored Proc Constants class holds all Stored Procedure Names as  constants that are used
    /// </summary>
    /// <history>
    ///  Author				:	Saravanan R
    ///  Creation Date		:	10/2/2014
    ///  Last revised		:
    ///  Revision history	:
    /// </history>
    public static class StoredProcConstants
    {
        public const string AUTHENTICATEUSER = "usp_AuthenticateUser";
        public const string PAYMENTTYPELIST = "usp_GetPaymentTypeList";
        public const string SAVEPAYMENTDETAILS = "usp_SavePaymentDetails";
        public const string GETPAYMENTATTRIBUTELIST = "usp_GetPaymentAttributesList";
        public const string GETINVOICEDETAILSLIST = "usp_GetInvoiceDeailList";
        public const string SAVEPAYMENTATTRIBUTES = "usp_SavePaymentAttributes";
        public const string GETPAYMENTLIST = "usp_GetPaymentList";
    }
}