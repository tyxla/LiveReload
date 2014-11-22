using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LiveReload
{
    // Factory for creating the proper LiveReloadFile instance.
    class LiveReloadFileFactory
    {
        // Our main factory method. 
        // Returns the correct instance of LiveReloadFile.
        public static LiveReloadFile Get(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            if (Array.IndexOf(LiveReload.allowedFormats, extension) >= 0)
            {
                switch (extension)
                {
                    case ".css":
                        return new LiveReloadFileCSS(filePath);
                    case ".js":
                        return new LiveReloadFileJS(filePath);
                    case ".htm":
                    case ".html":
                        return new LiveReloadFileHTML(filePath);
                }
            }

            return new LiveReloadFileDefault(filePath);
        }
    }
}
