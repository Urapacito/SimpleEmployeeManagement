using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFRepo.SimpleSecurityRepo;

namespace WPFService.SimpleSecurityService
{
    public class SimpleSecurityService : ISimpleSecurityService
    {
        private readonly ISimpleSecurityRepo simpleSecurityRepo = null;

        public SimpleSecurityService()
        {
            simpleSecurityRepo = new SimpleSecurityRepo();
        }

        public string GetUserRole(string username, string password) => simpleSecurityRepo.GetUserRole(username, password);
    }
}
