using EcommerceFull.Models;
using Newtonsoft.Json;

namespace EcommerceFull.Data
{
    public class DBAutent
    {
        private readonly DBContext _context;

        public DBAutent(DBContext context, IHttpContextAccessor httpcontext)
        {
            _context = context;
        }


        public UserModel VerifLogin(string email, string pass)
        {
                return _context.Users.Where(u => u.UserEmail == email && u.UserPass == pass).FirstOrDefault();
                
        }


        // guardar section 

        public void CreatSection(UserModel userModel)
        {
            string user = JsonConvert.SerializeObject(userModel);
        }
    }
}
