using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delicious.Models;
using System.Collections.ObjectModel;
using AutoMapper;
using System.Xml.Linq;
using Delicious.Helpers.Converters;
using Delicious.Helpers;

namespace Delicious.Services
{
    public class BundleService : IBundleService
    {
        private IConnection connection;

        public BundleService(IConnection connection)
        {
            this.connection = connection;

            Mapper.CreateMap<XDocument, ReadOnlyCollection<Bundle>>().ConvertUsing<ResponseBundleAllConverter>();
        }

        public ReadOnlyCollection<Bundle> GetAll(string bundleName = "")
        {
            //Console.WriteLine();
            var postsXml = connection.GetXmlDocument(BundleQuery.All(bundleName));
            //Console.WriteLine(postsXml);
            return Mapper.Map<XDocument, ReadOnlyCollection<Bundle>>(postsXml);            
            //return new ReadOnlyCollection<Bundle>(new List<Bundle>());
        }

        public bool Set(string bundleName, List<string> tags)
        {
            return true;
        }

        public bool Delete(string bundleName)
        {
            return true;
        }
    }
}
