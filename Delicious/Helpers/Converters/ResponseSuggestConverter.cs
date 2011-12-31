using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delicious.Models;
using System.Xml.Linq;
using AutoMapper;

namespace Delicious.Helpers.Converters
{
    class ResponseSuggestConverter : ITypeConverter<XDocument, Suggest>
    {
        #region ITypeConverter<XDocument,Suggest> Members

        public Suggest Convert(ResolutionContext context)
        {
            
            var items = context.SourceValue as XDocument;
            return new Suggest
            {
                Popular = items.Descendants("popular").Select(x => x.Attribute("tag").Value).ToList<string>(),
                Recommended = items.Descendants("recommended").Select(x => x.Attribute("tag").Value).ToList<string>(),
                Network = items.Descendants("network").Select(x => x.Attribute("tag").Value).ToList<string>()
            };           
        }

        #endregion
    }
}
