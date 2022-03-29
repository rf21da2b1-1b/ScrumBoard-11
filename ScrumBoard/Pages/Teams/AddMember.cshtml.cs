using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScrumBoard.Services;
using ScrumBoardLib.model;

namespace ScrumBoard.Pages.Teams
{
    public class AddMemberModel : PageModel
    {
        private IMemberService _memberService;
        public AddMemberModel(IMemberService memberService)
        {
            _memberService = memberService;
        }

        /*
         * Properties
         */
        [BindProperty]
        public TeamMember TeamMember { get; set; }
        [BindProperty] public String Rolle { get; set; }

       
        public void OnGet()
        {
            TeamMember = new TeamMember();
        }

        public void OnPost()
        {
            _memberService.Create(TeamMember);
        }


    }
}
