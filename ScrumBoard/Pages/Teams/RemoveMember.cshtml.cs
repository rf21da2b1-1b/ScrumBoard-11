using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScrumBoard.Services;
using ScrumBoardLib.model;

namespace ScrumBoard.Pages.Teams
{
    public class RemoveMemberModel : PageModel
    {


        private IMemberService _memberService;
        public RemoveMemberModel(IMemberService memberService)
        {
            _memberService = memberService;
        }


        /*
         * Properties
         */
       
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

        public IActionResult OnPost(int id, string answer)
        {
            if (!string.IsNullOrWhiteSpace(answer) && answer == "YES")
            {
                // remove member
                _memberService.Delete(id);
            }

            return RedirectToPage("/Teams/Index");
        }
    }
}
