using System;
using System.IO;
using System.Net;
using Microsoft.Win32;

namespace Dont_Touch_This_EXE
{
    class Program
    {
        public static void Main(string[] args)
        {
            WebClient wc = new WebClient();
            string base_url = "ftp://updater:thisispassword@31.25.29.138/usb1_1/minecraft/DontTouchThisFolder/";
            string appdata_path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appdata_launcher_path = appdata_path + @"\scproch_updater\";
            string temp_path = appdata_launcher_path + @"Temp\";
            string launcher_install_path = @"C:\Program Files\SKProCH Updater\";
            string sub_name = "L_Version.txt";
            File.Copy(temp_path + sub_name, appdata_launcher_path + sub_name, true);
            File.Delete(launcher_install_path + "ModPack Updater.exe");
            Directory.Delete(temp_path, true);
            Directory.CreateDirectory(temp_path);
            File.WriteAllText(appdata_launcher_path + "M_Version.txt", "При следующем включении апдейтер обновит клиент");            
            string url = base_url + "Updater.exe";
            string name = "Modpack Updater.exe";
            wc.DownloadFile(url, launcher_install_path + name);
            System.Diagnostics.Process.Start(launcher_install_path + "Modpack Updater.exe");
            return;
        }
    }
}