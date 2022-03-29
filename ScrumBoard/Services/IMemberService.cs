using System.Collections.Generic;
using ScrumBoardLib.model;

namespace ScrumBoard.Services
{
    public interface IMemberService
    {
        List<TeamMember> GetAll();
        TeamMember GetById(int id);
        TeamMember GetScrumMaster();
        TeamMember Create(TeamMember newMember);
        TeamMember Delete(int id);
        TeamMember Modify(TeamMember modifiedMember);
    }
}
