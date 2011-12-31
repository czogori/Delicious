using System;
using System.Linq;
using System.Collections.ObjectModel;
using Delicious.Helpers;

namespace Delicious.Services
{
    public class TagService : ITagService
    {
        private IConnection connection;

        public TagService(IConnection connection)
        {
            this.connection = connection;
        }

        #region ITagService Members

        public ReadOnlyCollection<Tag> GetAll()
        {
            var xmlResponse = connection.GetXmlDocument(TagQuery.All());
            var tags = (from tag in xmlResponse.Descendants("tag")
                    select new Tag
                    {
                        Name = tag.Attribute("tag").Value,
                        Count = Convert.ToInt32(tag.Attribute("count").Value)
                    }).ToList<Tag>();
            return new ReadOnlyCollection<Tag>(tags);
        }

        public bool Delete(string name)
        {
            var xmlResponse = connection.GetXmlDocument(TagQuery.Delete(name));
            Console.WriteLine(xmlResponse.ToString());
            return xmlResponse.ToString() == Constant.DELETE_CORRECT_RESPONSE;
        }

        public bool Rename(string oldName, string newName)
        {
            var xmlResponse = connection.GetXmlDocument(TagQuery.Rename(oldName, newName));
            Console.WriteLine(xmlResponse.ToString());
            return xmlResponse.ToString() == Constant.RENAME_CORRECT_RESPONSE;
        }

        #endregion
    }
}
