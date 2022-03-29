using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScrumBoard.Services;
using ScrumBoardLib.model;

namespace ScrumBoard.Pages.UserStories
{
    public class UserStoryDetailedModel : PageModel
    {
        // instance field
        private IUserStoryService _userStoryService;

        // property
        public UserStory UserStory { get; set; }
        public String Message { get; set; }


        // constructor - injekt userStory service
        public UserStoryDetailedModel(IUserStoryService userStoryService)
        {
            _userStoryService = userStoryService;
            Message = null;
        }

        public void OnGet(int id)
        {
            Message = null;
            try
            {
                UserStory = _userStoryService.GetById(id);
            }
            catch (KeyNotFoundException knfe)
            {
                Message = "No userstory with id " + id;
            }
        }
    }
}
