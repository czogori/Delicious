using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace Delicious.Helpers.Converters
{
    class TagsTypeConverter : ITypeConverter<string, List<Tag>>
    {
        public List<Tag> Convert(ResolutionContext context)
        {
            List<Tag> tags = new List<Tag>();
            string[] tagNames = context.SourceValue.ToString().Split(new Char[] { ' ' });
            foreach (string tagName in tagNames)
            {
                tags.Add(new Tag(tagName));
            }
            return tags;
        }
    }
}
