using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScrumBoard.Services;
using ScrumBoardLib.model;
using Enum = System.Enum;

namespace ScrumBoard.Pages.UserStories
{
    public class UpdateUserStoryModel : PageModel
    {
        private IUserStoryService _userStoryService;

        public UpdateUserStoryModel(IUserStoryService userStoryService)
        {
            _userStoryService = userStoryService;

            BusinessValues = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            StoryPointsValues = new List<int>() { 0, 1, 2, 3, 5, 8, 13, 21, 34, 45 };

            StateValues = new List<string>();

            var r = Enum.GetValues(typeof(UserStoryStateType));
            foreach (var e in Enum.GetValues(typeof(UserStoryStateType)))
            {
                StateValues.Add(e.ToString());
            }

            
        }


        [BindProperty]
        public UserStory UserStory { get; set; }

        [BindProperty]
        public String State { get; set; }


        public String ErrorMessage { get; private set; }
        public List<int> BusinessValues { get; private set; }
        public List<int> StoryPointsValues { get; private set; }
        public List<String> StateValues { get; private set; }



        public void OnGet(int id)
        {
            ErrorMessage = "";
            try
            {
                UserStory = _userStoryService.GetById(id);
            }
            catch (KeyNotFoundException ex)
            {
                ErrorMessage = $"En UserStory med id={id} findes ikke";
            }

        }

        public IActionResult OnPost(int id)
        {
            UserStory.Id = id;
            UserStory.State = Enum.Parse<UserStoryStateType>(State);
            
            _userStoryService.Modify(UserStory);
            return RedirectToPage("/UserStories/Index");
        }


    }
}
