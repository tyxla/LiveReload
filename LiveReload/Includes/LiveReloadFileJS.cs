using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveReload
{
    class LiveReloadFileJS: LiveReloadFile
    {
        // Constructor. Inheriting the parent constructor.
        public LiveReloadFileJS(string filePath) : base(filePath)
        {

        }

        // Process the file after being saved. 
        public override void ProcessReload()
        {
            // TODO: implement livereload
            MessageBox.Show("JS FILE SAVED!");
        }
    }
}
