using System;
using System.Windows.Forms;

namespace BibliotecaCS
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Agora o app começa pelo login
            Application.Run(new frmLogin());
        }
    }
}
