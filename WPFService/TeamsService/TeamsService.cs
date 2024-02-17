using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBO.DTO;
using WPFDAO.SimpleSecurityDAO;
using WPFRepo.TeamsRepo;

namespace WPFService.TeamsService
{
    public class TeamsService : ITeamsService
    {
        private TeamsRepo teamsRepo = null;

        public TeamsService()
        {
            teamsRepo = new TeamsRepo();
        }

        public TeamDTO GetTeamByManagerID(int managerID) => teamsRepo.GetTeamByManagerID(managerID);

        public bool UpdateTeamName(int teamID, string newTeamName) => teamsRepo.UpdateTeamName(teamID, newTeamName);

        public int GetTeamIDByManagerID(int managerID) => teamsRepo.GetTeamIDByManagerID(managerID);

        public void ClearTeamSession() => teamsRepo.ClearTeamSession();
    }
}
