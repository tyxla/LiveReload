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
        public LiveReloadFileJS(string filePath) : base(filePath)
        {

        }
        public override void Process()
        {
            MessageBox.Show("JS FILE SAVED!");
        }
    }
}
