using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteAppServico
{
    public class Tools
    {
        public static string RetornAPP(string path)
        {
            string ret;
            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.Load(path + "Conf.xml");
            System.Xml.XmlNode globalNode = xmldoc.SelectSingleNode("GlobalDefinitions");
            System.Xml.XmlNode ArcPS1 = globalNode.SelectSingleNode("ArcPS1");
            ret = ArcPS1.InnerText;
            return ret;
        }

        public static int TimeInI(string path)
        {
            int ret;
            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.Load(path + "Conf.xml");
            System.Xml.XmlNode globalNode = xmldoc.SelectSingleNode("GlobalDefinitions");
            System.Xml.XmlNode TimeInI = globalNode.SelectSingleNode("TimeInI");
            ret = Convert.ToInt32(TimeInI.InnerText);
            return ret;
        }

        public static int TimeDelay(string path)
        {
            int ret;
            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.Load(path + "Conf.xml");
            System.Xml.XmlNode globalNode = xmldoc.SelectSingleNode("GlobalDefinitions");
            System.Xml.XmlNode TimeDelay = globalNode.SelectSingleNode("TimeDelay");
            ret = Convert.ToInt32(TimeDelay.InnerText);
            return ret;
        }

        public static void CreateFileWriteHistoric(string path, string text)
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(text);
                }
            }
            else
            {
                string FindHist = "";
                FindHist = ReadFileHistoric(path, text);
                if (FindHist == "N")
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(text);
                    }
                }
            }

        }

        public static string ReadFileHistoric(string path, string text)
        {
            string RetText = "N";
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string input = sr.ReadToEnd();

                    if (input.IndexOf(text) > -1)
                        RetText = "Y";
                    else
                        RetText = "N";

                    sr.Close();
                }
            }
            return RetText;
        }
    }
}
