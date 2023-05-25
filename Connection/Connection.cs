using System.Xml.Serialization;

namespace MauiApp3.Connection
{
    public sealed class Connection
    {
        [XmlElement()]
        public string Server { get; set; }

        [XmlElement()]
        public string Database { get; set; }

        [XmlElement()]
        public string User { get; set; }

        [XmlElement()]
        public string Password { get; set; }

        [XmlElement()]
        public string Authentication { get; set; }
    }
}
