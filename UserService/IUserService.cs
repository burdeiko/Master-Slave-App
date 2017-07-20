using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService
{
    public interface IUserService
    {
        void Add(User user);
        void Remove(User user);
        IEnumerable<User> Search(Func<User, bool> predicate);
    }
}
