using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delicious.Helpers
{
    class BundleQuery
    {
        public static string All(string name = "")
        {
            UrlQuery query = new UrlQuery(Url.For(Constant.BUNDLE_ALL));
            query.Add("name", name);
            return query.ToString();
        }
    }
}
