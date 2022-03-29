using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScrumBoard.Services;
using ScrumBoardLib.model;

namespace ScrumBoard.Pages.UserStories
{
    public class DeleteUserStoryModel : PageModel
    {
        private IUserStoryService _userStoryService;

        public DeleteUserStoryModel(IUserStoryService userStoryService)
        {
            _userStoryService = userStoryService;
        }


        [BindProperty]
        public UserStory UserStory { get; set; }


        public void OnGet(int id)
        {
            UserStory = _userStoryService.GetById(id);

        }

        public IActionResult OnPost(int id)
        {
            UserStory deletedUserStory = _userStoryService.Delete(id);

            return RedirectToPage("Index");
        }
    }
}
