using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using Delicious.Models;

namespace Delicious.Helpers.Converters
{
    class ResponseBundleAllConverter : ITypeConverter<XDocument, ReadOnlyCollection<Bundle>>
    {
        #region ITypeConverter<XDocument,ReadOnlyCollection<Bundle>> Members

        public ReadOnlyCollection<Bundle> Convert(ResolutionContext context)
        {
            var items = context.SourceValue as XDocument;
            var result = (from date in items.Descendants("bundle")
                    select new Bundle
                    {
                        Name = date.Attribute("name").Value,
                        Tags = date.Attribute("tags").Value.Split(" ".ToArray()).ToList<string>()
                    }).ToList<Bundle>();
            return new ReadOnlyCollection<Bundle>(result);
        }

        #endregion
    }
}
