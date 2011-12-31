using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Xml.Linq;
using System.Collections.ObjectModel;

namespace Delicious.Helpers.Converters
{
    class ResponsePostAllConverter : ITypeConverter<XDocument, ReadOnlyCollection<Post>>
    {
        public ResponsePostAllConverter()
        {
            Mapper.CreateMap<string, bool>().ConvertUsing<BooleanTypeConverter>();
            Mapper.CreateMap<string, DateTime>().ConvertUsing<DateTimeTypeConverter>();
            Mapper.CreateMap<string, List<Tag>>().ConvertUsing<TagsTypeConverter>();  
        }
        #region ITypeConverter<string,List<Post>> Members

        public ReadOnlyCollection<Post> Convert(ResolutionContext context)
        {
            var items = context.SourceValue as XDocument;
            var result = (from post in items.Descendants("post")
                         select new Post
                         {
                             Description = post.Attribute("description").Value,
                             Extended = post.Attribute("extended").Value,
                             Url = post.Attribute("href").Value,
                             Hash = post.Attribute("hash").Value,
                             Private = Mapper.Map<string, bool>(post.Attribute("private").Value),
                             Shared = Mapper.Map<string, bool>(post.Attribute("shared").Value),
                             Time = Mapper.Map<string, DateTime>(post.Attribute("time").Value),
                             Tags = Mapper.Map<string, List<Tag>>(post.Attribute("tag").Value)
                         }).ToList<Post>();
            return new ReadOnlyCollection<Post>(result);
        }

        #endregion
    }
}
