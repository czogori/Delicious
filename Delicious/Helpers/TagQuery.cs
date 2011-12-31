using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delicious.Helpers
{
    public class TagQuery
    {        
        public static string All()
        {
            return Url.For(Constant.TAG_ALL);
        }

        public static string Rename(string oldName, string newName)
        {
            UrlQuery query = new UrlQuery(Url.For(Constant.TAG_RENAME));
            query.Add("old", oldName);
            query.Add("new", newName);
            return query.ToString();            
        }

        public static string Delete(string name)
        {
            UrlQuery query = new UrlQuery(Url.For(Constant.TAG_DELETE));
            query.Add("tag", name);            
            return query.ToString();            
        }
    }
}
