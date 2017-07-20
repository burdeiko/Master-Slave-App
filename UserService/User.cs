using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService
{
    public class User: IEquatable<User>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public int Id { get; set; }

        public bool Equals(User other)
        {
            if (other == null)
                return false;
            if (FirstName == other.FirstName && LastName == other.LastName && Age == other.Age)
                return true;
            return false;
        }

        public override bool Equals(object obj)
        {
            var other = obj as User;
            if (other == null)
                return false;
            return this.Equals(other);
        }
    }
}
