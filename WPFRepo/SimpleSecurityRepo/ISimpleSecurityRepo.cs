using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFRepo.SimpleSecurityRepo
{
    public interface ISimpleSecurityRepo
    {
        public string GetUserRole(string username, string password);
    }
}
