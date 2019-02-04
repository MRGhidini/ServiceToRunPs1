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
            timer1 = new System.Threading.Timer(new TimerCallback(ExecuteAPP), null, Tools.TimeInI(path), Tools.TimeDelay(path));
        }

        protected override void OnStop()
        {
            string hora = DateTime.Now.ToShortTimeString();
            string data = DateTime.Now.ToShortDateString();
            Tools.CreateFileWriteHistoric(path+"LogStop.txt","Servico parado em: Data: "+data+" Hora: "+hora);
        }

        private void ExecuteAPP(object sender)
        {

            using (Process processo = new Process())
            {
                System.Diagnostics.Process.Start("powershell.exe", " -executionpolicy unrestricted -file " + "\"" + Tools.RetornAPP(path) + "\"");
            }

        }

    }
}
