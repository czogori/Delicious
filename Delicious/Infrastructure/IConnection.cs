namespace Delicious
{
    public interface IConnection
    {
        System.Xml.Linq.XDocument GetXmlDocument(string query);
    }
}
