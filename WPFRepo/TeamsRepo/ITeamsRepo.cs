using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBO.DTO;

namespace WPFRepo.TeamsRepo
{
    public interface ITeamsRepo
    {
        public TeamDTO GetTeamByManagerID(int managerID);

        public bool UpdateTeamName(int teamID, string newTeamName);
        
        public int GetTeamIDByManagerID(int managerID);

        public void ClearTeamSession();
    }
}
