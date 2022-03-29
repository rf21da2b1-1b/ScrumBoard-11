using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScrumBoard.Services;
using ScrumBoardLib.model;

namespace ScrumBoard.Pages.Teams
{
    public class EditMemberModel : PageModel
    {
        private IMemberService _memberService;
        public EditMemberModel(IMemberService memberService)
        {
            _memberService = memberService;
        }


        /*
         * Properties
         */
        [BindProperty]
        public TeamMember TeamMember { get; set; }
        public String ErrorMessage { get; set; }

        public void OnGet(int id)
        {
            ErrorMessage = "";
            try
            {
                TeamMember = _memberService.GetById(id);
            }
            catch (Exception e)
            {
                ErrorMessage = $"Der er ingen medlemer med id={id}";
            }
        }

        public IActionResult OnPost(int id)
        {
            TeamMember.Id = id;
            _memberService.Modify(TeamMember);
            return RedirectToPage("/Teams/Index");
        }

    }
}
