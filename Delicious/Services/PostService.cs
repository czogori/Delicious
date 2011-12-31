using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using AutoMapper;
using Delicious.Models;
using Delicious.Helpers;
using Delicious.Helpers.Converters;

namespace Delicious.Services
{
    public class PostService : IPostService
    {
        private IConnection connection;      

        public PostService(IConnection connection)
        {
            this.connection = connection;

            Mapper.CreateMap<XDocument, ReadOnlyCollection<Post>>().ConvertUsing<ResponsePostAllConverter>();
            Mapper.CreateMap<XDocument, ReadOnlyCollection<DeliciousDate>>().ConvertUsing<ResponseDeliciousDatesConverter>();
            Mapper.CreateMap<XDocument, ReadOnlyCollection<PostHash>>().ConvertUsing<ResponsePostHashesConverter>();
            Mapper.CreateMap<XDocument, Suggest>().ConvertUsing<ResponseSuggestConverter>();
        }

        public ReadOnlyCollection<Post> GetAll()
        {
            return GetPosts(PostQuery.All());
        }

        public ReadOnlyCollection<Post> GetRecent()
        {
            return GetPosts(PostQuery.Recent());
        }

        public bool Add(Post post)
        {
            return Add(post.Url, post.Description, post.Extended, post.Tags, post.Time, post.Shared);
        }

        public bool Add(string url, string description, string extended = "", List<Tag> tags = null,
                        DateTime? date = null, bool shared = false, bool replace = false)
        {
            string tagsAsString = "";
            return Add(url, description, extended, tagsAsString, date, shared, replace);
        }

        public bool Add(string url, string description, string extended = "", string tags = "",
                        DateTime? date = null, bool shared = false, bool replace = false)
        {
            connection.GetXmlDocument(PostQuery.Add(url, description, extended, tags, date, shared, replace));
            return true;
        }


        public ReadOnlyCollection<DeliciousDate> GetDeliciousDates(string tag = "")
        {
            var postsXml = connection.GetXmlDocument(PostQuery.Dates(tag));
            return Mapper.Map<XDocument, ReadOnlyCollection<DeliciousDate>>(postsXml);            
        }

        public ReadOnlyCollection<PostHash> GetPostHashes()
        {
            var postsXml = connection.GetXmlDocument(PostQuery.Hashes());
            return Mapper.Map<XDocument, ReadOnlyCollection<PostHash>>(postsXml);           
        }

        public Suggest GetSuggest(string url)
        {
            if(String.IsNullOrEmpty(url.Trim()))
            {
                throw new Exception("Url could not be empty");
            }
            var postsXml = connection.GetXmlDocument(PostQuery.Suggest(url));
            return Mapper.Map<XDocument, Suggest>(postsXml);                        
        }

        private ReadOnlyCollection<Post> GetPosts(string query)
        {
            var postsXml = connection.GetXmlDocument(query);
            return Mapper.Map<XDocument, ReadOnlyCollection<Post>>(postsXml);            
        }
    }
}
