using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WindowsFormsApp1.Contexts;

namespace WindowsFormsApp1.Helpers
{
    public class CheckUserCredentialsHelper
    {
        private readonly AppDbContext _context;

        public CheckUserCredentialsHelper()
        {
            _context = new AppDbContext();
        }

        public bool CheckUserCredentials(string email, string password)
        {
            return _context.RegisterEntities.Any(u => u.Email == email && u.PasswordHash == password);
        }
    }
}
