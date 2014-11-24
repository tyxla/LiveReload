using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LiveReload
{
    // Abstract class for a file that is being saved.
    abstract class LiveReloadFile
    {
        // Constructor. Specifies the path of the updated file.
        public LiveReloadFile(string filePath)
        {
            this.FilePath = filePath;
        }

        // Process the file after being saved.
        // Must be implemented in the child classes.
        abstract public void Process();

        // Contains the file path.
        private string filePath;

        // Setter & getter for file path.
        protected string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

    }
}
