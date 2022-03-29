using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScrumBoardLib.model;

namespace ScrumBoard.util
{
    public class SortByBusinessValue:IComparer<UserStory>
    {
        public int Compare(UserStory? x, UserStory? y)
        {
            if (x == null || y == null)
            {
                return 0;
            }

            return y.BusinessValue - x.BusinessValue;
        }
    }
}
