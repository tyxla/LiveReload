using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveReload
{
    // Main application class
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Initialize our visual styles
            Application.EnableVisualStyles();
            
            // Setup text rendering compatibility
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize and run the main LiveReload instance
            Application.Run(new LiveReload());
        }
    }
}
