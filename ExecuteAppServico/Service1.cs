using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.IO;

namespace ExecuteAppServico
{
    public partial class Service1 : ServiceBase
    {
        System.Threading.Timer timer1;
        public static string path = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer1 = new System.Threading.Timer(new TimerCallback(ExecuteAPP), null, 3000, 3000);
        }

        protected override void OnStop()
        {
        }

        private void ExecuteAPP(object sender)
        {

            using (Process processo = new Process())
            {
                processo.StartInfo.CreateNoWindow = true;
                System.Diagnostics.Process.Start("powershell.exe", " -executionpolicy unrestricted -file " + "\"" + RetornAPP() + "\"");
            }

        }

        public static string RetornAPP()
        {
            string ret;
            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.Load(path + "Conf.xml");
            System.Xml.XmlNode AppNode = xmldoc.SelectSingleNode("AppNode");
            ret = AppNode.InnerText;
            return ret;
        }

    }
}
