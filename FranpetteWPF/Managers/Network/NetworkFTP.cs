using System;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Franpette.Sources.Network;
using Franpette.Sources.Franpette;
using System.ComponentModel;
using System.Collections.Generic;
using System.Resources;
using System.Globalization;

namespace Franpette.Sources
{
    class NetworkFTP : IFranpetteNetwork
    {
        private Stopwatch       _sw;
        private Label           _progress;
        private Font            _font;
        private PointF          _textPos;
        
        private String          _password;
        private String          _login;
        private String          _address;

        private ResourceManager _resMan;
        private CultureInfo     _cul;

        public NetworkFTP(Label progress_label)
        {
            _sw = new Stopwatch();
            _progress = progress_label;
            _font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular);
            _textPos = new PointF(0, 0);

            _resMan = new ResourceManager("Franpette.Resources.Lang", typeof(Program).Assembly);
            _cul = CultureInfo.CreateSpecificCulture(Utils.getProperty("lang", "en-US"));
        }

        public Boolean connect(string address)
        {
            _address = address;
            return true;
        }

        public Boolean login(string login, string password)
        {
            _login = login;
            _password = password;
            return true;
        }

        // Actions depuis le serveur
        public virtual Boolean downloadFile(ETarget target, BackgroundWorker worker)
        {
            switch (target)
            {
                case ETarget.FRANPETTE:
                    ftpDownload("Franpette/FranpetteStatus.xml", Utils.getRoot("FranpetteStatus.xml"), worker);
                    printInfo(_resMan.GetString("franpette_ready", _cul));
                    break;
                case ETarget.MINECRAFT:
                    printInfo(_resMan.GetString("franpette_checkCsv", _cul));
                    File.WriteAllLines(Utils.getRoot("Minecraft.csv"), Utils.checkCsv(true, Utils.getProperty("directory", Utils.getRoot()) + "Minecraft"));
                    ftpDownload("Franpette/Minecraft.csv", Utils.getRoot("Minecraft_server.csv"), worker);
                    filesToDownload(Utils.getRoot("Minecraft_server.csv"), Utils.getRoot("Minecraft.csv"), worker);
                    printInfo(_resMan.GetString("franpette_checkCsv", _cul));
                    File.WriteAllLines(Utils.getRoot("Minecraft.csv"), Utils.checkCsv(true, Utils.getProperty("directory", Utils.getRoot()) + "Minecraft"));
                    ftpUpload(Utils.getRoot("Minecraft.csv"), "Franpette/Minecraft.csv", worker);
                    break;
                default:
                    Utils.debug("[NetworkFTP] downloadFile : Target is missing.");
                    break;
            }
            return true;
        }

        // Actions vers le serveur
        public virtual Boolean uploadFile(ETarget target, BackgroundWorker worker)
        {
            switch (target)
            {
                case ETarget.FRANPETTE:
                    ftpUpload(Utils.getRoot("FranpetteStatus.xml"), "Franpette/FranpetteStatus.xml", worker);
                    break;
                case ETarget.MINECRAFT:
                    printInfo(_resMan.GetString("franpette_checkCsv", _cul));
                    File.WriteAllLines(Utils.getRoot("Minecraft.csv"), Utils.checkCsv(true, Utils.getProperty("directory", Utils.getRoot()) + "Minecraft"));
                    ftpDownload("Franpette/Minecraft.csv", Utils.getRoot("Minecraft_server.csv"), worker);
                    filesToUpload(Utils.getRoot("Minecraft.csv"), Utils.getRoot("Minecraft_server.csv"), worker);
                    ftpUpload(Utils.getRoot("Minecraft.csv"), "Franpette/Minecraft.csv", worker);
                    break;
                default:
                    Utils.debug("[NetworkFTP] uploadFile : Target is missing.");
                    break;
            }
            return true;
        }

        // Connexion à un Path sur le server FTP avec les identifiants
        private FtpWebRequest requestMethod(string path, string method)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + _address + "/" + path);
            request.Credentials = new NetworkCredential(_login, _password);
            request.Method = method;
            return request;
        }

        // Récupération de la taille du fichier téléchargé pour la progressBar
        private int requestSize(string path, FtpWebRequest request)
        {
            WebRequest sizeRequest = WebRequest.Create("ftp://" + _address + "/" + path);
            sizeRequest.Credentials = request.Credentials;
            sizeRequest.Method = WebRequestMethods.Ftp.GetFileSize;
            return (int)sizeRequest.GetResponse().ContentLength;
        }

        // Upload
        private void ftpUpload(string src, string dest, BackgroundWorker worker)
        {
            FtpWebRequest request = requestMethod(dest, WebRequestMethods.Ftp.UploadFile);

            _sw.Reset();
            try
            {
                using (Stream fileStream = File.OpenRead(src))
                using (Stream ftpStream = request.GetRequestStream())
                {
                    byte[] buffer = new byte[10240];
                    int read;
                    _sw.Start();
                    Utils.debug("[NetworkFTP] ftpUpload : ...uploading " + src);
                    while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ftpStream.Write(buffer, 0, read);
                        printProgressInfo(src, fileStream.Position, (int)fileStream.Length);
                    }
                    _sw.Stop();
                    Utils.debug("[NetworkFTP] ftpUpload : " + src + " uploaded !");
                }
            }
            catch (WebException e)
            {
                Utils.debug("[NetworkFTP] ftpDownload : " + e.Message);
            }
        }

        // Download
        private void ftpDownload(string src, string dest, BackgroundWorker worker)
        {
            FtpWebRequest request = requestMethod(src, WebRequestMethods.Ftp.DownloadFile);

            int total = requestSize(src, request);
            _sw.Reset();
            try
            {
                using (Stream ftpStream = request.GetResponse().GetResponseStream())
                using (Stream fileStream = File.Create(dest))
                {
                    byte[] buffer = new byte[102400];
                    int read;
                    _sw.Start();
                    Utils.debug("[NetworkFTP] ftpDownload : ...downloading " + dest);
                    while ((read = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, read);
                        printProgressInfo(dest, fileStream.Position, total);
                    }
                    _sw.Stop();
                    Utils.debug("[NetworkFTP] ftpDownload : " + dest + " downloaded !");
                }
            }
            catch (WebException e)
            {
                Utils.debug("[NetworkFTP] ftpDownload : " + e.Message);
            }
        }

        // Afficher les infos d'upload ou de download sur la progressBar
        public void printProgressInfo(string filename, long pos, int max)
        {
            string perSeconds = "";
            if (max > 100000)
            {
                float speed = pos / (float)_sw.Elapsed.TotalSeconds;
                perSeconds = " - " + (speed / 1000).ToString("F") + " Kb/s";
                if (speed > 1000000) perSeconds = " - " + (speed / 1000000).ToString("F") + " Mb/s";
            }

            float percent = ((float)pos / max) * 100f;
            string percentage = ((int)percent).ToString() + "%";

            printInfo(Path.GetFileName(filename) + perSeconds + " - " + percentage);
        }

        // Afficher au dessus de la barre de progression un message
        public void printInfo(string info)
        {
            _progress.CreateGraphics().Clear(Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(130))))));
            _progress.CreateGraphics().DrawString(info, _font, Brushes.White, _textPos);
        }

        // Téléchargement des fichiers
        public void filesToDownload(string server, string local, BackgroundWorker worker)
        {
            string[] localFiles = File.ReadAllLines(local);
            string[] serverFiles = File.ReadAllLines(server);

            int total = 0;
            foreach (string line in serverFiles)
            {
                if (line.Split(';').Length == 3)
                    total += Convert.ToInt32(line.Split(';')[2]);
            }

            int done = 0;
            Boolean found;
            int i = 0;
            int start = 0;

            Utils.debug("[NetworkFTP] filesToDownload : debut de l'analyse des fichiers...");

            foreach (string serv in serverFiles)
            {
                string file = serv.Split(';')[0];

                // If minecraft_server.jar is found -> create appropriate start.bat
                if ((file.Contains("minecraft") || file.Contains("server")) && file.Contains(".jar"))
                {
                    string[] scriptLines = new string[3];
                    scriptLines[0] = "cd " + Utils.getProperty("directory", Utils.getRoot()) + Path.GetDirectoryName(file);
                    scriptLines[1] = "cls";
                    scriptLines[2] = "java -Xms1024M -Xmx2048M -jar " + Path.GetFileName(file) + " nogui";
                    File.WriteAllLines(Utils.getRoot("start.bat"), scriptLines);
                }

                found = false;
                i = start;
                while (i < localFiles.Length)
                {
                    if (serv == localFiles[i])
                    {
                        start++;
                        found = true;
                        break;
                    }
                    else if (serv.Split(';')[0] == localFiles[i].Split(';')[0])
                    {
                        start++;
                        found = true;
                        Directory.CreateDirectory(Utils.getProperty("directory", Utils.getRoot()) + file.Substring(0, file.LastIndexOf('\\')));
                        if (serv.Split(';')[1] != localFiles[i].Split(';')[1])
                        {
                            ftpDownload("Franpette/" + file.Replace('\\', '/'), Utils.getProperty("directory", Utils.getRoot()) + file, worker);
                        }
                        break;
                    }
                    i++;
                }
                if (!found)
                {
                    Directory.CreateDirectory(Utils.getProperty("directory", Utils.getRoot()) + file.Substring(0, file.LastIndexOf('\\')));
                    ftpDownload("Franpette/" + file.Replace('\\', '/'), Utils.getProperty("directory", Utils.getRoot()) + file, worker);
                }
                worker.ReportProgress((int)(done * 100.0 / (float)total));
                if (serv.Split(';').Length == 3)
                    done += Convert.ToInt32(serv.Split(';')[2]);
            }
        }

        // Upload des fichiers
        public void filesToUpload(string local, string server, BackgroundWorker worker)
        {
            string[] localFiles = File.ReadAllLines(server);
            string[] serverFiles = File.ReadAllLines(local);

            int total = 0;
            foreach (string line in serverFiles)
            {
                if (line.Split(';').Length == 3)
                    total += Convert.ToInt32(line.Split(';')[2]);
            }

            int done = 0;
            Boolean found;
            int i = 0;
            int start = 0;

            foreach (string serv in serverFiles)
            {
                string file = serv.Split(';')[0];

                found = false;
                i = start;
                while (i < localFiles.Length)
                {
                    if (serv == localFiles[i])
                    {
                        start++;
                        found = true;
                        break;
                    }
                    else if (serv.Split(';')[0] == localFiles[i].Split(';')[0])
                    {
                        start++;
                        found = true;
                        if (serv.Split(';')[1] != localFiles[i].Split(';')[1])
                        {
                            ftpUpload(Utils.getProperty("directory", Utils.getRoot()) + file, "Franpette/" + file.Replace('\\', '/'), worker);
                        }
                        break;
                    }
                    i++;
                }
                if (!found) ftpUpload(Utils.getProperty("directory", Utils.getRoot()) + file, "Franpette/" + file.Replace('\\', '/'), worker);
                worker.ReportProgress((int)(done * 100.0 / (float)total));
                if (serv.Split(';').Length == 3)
                    done += Convert.ToInt32(serv.Split(';')[2]);
            }
        }
    }
}
