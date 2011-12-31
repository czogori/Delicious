using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delicious.Helpers
{
    class Constant
    {
        public const string BASE_URL = "https://api.del.icio.us/v1/";
        public const string SET_CORRECT_RESPONSE = "<result>ok</result>";
        public const string RENAME_CORRECT_RESPONSE = "<result code=\"done\" />";
        public const string DELETE_CORRECT_RESPONSE = "<result code=\"done\" />";


        public const string POST_ALL = "posts/all";
        public const string POST_RECENT = "posts/recent";
        public const string POST_SUGGEST = "posts/suggest";
        public const string POST_ADD = "posts/add";
        public const string POST_DATE = "posts/date";
        public const string POST_HASH = "posts/add";

        public const string TAG_ALL = "tags/get";
        public const string TAG_RENAME = "tags/rename";
        public const string TAG_DELETE = "tags/delete";

        public const string BUNDLE_ALL = "tags/bundles/all";
        public const string BUNDLE_SET = "tags/bundles/set";
        public const string BUNDLE_DELETE = "tags/bundles/delete";

         
    }
}
