using FranpetteLib.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace FranpetteLib.Serialisation.XMLSerialisation
{
    public class XMLSerialisation
    {
        public static void Deserialise(FClient client, String path)
        {
            if (client == null)
                return;

            List<FApplication> applicationList = new List<FApplication>();

            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode root = doc.DocumentElement;

            root.SelectSingleNode("/franpette/client/id").InnerText = client.Id.ToString();
            root.SelectSingleNode("/franpette/client/name").InnerText = client.Name;
            root.SelectSingleNode("/franpette/client/news").InnerText = client.News;
            root.SelectSingleNode("/franpette/client/serverAddress").InnerText = client.ServerAddress;
            root.SelectSingleNode("/franpette/client/serverPort").InnerText = client.ServerPort.ToString();
            root.SelectSingleNode("/franpette/client/localVersion").InnerText = client.LocalVersion;
            root.SelectSingleNode("/franpette/client/newsOwner").InnerText = client.NewsOwner.Name;
            root.SelectSingleNode("/franpette/client/currentUser").InnerText = client.CurrentUser.Name;

            root.SelectSingleNode("/franpette/user/id").InnerText = client.CurrentUser.Id.ToString();
            root.SelectSingleNode("/franpette/user/name").InnerText = client.CurrentUser.Name;
            root.SelectSingleNode("/franpette/user/description").InnerText = client.CurrentUser.Description;

            XmlNodeList nodeList;
            nodeList = root.SelectNodes("/franpette/application/app");

            foreach (XmlNode app in nodeList)
            {
                FApplication application = new FApplication();

                app.SelectSingleNode("id").InnerText = application.Id.ToString();
                app.SelectSingleNode("name").InnerText = application.Name;
                app.SelectSingleNode("description").InnerText = application.Description;
                app.SelectSingleNode("lastUser").InnerText = application.LastUser.Name;
                app.SelectSingleNode("lastDate").InnerText = application.LastDate;
                app.SelectSingleNode("path").InnerText = application.Path;
                app.SelectSingleNode("localVersion").InnerText = application.LocalVersion;
                app.SelectSingleNode("owner").InnerText = application.Owner.Name;
                app.SelectSingleNode("creationDate").InnerText = application.CreationDate;

                applicationList.Add(application);
            }

            doc.Save(path);
        }

        public static FClient Serialise(String path)
        {
            try
            {
                FClient client = new FClient();

                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode root = doc.DocumentElement;

                client.Id = int.Parse(root.SelectSingleNode("/franpette/client/id").InnerText);
                client.Name = root.SelectSingleNode("/franpette/client/name").InnerText;
                client.News = root.SelectSingleNode("/franpette/client/news").InnerText;
                client.ServerAddress = root.SelectSingleNode("/franpette/client/serverAddress").InnerText;
                client.ServerPort = int.Parse(root.SelectSingleNode("/franpette/client/serverPort").InnerText);
                client.LocalVersion = root.SelectSingleNode("/franpette/client/localVersion").InnerText;

                client.NewsOwner = new FUser();
                client.NewsOwner.Id = int.Parse(root.SelectSingleNode("/franpette/client/newsOwner/id").InnerText);
                client.NewsOwner.Name = root.SelectSingleNode("/franpette/client/newsOwner/name").InnerText;
                client.NewsOwner.Description = root.SelectSingleNode("/franpette/client/newsOwner/description").InnerText;

                client.CurrentUser = new FUser();
                client.CurrentUser.Id = int.Parse(root.SelectSingleNode("/franpette/client/currentUser/id").InnerText);
                client.CurrentUser.Name = root.SelectSingleNode("/franpette/client/currentUser/name").InnerText;
                client.CurrentUser.Description = root.SelectSingleNode("/franpette/client/currentUser/description").InnerText;

                XmlNodeList nodeList;
                nodeList = root.SelectNodes("/franpette/application/app");

                client.ApplicationsList = new List<FApplication>();

                foreach (XmlNode app in nodeList)
                {
                    FApplication application = new FApplication();

                    application.Id = int.Parse(app.SelectSingleNode("id").InnerText);
                    application.Name = app.SelectSingleNode("name").InnerText;
                    application.Description = app.SelectSingleNode("description").InnerText;

                    application.LastUser = new FUser();
                    application.LastUser.Id = int.Parse(app.SelectSingleNode("lastUser/id").InnerText);
                    application.LastUser.Name = app.SelectSingleNode("lastUser/name").InnerText;
                    application.LastUser.Description = app.SelectSingleNode("lastUser/description").InnerText;

                    application.LastDate = app.SelectSingleNode("lastDate").InnerText;
                    application.Path = app.SelectSingleNode("path").InnerText;
                    application.LocalVersion = app.SelectSingleNode("localVersion").InnerText;

                    application.Owner = new FUser();
                    application.Owner.Id = int.Parse(app.SelectSingleNode("owner/id").InnerText);
                    application.Owner.Name = app.SelectSingleNode("owner/name").InnerText;
                    application.Owner.Description = app.SelectSingleNode("owner/description").InnerText;

                    application.CreationDate = app.SelectSingleNode("creationDate").InnerText;

                    client.ApplicationsList.Add(application);
                }

                return client;
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}
