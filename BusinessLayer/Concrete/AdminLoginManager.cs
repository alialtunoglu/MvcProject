using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminLoginManager: IAdminLoginService
    {
        private readonly IAdminDal _adminDal; // Veri erişim katmanını kullanıyoruz.

        public AdminLoginManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public bool ValidateAdmin(string username, string password)
        {
            // Parolayı hashle
            var hashedPassword = HashPassword(password);
            
            // Kullanıcıyı doğrula
            var admin = _adminDal.Get(x => x.AdminUserName == username && x.AdminPassword == hashedPassword);
            return admin != null;
        }

        private string HashPassword(string password)
        {
            // SHA256 ile parola hashleme örneği
            return Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
        }
    }
}
