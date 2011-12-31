using System.Xml.Linq;
using Delicious.Helpers;
using Moq;
using NUnit.Framework;
using Delicious.Services;

namespace Delicious.Tests
{
    [TestFixture]
    public class TagServiceTest
    {
        [SetUp]
        public void Initialize()
        {            
        }
      

        [Test]
        public void GetAllTagsTest()
        {
            XDocument response = new XDocument(
               new XDeclaration("1.0", "utf-8", "yes"),
               new XElement("tags",
                  new XElement("tag",
                     new XAttribute("count", "1"),
                     new XAttribute("tag", "c#")),
                  new XElement("tag",
                     new XAttribute("count", "2"),
                     new XAttribute("tag", "ruby"))));
            
            var mockConnection = new Mock<IConnection>();
            mockConnection.Setup(x => x.GetXmlDocument(Constant.TAG_ALL)).Returns(response);
            ITagService tagService = new TagService(mockConnection.Object);
            var tags = tagService.GetAll();

            Assert.AreEqual(2, tags.Count);

            Assert.AreEqual(1, tags[0].Count);
            Assert.AreEqual("c#", tags[0].Name);

            Assert.AreEqual(2, tags[1].Count);
            Assert.AreEqual("ruby", tags[1].Name);
        }

    }
}
