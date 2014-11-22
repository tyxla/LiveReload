using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveReload
{
    class LiveReloadFileDefault: LiveReloadFile
    {
        // Constructor. Inheriting the parent constructor.
        public LiveReloadFileDefault(string filePath) : base(filePath)
        {

        }

        // Process the file after being saved. 
        public override void Process()
        {
            // Nothing should happen here. 
            // This file appears be of no concern to us.
        }
    }
}
