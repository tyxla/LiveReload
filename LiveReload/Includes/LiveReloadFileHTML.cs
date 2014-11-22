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
        public LiveReloadFileHTML(string filePath) : base(filePath)
        {

        }

        public override void Process()
        {
            MessageBox.Show("HTML FILE SAVED!");
        }
    }
}
