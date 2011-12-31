using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delicious
{
    public class Configuration
    {
        private static Configuration @this = null;
        private string userName;
        private string password;
        private const string baseUrl = "https://api.del.icio.us/v1/";

        private Configuration ()
	    {
	    }

        public static Configuration Configure()
        {
            if(@this == null)
            {
                @this = new Configuration();
            }
            return @this;
        }

        public Configuration SetUserName(string userName)
        {
            this.userName = userName;
            return this;
        }

        public Configuration SePassword(string password)
        {
            this.password = password;
            return this;
        }

        internal string GetUserName()
        {
            return userName;
        }

        internal string GetPassword()
        {
            return password;
        }

        public static string GetBaseUser()
        {
            return baseUrl;
        }
    }
}
