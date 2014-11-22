using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LiveReload
{
    abstract class LiveReloadFile
    {
        public LiveReloadFile(string filePath)
        {
            this.FilePath = filePath;
        }

        abstract public void Process();

        private string filePath;

        protected string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

    }
}
