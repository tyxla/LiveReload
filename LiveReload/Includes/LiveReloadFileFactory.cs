using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LiveReload
{
    class LiveReloadFileFactory
    {
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
