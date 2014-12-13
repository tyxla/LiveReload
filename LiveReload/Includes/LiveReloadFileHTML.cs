using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveReload
{
    class LiveReloadFileHTML: LiveReloadFile
    {
        // Constructor. Inheriting the parent constructor.
        public LiveReloadFileHTML(string filePath) : base(filePath)
        {

        }

        // Process the file after being saved. 
        public override void ProcessReload()
        {
            // TODO: implement livereload
            MessageBox.Show("HTML FILE SAVED!");
        }
    }
}
