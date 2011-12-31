using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Delicious.Models;

namespace Delicious
{
    public interface IPostService
    {
        bool Add(Post post);
        //void Delete();
        //List<Post> Get();
        ReadOnlyCollection<Post> GetAll();
        ReadOnlyCollection<Post> GetRecent();
        ReadOnlyCollection<DeliciousDate> GetDeliciousDates(string tag);
        ReadOnlyCollection<PostHash> GetPostHashes();
        Suggest GetSuggest(string tag);
    }
}
