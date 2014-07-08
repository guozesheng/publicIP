using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;

namespace publicIP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            NetworkChange.NetworkAvailabilityChanged += new 
                System.Net.NetworkInformation.NetworkAvailabilityChangedEventHandler(NetworkAvailabilityCallback);
        }

        private void NetworkAvailabilityCallback(object sender, NetworkAvailabilityEventArgs e)
        {

            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface n in adapters)
            {
                if (n.Name == "无线网络连接" && n.OperationalStatus == OperationalStatus.Up)
                {
                    //textBox1.Text += n.Name + " is " + n.OperationalStatus.ToString();
                    mytest();
                }
            }
        }

        private void mytest()
        {
            WebClient client = new WebClient();
            int times = 5;
            int timeout = 4000;

            while (times-- > 0)
            {
                string str = client.DownloadString("http://1.guozesheng.sinaapp.com/publicIP/set.php");

                if (str == "hello, world")
                {
                    break;
                }
                else
                {
                    System.Threading.Thread.Sleep(timeout);
                    timeout *= 2;
                }
            }
        }
    }
}
