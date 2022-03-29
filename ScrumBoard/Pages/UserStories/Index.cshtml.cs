using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScrumBoard.Services;
using ScrumBoard.util;
using ScrumBoardLib.model;

namespace ScrumBoard.Pages.UserStories
{
    public class IndexModel : PageModel
    {
        private IUserStoryService _userStoryService;
        private static List<UserStory> _originalListe;


        public List<UserStory> UserStories { get; private set; }
        public List<String> SortTypeValues { get; private set; }

        [BindProperty] 
        public String SortType { get; set; }

        public IndexModel(IUserStoryService userStoryService)
        {
            _userStoryService = userStoryService;
            SortTypeValues = new List<string>()
            {
                "Almindelig", "Business Values", "Mangler Business Value", "Mangler Story Points"
            };

        }

        public void OnGet()
        {
            _originalListe = _userStoryService.GetAll();
            UserStories = new List<UserStory>(_originalListe);
        }

        public IActionResult OnPost()
        {
                    DoFind();
                    return Page();
        }

        private void DoFind()
        {
            switch (SortType)
            {
                case "Almindelig":
                    UserStories = new List<UserStory>(_originalListe);
                    break;

                case "Business Values":
                    UserStories = new List<UserStory>(_originalListe);
                    UserStories.Sort(new SortByBusinessValue());
                    //UserStories.Sort((us1, us2) =>
                    //{
                    //    return us2.BusinessValue - us1.BusinessValue;
                    //});
                    break;

                case "Mangler Business Value":
                    UserStories = _originalListe.Where(us => us.BusinessValue == 0).ToList();
                    break;

                case "Mangler Story Points":
                    UserStories = _originalListe.Where(us => us.StoryPoints == 0).ToList();
                    break;
            }
        }

        public string ShowDescription(String desc)
        {
            return (desc.Length < 25) ? desc : desc.Substring(0, 24) + " ...";
        }

       

    }
}
