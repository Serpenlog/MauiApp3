using System;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Xml.Serialization;
using MauiApp3.Connection;

namespace MauiApp3.Connection
{
    [XmlRoot("ConnectionSettings")]
    public class ConnectionSettings
    {
        [XmlElement()]
        public Connection Connection { get; set; } = new Connection();

        public string GetConnection()
        {
            return GetConnection(6);
        }

        public string GetConnection(int timeout)
        {
            var bldr = new SqlConnectionStringBuilder
            {
                InitialCatalog = Connection.Database,
                DataSource = Connection.Server,
                ConnectTimeout = timeout,
                MaxPoolSize = 100,
                MultipleActiveResultSets = true
            };

            // we will only use SQL Auth
            switch (Connection.Authentication)
            {
                case "Windows":
                    bldr.IntegratedSecurity = true;
                    break;
                case "SQL":
                    bldr.UserID = Connection.User;
                    bldr.Password = Connection.Password;
                    break;
            }

            return bldr.ConnectionString;
        }


        public void Deserialize()
        {
            string filename = "MauiApp3.Connection.connection.xml"; // TODO: Replace with actual path
            if (!File.Exists(filename)) throw new FileNotFoundException();

            var serializer = new XmlSerializer(typeof(ConnectionSettings));
            using (var stream = File.OpenRead(filename))
            {
                var other = (ConnectionSettings)(serializer.Deserialize(stream));
                Connection = other.Connection;
            }
        }
    }
}
