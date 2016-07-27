using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace iTanec.eCom.Common.General
{
    public class EmailUtility
    {
        private MailMessage mailMessage = null;
        private SmtpClient smtpClientObj = null;

        public EmailUtility()
        {
            this.smtpClientObj = new SmtpClient();
        }
        public void SendMailToOne(string fromAddr, string toAddress, string subject,
                                string bodyTxt, string smtpServer,
                                NetworkCredential networkCredentialObj,
                                string attachMentFilePath = null,
                                string ccAddress = null,
                                string bccAddress = null)
        {
            MailAddress toMailAddress = null;
            MailAddress fromMailAddress = null;
            Attachment attachfile = null;

            toMailAddress = new MailAddress(toAddress);
            fromMailAddress = new MailAddress(fromAddr);

            if (!string.IsNullOrEmpty(attachMentFilePath))
            {
                attachfile = new Attachment(attachMentFilePath);
            }

            this.mailMessage = new MailMessage();

            this.mailMessage.To.Add(toMailAddress);
            this.mailMessage.From = fromMailAddress;
            this.mailMessage.Subject = subject;
            this.mailMessage.Body = bodyTxt;
            this.mailMessage.IsBodyHtml = true;
            this.mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            if (!string.IsNullOrEmpty(ccAddress))
            {
                this.mailMessage.CC.Add(ccAddress);
            }
            if (!string.IsNullOrEmpty(bccAddress))
            {
                this.mailMessage.Bcc.Add(bccAddress);
            }

            if (File.Exists(attachMentFilePath))
            {
                this.mailMessage.Attachments.Add(attachfile);
            }

            smtpClientObj.Credentials = networkCredentialObj;
            smtpClientObj.Host = smtpServer;
            smtpClientObj.EnableSsl = false;
            smtpClientObj.Send(mailMessage);
            mailMessage.Dispose();
        }

        public void SendMailToMany(string fromAddress, List<string> toAddressArr, string subject,
                                    string bodyTxt, string smtpServer,
                                    NetworkCredential networkCredentialObj,
                                    string[] attachmentFileArr = null,
                                    List<string> ccAddressArr = null,
                                    List<string> bccAddressArr = null)
        {
            MailAddress fromMailAddress = null;
            fromMailAddress = new MailAddress(fromAddress);

            this.mailMessage = new MailMessage();

            this.mailMessage.From = fromMailAddress;
            this.mailMessage.Subject = subject;
            this.mailMessage.IsBodyHtml = true;
            this.mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            AddBCCAddresses(bccAddressArr);
            AddCCAddresses(ccAddressArr);
            AddReceiversAddresses(toAddressArr);
            AddBody(bodyTxt);
            AttachFiles(attachmentFileArr);

            smtpClientObj.Host = smtpServer;
            smtpClientObj.Credentials = networkCredentialObj;
            smtpClientObj.EnableSsl = true;
            smtpClientObj.Send(mailMessage);
            mailMessage.Dispose();
        }

        public void SendMailWithAttachment(string fromAddress, string toMailAddress, string subject,
                                  string bodyTxt, string smtpServer,
                                  NetworkCredential networkCredentialObj,
                                  HttpPostedFile[] attachmentFileArr,
                                  List<string> ccAddressArr = null)
        {
            MailAddress fromMailAddress = null;
            fromMailAddress = new MailAddress(fromAddress);

            this.mailMessage = new MailMessage();

            this.mailMessage.From = fromMailAddress;
            this.mailMessage.To.Add(toMailAddress);
            this.mailMessage.Subject = subject;
            this.mailMessage.IsBodyHtml = true;
            this.mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            //AddBCCAddresses(bccAddressArr);
            AddCCAddresses(ccAddressArr);
            AddBody(bodyTxt);
            AttachHttpPostedFiles(attachmentFileArr);

            smtpClientObj.Host = smtpServer;
            smtpClientObj.Credentials = networkCredentialObj;
            smtpClientObj.EnableSsl = true;
            smtpClientObj.Send(mailMessage);
            mailMessage.Attachments.Dispose();
        }

        private void AddReceiversAddresses(List<string> toAddressArr)
        {
            if (toAddressArr != null)
            {
                for (int addressIndex = 0; addressIndex < toAddressArr.Count; addressIndex++)
                {
                    if (!String.IsNullOrEmpty(toAddressArr[addressIndex]))
                    {
                        mailMessage.To.Add(toAddressArr[addressIndex].Trim());
                    }
                }
            }
        }

        private void AddCCAddresses(List<string> ccAddressArr)
        {
            if (ccAddressArr != null)
            {
                for (int addressIndex = 0; addressIndex < ccAddressArr.Count; addressIndex++)
                {
                    if (!String.IsNullOrEmpty(ccAddressArr[addressIndex]))
                    {
                        mailMessage.CC.Add(ccAddressArr[addressIndex].Trim());
                    }
                }
            }
        }

        private void AddBCCAddresses(List<string> bccAddressArr)
        {
            if (bccAddressArr != null)
            {
                for (int addressIndex = 0; addressIndex < bccAddressArr.Count; addressIndex++)
                {
                    if (!string.IsNullOrEmpty(bccAddressArr[addressIndex]))
                    {
                        mailMessage.Bcc.Add(bccAddressArr[addressIndex].Trim());
                    }
                }
            }
        }

        private void AddBody(string bodyTxt)
        {
            mailMessage.Body = bodyTxt;
        }

        private void AttachFiles(string[] attachmentFileArr)
        {
            Attachment attachFile = null;

            if (attachmentFileArr != null)
            {
                for (int fileIndex = 0; fileIndex < attachmentFileArr.Length; fileIndex++)
                {
                    if (File.Exists(attachmentFileArr[fileIndex]))
                    {
                        attachFile = new Attachment(attachmentFileArr[fileIndex]);
                        mailMessage.Attachments.Add(attachFile);
                    }
                }
            }
        }

        private void AttachHttpPostedFiles(HttpPostedFile[] attachmentFileArr)
        {
            Attachment attachFile = null;

            if (attachmentFileArr != null)
            {
                for (int fileIndex = 0; fileIndex < attachmentFileArr.Length; fileIndex++)
                {
                    string strFileName = Path.GetFileName(attachmentFileArr[fileIndex].FileName);

                    attachFile = new Attachment(attachmentFileArr[fileIndex].InputStream, strFileName);
                    mailMessage.Attachments.Add(attachFile);
                }
            }
        }
    }
}
