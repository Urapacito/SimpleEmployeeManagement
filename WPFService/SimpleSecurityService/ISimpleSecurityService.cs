using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFService.SimpleSecurityService
{
    public interface ISimpleSecurityService
    {
        public string GetUserRole(string username, string password);
    }
}
