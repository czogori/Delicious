using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Net;

namespace Delicious
{
    public class Connection : IConnection
    {
        private string login;
        private string password;        

        public Connection()
        {
            login = Configuration.Configure().GetUserName();
            password = Configuration.Configure().GetPassword();         
        }

        public XDocument GetXmlDocument(string url)
        {
            using (WebClient wc = new WebClient())
            {
                //wc.Proxy = null;                                
                wc.Credentials = new NetworkCredential(login, password);
                string str = wc.DownloadString(url);
                return XDocument.Parse(str);                
            }
        }
    }
}
