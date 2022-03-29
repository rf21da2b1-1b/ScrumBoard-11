using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScrumBoard.Services;
using ScrumBoardLib.model;

namespace ScrumBoard.Pages.UserStories
{
    public class CreateUserStoryModel : PageModel
    {
        // servicen
        private IUserStoryService _userStoryService;
        private int _storyPointsDropDown;

        // properties
        [BindProperty]
        public UserStory UserStory { get; set; }

        [BindProperty]
        public List<int> AreChecked { get; set; }

        [BindProperty]
        public int StoryPoints { get; set; }

        [BindProperty]
        public int StoryPointsDropDown
        {
            get => _storyPointsDropDown;
            set
            {
                _storyPointsDropDown = value;
                if (value == 8)
                {
                    int i = 6;
                }
            }
        }


        public List<int> BusinessRadioValues { get; }
        public List<int> StoryPointsValues { get; }



        public CreateUserStoryModel(IUserStoryService userStoryService)
        {
            _userStoryService = userStoryService;
            BusinessRadioValues = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            StoryPointsValues = new List<int>() { 0, 1, 2, 3, 5, 8, 13, 21, 34, 45};
            AreChecked = new List<int>();
        }



        public void OnGet()
        {
            UserStory = new UserStory();
        }

        public void OnPost()
        {
            if (AreChecked != null && AreChecked.Count > 0)
            {
                UserStory.BusinessValue = AreChecked[0];
            }
            //UserStory.StoryPoints = StoryPoints;
            UserStory.StoryPoints = StoryPointsDropDown;

            _userStoryService.Create(UserStory);
        }
    }
}
