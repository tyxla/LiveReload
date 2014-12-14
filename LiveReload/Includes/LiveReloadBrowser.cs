using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LiveReload
{
    class LiveReloadBrowser
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        public static void Refresh() {

            // Define all browsers that we will refresh
            string[] browsers = {"chrome", "firefox", "opera", "iexplore", "safari"};

            // Refresh all browsers
            foreach (string browser in browsers)
            {
                Process[] browserProcesses = Process.GetProcessesByName(browser);
                foreach (Process browserProcess in browserProcesses)
                {
                    if (browserProcess.MainWindowHandle != IntPtr.Zero)
                    {
                        // Save the currently focused window
                        IntPtr currentWindowHandle = GetForegroundWindow();

                        // Set focus on the window so that the key input can be received.
                        LiveReloadSendInput.SetForegroundWindow(browserProcess.MainWindowHandle);

                        // Create a F5 key press
                        LiveReloadSendInput.INPUT ip = new LiveReloadSendInput.INPUT { Type = 1 };
                        ip.Data.Keyboard = new LiveReloadSendInput.KEYBDINPUT();
                        ip.Data.Keyboard.Vk = (ushort)0x74;  // F5 Key
                        ip.Data.Keyboard.Scan = 0;
                        ip.Data.Keyboard.Flags = 0;
                        ip.Data.Keyboard.Time = 0;
                        ip.Data.Keyboard.ExtraInfo = IntPtr.Zero;

                        var inputs = new LiveReloadSendInput.INPUT[] { ip };

                        // Send the keypress to the window
                        LiveReloadSendInput.SendInput(1, inputs, Marshal.SizeOf(typeof(LiveReloadSendInput.INPUT)));

                        // Set focus back 
                        LiveReloadSendInput.SetForegroundWindow(currentWindowHandle);
                    }
                }
            }

        }
    }
}
