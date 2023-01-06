using Museum.Client.Demos;
using System;
using System.Windows.Forms;


namespace Museum.Client
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Builder.Demo();
        }
    }
}
