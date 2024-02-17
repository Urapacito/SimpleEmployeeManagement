using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDAO.SimpleSecurityDAO
{
    public interface ISecurity
    {
        public string GetUserRole(string username, string password);
    }
}
