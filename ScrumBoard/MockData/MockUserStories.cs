using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScrumBoardLib.model;

namespace ScrumBoard.MockData
{
    public class MockUserStories
    {
        private static List<UserStory> userStories = new List<UserStory>() {
            new UserStory(1,"Create Story", "As P.O I want to create a new Story So ..."),
            new UserStory(2,"Edit Story", "As P.O I want to edit a Story So ..."),
            new UserStory(3,"Move Story", "As team member I want to move a Story So ..."),
            new UserStory(4,"Delete Story", "As team member to delete")
        };


        public static List<UserStory> GetMockUserStories()
        {
            return new List<UserStory>(userStories);
        }

    }
}
