using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScrumBoard.Services;
using ScrumBoardLib.model;

namespace ScrumBoard.Pages.Teams
{
    public class IndexModel : PageModel
    {
        private IMemberService _memberService;


        /*
         * Properties
         */
        public List<TeamMember> TeamMembers { get; set; }

        public IndexModel(IMemberService memberService)
        {
            _memberService = memberService;
        }

        public void OnGet()
        {
            TeamMembers = _memberService.GetAll();
        }


    }
}
