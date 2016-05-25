using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactCenterGUI.CC;
using System.Threading;
using System.Globalization;

namespace ContactCenterGUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Sets the culture to French (France)
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-PE");
            // Sets the UI culture to French (Peru)
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-PE");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Loader());
        }
    }
}
