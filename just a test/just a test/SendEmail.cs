using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Exchange.WebServices.Autodiscover;
using Microsoft.Exchange.WebServices.Data;

namespace just_a_test
{
    static class SendEmail
    {
        const string receiver = "y.georgiev@phoenixpharma.bg";
        static string sender = "";
        public static int Send(string subject, string body)
        {

            string logFile = "errLog.txt";
            string errorSection = "Read Console Arguments";
            try
            {
                /*
                string sender = args[0];
                string user = args[1];
                string pass = args[2];
                string msg = args[3];
                if (args.Length > 4)
                    logFile = args[4];//*/
                PrincipalContext context = UserPrincipal.Current.Context;
                string user = System.DirectoryServices.AccountManagement.UserPrincipal.Current.SamAccountName;
                
                string domain = Environment.UserDomainName;
                UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(context, user);
                sender = userPrincipal.EmailAddress;
                errorSection = "Validate Certificate";
                ServicePointManager.ServerCertificateValidationCallback = CertificateValidationCallBack;
                
                //string domain = sender.Substring(sender.IndexOf('@') + 1);
                AutodiscoverService adSrv = new AutodiscoverService(domain);
                
                ExchangeService service = new ExchangeService(adSrv.RequestedServerVersion);

                // For debug only!!!!
                //service.TraceEnabled = true;
                service.TraceFlags = TraceFlags.All;
                // ------------------ end of debug

                errorSection = "Create Credentials";

                //WebCredentials Cred = new WebCredentials(user, pass);
                //service.Credentials = Cred;
                service.UseDefaultCredentials = true;

                errorSection = "Autodiscover URL";
                //String [] byPassList = null;
                //service.WebProxy = new WebProxy("https://webmailext.phoenixgroup.eu");
                //service.Url = new Uri("https://webmailext.phoenixgroup.eu/");
                //service.Url = new Uri("DENU1XMAIL02.phoenix.loc", UriKind.Relative);
                service.AutodiscoverUrl(sender, RedirectionUrlValidationCallback);

                //service.Url = new Uri("https://webmail.phoenixgroup.eu/EWS/Exchange.asmx");
                //service.Url = new Uri("https://denu1xcasint.phoenix.loc/EWS/Exchange.asmx"); // old exchange server
                //service.Url = new Uri("https://denu02ms0015.phoenix.loc/EWS/Exchange.asmx"); // new server

                //Console.WriteLine("service.Url="+service.Url.ToString());

                Mailbox mail = new Mailbox(sender);
                bool isValid = mail.IsValid;
                
                MessageBody msgBody = new MessageBody
                {
                    BodyType = BodyType.HTML,
                    Text = body.Replace("\r\n", "<br />")
                };

                EmailMessage email = new EmailMessage(service)
                {
                    //From = new EmailAddress(sender),
                    Subject = subject,
                    Body = msgBody,
                    Sender = new EmailAddress(sender) { Name = UserPrincipal.Current.UserPrincipalName }
                };
                //email.From = new EmailAddress(sender);
                errorSection = "Read message file";
                
                email.ToRecipients.Add(receiver);

                errorSection = "Send message";
                email.Send();
            }
            catch (Exception e)
            {

                if (!File.Exists(logFile))
                {
                    using (StreamWriter writer = File.CreateText(logFile))
                    {
                        writer.WriteLine(DateTime.Now.ToString("dd.MM.yy HH:mm:ss") + "   " + errorSection);
                        writer.WriteLine("Error: " + e.Message);
                    }
                }
                else
                {
                    StreamWriter writer = new StreamWriter(logFile, true);
                    using (writer)
                    {
                        writer.WriteLine(DateTime.Now.ToString("dd.MM.yy HH:mm:ss") + "   " + errorSection);
                        writer.WriteLine("Error: " + e.Message);
                    }
                }

                return 1;
            }
            return 0;

        }

        private static bool RedirectionUrlValidationCallback(string redirectionUrl)
        {
            // The default for the validation callback is to reject the URL.
            bool result = false;

            Uri redirectionUri = new Uri(redirectionUrl);

            // Validate the contents of the redirection URL. In this simple validation
            // callback, the redirection URL is considered valid if it is using HTTPS
            // to encrypt the authentication credentials. 
            if (redirectionUri.Scheme == "https")
            {
                result = true;
            }
            return result;
        }

        private static bool CertificateValidationCallBack(
            object sender,
            System.Security.Cryptography.X509Certificates.X509Certificate certificate,
            System.Security.Cryptography.X509Certificates.X509Chain chain,
            System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            // If the certificate is a valid, signed certificate, return true.
            if (sslPolicyErrors == System.Net.Security.SslPolicyErrors.None)
            {
                return true;
            }

            // If there are errors in the certificate chain, look at each error to determine the cause.
            if ((sslPolicyErrors & System.Net.Security.SslPolicyErrors.RemoteCertificateChainErrors) != 0)
            {
                if (chain != null && chain.ChainStatus != null)
                {
                    foreach (System.Security.Cryptography.X509Certificates.X509ChainStatus status in chain.ChainStatus)
                    {
                        if ((certificate.Subject == certificate.Issuer) &&
                           (status.Status == System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.UntrustedRoot))
                        {
                            // Self-signed certificates with an untrusted root are valid. 
                            continue;
                        }
                        else
                        {
                            if (status.Status != System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.NoError)
                            {
                                // If there are any other errors in the certificate chain, the certificate is invalid,
                                // so the method returns false.
                                return false;
                            }
                        }
                    }
                }

                // When processing reaches this line, the only errors in the certificate chain are 
                // untrusted root errors for self-signed certificates. These certificates are valid
                // for default Exchange server installations, so return true.
                return true;
            }
            else
            {
                // In all other cases, return false.
                return false;
            }

            //return true;
        }

    }
}
