using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDAO.SimpleSecurityDAO;

namespace WPFRepo.SimpleSecurityRepo
{
    public class SimpleSecurityRepo : ISimpleSecurityRepo
    {
        private SimpleSecurityDAO SimpleSecurityDAO = null;

        public SimpleSecurityRepo()
        {
            SimpleSecurityDAO = new SimpleSecurityDAO();
        }

        public string GetUserRole(string username, string password) => SimpleSecurityDAO.GetUserRole(username, password);
    }
}
