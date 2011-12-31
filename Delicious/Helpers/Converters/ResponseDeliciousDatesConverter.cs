using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delicious.Models;
using System.Xml.Linq;
using AutoMapper;
using System.Collections.ObjectModel;

namespace Delicious.Helpers.Converters
{
    class ResponseDeliciousDatesConverter : ITypeConverter<XDocument, ReadOnlyCollection<DeliciousDate>>
    {
        public ResponseDeliciousDatesConverter()
        {
            Mapper.CreateMap<string, DateTime>().ConvertUsing<DateTimeTypeConverter>();
        }
        #region ITypeConverter<XDocument,List<DeliciousDate>> Members

        public ReadOnlyCollection<DeliciousDate> Convert(ResolutionContext context)
        {
            var items = context.SourceValue as XDocument;

            var result = (from date in items.Descendants("date")
                    select new DeliciousDate
                    {
                        Date = Mapper.Map<string, DateTime>(date.Attribute("date").Value),
                        Count = UInt32.Parse(date.Attribute("count").Value)
                    }).ToList<DeliciousDate>();
            return new ReadOnlyCollection<DeliciousDate>(result);
        }

        #endregion
    }
}
