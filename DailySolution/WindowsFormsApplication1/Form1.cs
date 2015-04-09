using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void handleTag_Click(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(new ThreadStart(Test));
            thread1.IsBackground = true;
            thread1.Start();

            Thread thread2 = new Thread(new ThreadStart(Test));
            thread2.IsBackground = true;
            thread2.Start();
        }
        private void StartSomeWorkFromUIThread()
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new EventHandler(RunsOnWorkerThread), null);
            }
            else
            {
                RunsOnWorkerThread(this, null);
            }
        }

        private void RunsOnWorkerThread(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            MessageBox.Show(DateTime.Now.ToString());
        }
        private void Test()
        {
            Thread.Sleep(2000);
            MessageBox.Show(DateTime.Now.ToString());
        }
    }
}
