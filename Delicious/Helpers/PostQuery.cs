using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace Delicious.Helpers
{
    class PostQuery
    {
        public static string All()
        {
            return Url.For(Constant.POST_ALL);
        }

        public static string Recent()
        {
            return Url.For(Constant.POST_RECENT);
        }

        public static string Add(string url, string description, string extended = "", string tags = "",
                        DateTime? date = null, bool shared = false, bool replace = false)
        {
            UrlQuery query = new UrlQuery(Url.For(Constant.POST_ADD));
            query.Add("url", url);
            query.Add("decription", description);
            query.Add("extended", extended);
            query.Add("tags", tags);
            query.Add("dt", date.Value.ToLongDateString());
            query.Add("shared", shared.ToString());
            query.Add("replace", replace.ToString());
            return query.ToString();
        }

        public static string Dates(string tag = "")
        {
            UrlQuery query = new UrlQuery(Url.For(Constant.POST_DATE));
            query.Add("tag", tag);            
            return query.ToString();
        }

        public static string Hashes()
        {
            return Url.For(Constant.POST_HASH);
        }

        public static string Suggest(string url)
        {
            UrlQuery query = new UrlQuery(Url.For(Constant.POST_SUGGEST));
            query.Add("url", url);
            return query.ToString();
        }
    }
}
