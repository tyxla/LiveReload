using System;
using System.Collections.Generic;
using System.Linq;
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
        public override void Process()
        {
            // TODO: implement livereload
            MessageBox.Show("HTML FILE SAVED!");
        }
    }
}
