using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.ComponentModel;

namespace FranpetteLib.JsonManager
{
    public class Json : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static String GetStream(String directory)
        {
            JArray files = new JArray();
            foreach (string file in Directory.GetFiles(directory, "*", SearchOption.AllDirectories))
            {
                JProperty path = new JProperty("path", file);
                JProperty size = new JProperty("size", new FileInfo(file).Length);
                JProperty hash = new JProperty("hash", GetSha256(file));

                JObject filename = new JObject(path, size, hash);

                files.Add(filename);
            }

            return files.ToString();
        }

        public static List<Tuple<String, String, int>> MissingFiles(string local, string server)
        {
            Boolean found;
            int i = 0;
            int start = 0;

            List<Tuple<String, String, int>> list = new List<Tuple<String, String, int>>();

            foreach (JObject serv in JArray.Parse(server))
            {
                String localPath = null;
                String localHash = null;

                string servPath = (String)serv.Property("path").Value;
                int servSize = (int)serv.Property("size").Value;
                string servHash = (String)serv.Property("hash").Value;

                found = false;
                i = start;

                while (i < JArray.Parse(local).Count)
                {
                    localPath = (String)JArray.Parse(local)[i].Value<JObject>().Property("path").Value;
                    localHash = (String)JArray.Parse(local)[i].Value<JObject>().Property("hash").Value;

                    if (servPath == localPath && servHash == localHash)
                    {
                        start++;
                        found = true;
                        break;
                    }
                    else if (servPath == localPath)
                    {
                        start++;
                        found = true;
                        if (servHash != localHash)
                            list.Add(new Tuple<String, String, int>(localPath, servPath, servSize));
                        break;
                    }
                    i++;
                }

                if (!found)
                    list.Add(new Tuple<String, String, int>(localPath, servPath, servSize));
            }

            return list.OrderBy(t => t.Item3).ToList();
        }

        public static String GetSha256(String filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                var sha = new SHA256Managed();
                byte[] hash = sha.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", String.Empty).ToLowerInvariant();
            }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
