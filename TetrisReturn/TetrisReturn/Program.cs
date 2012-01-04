using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace TetrisReturn
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool ownsMutex;
            using (Mutex mutex = new Mutex(true, "Mutex", out ownsMutex))
            {
                if (ownsMutex)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());
                    mutex.ReleaseMutex();
                }
                else
                {
                    string procName = Process.GetCurrentProcess().ProcessName;
                    MessageBox.Show("Another " + procName + " game is running. Bye!", procName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }
            }
        }
    }
}