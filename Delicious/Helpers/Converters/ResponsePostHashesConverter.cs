using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AutoMapper;
using Delicious.Models;
using System.Collections.ObjectModel;

namespace Delicious.Helpers.Converters
{
    class ResponsePostHashesConverter : ITypeConverter<XDocument, ReadOnlyCollection<PostHash>>
    {
        #region ITypeConverter<XDocument,List<PostHash>> Members

        public ReadOnlyCollection<PostHash> Convert(ResolutionContext context)
        {
            var items = context.SourceValue as XDocument;
            var result =  (from post in items.Descendants("post")
                    select new PostHash
                    {
                        Meta = post.Attribute("meta").Value,
                        Url = post.Attribute("url").Value
                    }).ToList<PostHash>();
            return new ReadOnlyCollection<PostHash>(result);
        }

        #endregion
    }
}
