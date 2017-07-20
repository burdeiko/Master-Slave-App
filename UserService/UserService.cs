using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Exceptions;

namespace UserService
{
    public class UserService : IUserService
    {
        private List<User> storage = new List<User>();
        private IdCalculator idCalculator = new IdCalculator();
        public void Add(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (!UserIsValid(user))
                throw new UserValidationException();
            if (storage.Contains(user))
                throw new AlreadyExistsException();
            user.Id = idCalculator.CreateId();
            storage.Add(user);
        }

        public void Remove(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (!storage.Remove(user))
                throw new NotExistedException();
        }

        public IEnumerable<User> Search(Func<User, bool> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            return storage.Where(predicate);
        }

        private bool UserIsValid(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (user.Age < 0)
                return false;
            if (user.FirstName == null || user.FirstName == string.Empty)
                return false;
            if (user.LastName == null || user.LastName == string.Empty)
                return false;
            return true;
        }
    }
}
