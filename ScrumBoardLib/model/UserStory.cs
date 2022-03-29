using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumBoardLib.model
{
    public enum UserStoryStateType  {ProductBacklog, ToDo, Doing, Done, DoneDone}
    public class UserStory
    {
        private int _id;
        private String _title;
        private String _description;
        private int _storyPoints;
        private int _businessValue;
        private UserStoryStateType _state;

        public UserStory():this(0, "dummy", "dummydummy")
        {
        }

        public UserStory(string title, string description) : this(0, "dummy", "dummydummy")
        {
        }

        public UserStory(int id, string title, string description)
        {
            _id = id;
            Title = title;
            Description = description;
            _storyPoints = 0;
            _businessValue = 0;
            _state = UserStoryStateType.ProductBacklog;
        }

        

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("title must be at least 3 char. long");

                }
                if (value.Length < 3)
                {
                    throw new ArgumentException("title must be at least 3 char. long");
                }

                _title = value;
            }
        }

        public string Description
        {
            get => _description;
            set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Description must be at least 10 char. long");

                }
                if (value.Length < 10)
                {
                    throw new ArgumentException("Description must be at least 10 char. long");
                }
                _description = value; }
        }

        public int StoryPoints
        {
            get => _storyPoints;
            set {
                if (value < 0)
                {
                    throw new ArgumentException("StoryPoints must be Zero or positive");
                }
                _storyPoints = value;
            }
        }

        public int BusinessValue
        {
            get => _businessValue;
            set
            {
                if (value < 0 || 10 < value)
                {
                    throw new ArgumentException("BusinessValue must be between 0-10 both incl.");
                }
                _businessValue = value;
            }
        }

        public UserStoryStateType State
        {
            get => _state;
            set => _state = value;
        }


        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Title)}: {Title}, {nameof(Description)}: {Description}, {nameof(StoryPoints)}: {StoryPoints}, {nameof(BusinessValue)}: {BusinessValue}, {nameof(State)}: {State}";
        }
    }
}
