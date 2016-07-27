using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTanec.eCom.Common.General
{
    public class ApplicationConstants
    {
        //Constructor
        public ApplicationConstants() { }

        /***************************************** SMTP Constants *****************************************/
        public const string ApplicationDomainName = "admin.iTanec.com";
        public const string ApplicationDomainURL = "admin.iTanec.com";

        /**************************************** String Constants ****************************************/

        /***************************************** SMTP Constants *****************************************/
        public const string SMTP_SERVER = "Smtp.mail.iTanec.net";

        /**************************************** String Constants ****************************************/
        public const string USER_ID = "UserID";
        public const string USER_NAME = "UserName";
        public const string EMAIL_ADDRESS = "EmailAddress";
        public const string ROLE_ID = "RoleID";
        public const string LANGUAGE_ID = "LanguageID";
        public const string SIF_ENTITY = "SIFEntity";
        public const string PROCESS_ID = "ProcessID";
        public const string MULTIPLE_SIF = "MultipleSIF";
        public const string ZEUS_PLUS = "ZeusPlus";
        public const string GUEST_LANGUAGE_ID = "GuestLanguageID";
        public const string GUEST_SIF_ENTITY = "GuestSIFEntity";
        public const string SIF_LOCATION = "SIFLocation";
        public const string MULTIPLE_SIF_LOCATION = "MultipleSIFLocation";
        public const string ALLAREAS_RIGHTS = "AllAreas_Rights";
        public const string BUSINESS_UNIT_ID = "BUSINESS_UNIT_ID";
        public const string BU_GUEST = "BU_GUEST";
        public const string CFO_Flg = "CFO_Flg";
        public const string ADMIN_Flg = "ADMIN_Flg";

       

        /*************************************** Integer Constants ****************************************/
        public const string DEFAULT_USER_PHOTO = "NoImageAvail.jpg";

        /*************************************** Integer Constants ****************************************/
        public const int MAX_PROCESS_COLUMNS = 9;
        public const int MAX_ZEUSPLUS_MODULES_COLUMNS = 7;
        /**************************************************************************************************/
        /*************************************** Character Constants **************************************/
        public const char DELIMITER_PIPE = '|';
        public const char DELIMITER_COLON = ':';
        public const char DELIMITER_TILDE = '~';
        public const char DELIMITER_COMMA = ',';
        /**************************************************************************************************/

        /*********************************** Images File Path Constants ***********************************/
        //Image file path Constants
        public const string NORMAL_IMAGE_PATH = "Images/";
        public const string FOOTER_IMAGE_PATH = "Images/FooterImages/";
        public const string GRAY_IMAGE_PATH = "Images/GrayImage/";
        public const string TREE_IMAGE_PATH = "Images/TreeImages/";
        public const string PROCESS_IMAGE_PATH = "Images/Process/";
        public const string USER_IMAGE_PATH = "Images/EmplImages/";
        /**************************************************************************************************/

        /************************************** File Paths Constants **************************************/
        public const string MATRIX_FOLDER_PATH = "Matrix/";
        public const string REF_DOC_FOLDER_PATH = "RefDocs/";
        public const string UPLOAD_FILE_PATH = "UploadFiles/";
        /**************************************************************************************************/

        /***************************************** Template Files *****************************************/
        //Email Templates
        public const string TEMPLATE_EMAIL_ERROR = "EmailError.htm";
        public const string TEMPLATE_EMAIL_CFO_AdminEdit = "CFO_MailProcess.html";
        /**************************************************************************************************/

        /****************************************** Allowed Pages *****************************************/
        public const string ALLOWED_PAGES = "Login.chtml, LoginValidate.chtml, WelcomeGuest.chtml, Home.chtml, AdminHome.chtml, MyProfile.chtml, SessionExpired.chtml, SIFTree.chtml, Introduction.chtml, ReferenceFramework.chtml, ViewFramework.chtml, Matrix.chtml, " +
                                                                                                    "AdaptSupplement.chtml, AdminRightAssign.chtml, AssessRisks.chtml, ViewAssessRisks.chtml, AssessRisksPendingApproval.chtml, ApproveAssessRisks.chtml, ADSI.chtml, FormulateControlsEdit.chtml, FormulateControls.chtml, " +
                                                                                                    "FormalizeReviews.chtml, FormalizeReviewsEdit.chtml, ReviewControls.chtml, ViewReviewControls.chtml, ReportAudits.chtml, CreateInternalAudit.chtml, ReportInternalAudits.chtml, RecordAuditReport.chtml, RecordAudit.chtml, " +
                                                                                                    "RecordAnomalies.chtml, RecordAnomalies_PID.chtml, DeployAction.chtml, FollowAction.chtml, FollowActionPlan.chtml, ViewFollowActionPlan.chtml, ZeusPlus.chtml, Dispute.chtml, Contracts.chtml, TradeOrgs.chtml, ConfidentialInfo.chtml,ReviewSessionGet_myinfo.chtml," +
                                                                                                    "ConfidentialInformationHome.chtml, ViewConfidentialInfo.chtml, ConfidentialInformationProcessList.chtml, ConfidentitalInformationList.chtml, ReviewResultsDashBoard.chtml,ITAC_HomePage.chtml,View_ITAC_Information.chtml,ITAC_ICRFControls_DashBoard.chtml," +
                                                                                                    "MonitorProgress.chtml,MonitorActionPoints.chtml, ArchivePolicy_Home.chtml, ArchivePolicyInforamtion.chtml, ArchivalInformationProcessList.chtml, ArchivalInformationList.chtml, DefaultFormBuiltUpdate.chtml,AssessRiskDefaultScreenOpen.chtml,FormulateControlsDefaultScreenOpen.chtml,DefaultFormControlsUpdate.chtml," +
                                                                                                    "AssessRiskCreateTemplateScreenOpen.chtml, DefaultRiskTemplateBuiltUpdate.chtml, FormulateControlsTemplateScreenOpen.chtml, DefaultFormControlsTemplateUpdate.chtml, AssessRiskCopyTemplateScreenOpen.chtml, DefaultCopyRiskTemplateBuiltUpdate.chtml, FormulateControlsCopyTemplateScreenOpen.chtml, DefaultCopyFormControlsTemplateUpdate.chtml, " +
                                                                                                    " FormalizeReviewTemplateScreenOpen.chtml, FormalizeControlsSetupReviews.chtml,FormalizeSetupReviewsOScreen.chtml,UpdateActionItems.chtml,FormalizeCtrlDepActionOScreen.chtml,FormalizeControlsDeployAction.chtml";
        public const string GUEST_ALLOWED_PAGES = "Login.chtml, LoginValidate.chtml, WelcomeGuest.chtml, Home.chtml, SessionExpired.chtml, Introduction.chtml, ReferenceFramework.chtml, ViewFramework.chtml, Matrix.chtml";
        public const string SPECIAL_ALLOWED_PAGES = "ZeusPlus.chtml, Dispute.chtml, Contracts.chtml, TradeOrgs.chtml, ConfidentialInfo.chtml, IntAcqCompany.chtml";


        /**************************************************************************************************/

        /************************************* Random String Constants ************************************/
        public const int RAND_COMBINE_ALL = 0;
        public const int RAND_ALPHA_NUMERIC = 1;
        public const int RAND_NUMBERS_ONLY = 2;
        public const int RAND_ALPHABETS_ONLY = 3;
        public const int RAND_DATETIME_ONLY = 4;
        public const int RAND_DATETIME_ALPHABETS = 5;

        /**************************************************************************************************/

        /************************************** Measurement Constants *************************************/
        public const int UNIT_BYTE = 0;
        public const int UNIT_KB = 1;
        public const int UNIT_MB = 2;
        public const int UNIT_GB = 3;
        public const int UNIT_SIZE = 1024;

        public const string UNIT_TYPE_BYTE = "B";
        public const string UNIT_TYPE_KB = "KB";
        public const string UNIT_TYPE_MB = "MB";
        public const string UNIT_TYPE_GB = "GB";

        /**************************************************************************************************/

       
    }
}
