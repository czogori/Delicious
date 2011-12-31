using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace Delicious.Helpers.Converters
{
    class BooleanTypeConverter : ITypeConverter<string, bool>
    {
        public bool Convert(ResolutionContext context)
        {
            return context.SourceValue.ToString().Equals("yes");
        }
    }
}
