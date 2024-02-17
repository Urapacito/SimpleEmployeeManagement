using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBO.DTO;
using WPFDAO.TeamDAO;

namespace WPFRepo.TeamsRepo
{
    public class TeamsRepo : ITeamsRepo
    {
        private TeamsDAO teamsDAO = null;

        public TeamsRepo()
        {
            teamsDAO = new TeamsDAO();
        }

        public TeamDTO GetTeamByManagerID(int managerID) => teamsDAO.GetTeamByManagerID(managerID);

        public bool UpdateTeamName(int teamID, string newTeamName) => teamsDAO.UpdateTeamName(teamID, newTeamName);

        public int GetTeamIDByManagerID(int managerID) => teamsDAO.GetTeamIDByManagerID(managerID);

        public void ClearTeamSession() => teamsDAO.ClearTeamSession();
    }
}
