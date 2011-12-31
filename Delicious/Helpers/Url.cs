using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delicious.Helpers
{
    class Url
    {
        public static string For(string action)
        {
            return Constant.BASE_URL + action;
        }    
    }
}
