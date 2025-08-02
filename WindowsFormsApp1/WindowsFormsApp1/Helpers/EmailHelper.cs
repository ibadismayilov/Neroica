using System.Net;

namespace WindowsFormsApp1.Helpers
{
    public static class EmailHelper
    {
        public static bool IsEmailValid(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                string domain = addr.Host;
                var entries = Dns.GetHostEntry(domain);
                return entries.AddressList.Length > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
