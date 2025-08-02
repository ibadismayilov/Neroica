using System;
using System.Windows.Forms;
using WindowsFormsApp1.Entities.Auth;

namespace WindowsFormsApp1.UserControls
{
    public partial class UC_VerifyEmailOTP
    {
        public class VerificationCompletedEventArgs : EventArgs
        {
            public DialogResult Result { get; }
            public RegisterEntity VerifiedUser { get; }

            public VerificationCompletedEventArgs(DialogResult result, RegisterEntity verifiedUser = null)
            {
                Result = result;
                VerifiedUser = verifiedUser;
            }
        }
    }
}
