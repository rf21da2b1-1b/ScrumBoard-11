
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumBoardLib.model
{
    public class TeamMember
    {
        private int _id;
        private string _name;
        private string _email;
        private string _role;

        public TeamMember():this(-1,"","","Member")
        {
        }

        public TeamMember(int id, string name, string email, string role)
        {
            _id = id;
            _name = name;
            _email = email;
            _role = role;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public string Role
        {
            get => _role;
            set => _role = value;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Email)}: {Email}, {nameof(Role)}: {Role}";
        }
    }
}
