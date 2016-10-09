using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.Diagnostics;

namespace TestThread
{
   
    public partial class Form1 : Form
    {
        private int limit = 2,maxThread=5;
        static SemaphoreSlim _sem;
        public Form1()
        {
            InitializeComponent();
            _sem = new SemaphoreSlim(this.limit); // only this.limit thread
            object lockThis = new Object();

            for ( int i = 0;i<maxThread;i++)
            {
                
                Thread th = new Thread(() =>
               {
                   _sem.Wait(); //wait for thread
                   var process = new Process
                   {
                       StartInfo = new ProcessStartInfo
                       {
                           FileName = "notepad"
                       }
                   };
                   process.Start();
                   process.WaitForExit();
                   Console.WriteLine("exit");
                   _sem.Release();

               });
                th.Start();
            }



        }
    }
}
