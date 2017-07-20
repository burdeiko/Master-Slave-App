using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService
{
    public class IdCalculator
    {
        private int counter;
        public int CreateId()
        {
            return counter++;
        }
    }
}
