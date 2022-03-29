using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScrumBoardLib.model;

namespace ScrumBoard.Services
{
    public interface IUserStoryService
    {
        List<UserStory> GetAll();
        UserStory GetById(int id);
        UserStory Create(UserStory newUserStory);
        UserStory Delete(int id);
        UserStory Modify(UserStory modifiedUserStory);
    }
}
