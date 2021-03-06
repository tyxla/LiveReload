﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.IO;

namespace LiveReload
{
    // Main application form class.
    public partial class LiveReload : Form
    {
        // Constructor.
        public LiveReload()
        {
            // Initialize visual form controls.
            InitializeComponent();

            // Initialize settings.
            this.Settings = new LiveReloadSettings();

            // Setup settings field values.
            settings_host.Text = this.Settings.UserHost;
            settings_document_root.Text = this.Settings.UserDocumentRoot;

            // Setup the filewatcher path.
            fileWatcher.Path = this.Settings.UserDocumentRoot;
        }

        // The file formats that we'll be listening for.
        public static string[] allowedFormats = { ".css", ".html", ".htm", ".js" };

        // Called on minimize/maximize to toggle the tray icon.
        private void LiveReloadResize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon.Visible = true;
                this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon.Visible = false;
            }
        }

        // The exit method.
        private void ExitApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Display the settings form.
        private void ShowMainForm(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        // Save the form settings.
        private void SaveSettings(object sender, EventArgs e)
        {
            // Contains a flag - whether we have an error or not.
            Boolean has_error = false;

            // Validate Host field - should not be empty.
            if (settings_host.Text.Length < 1)
            {
                MessageBox.Show("Please, input your Host.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                has_error = true;
            } 

            // Validate Document Root field - should not be empty.
            else if (settings_document_root.Text.Length < 1)
            {
                MessageBox.Show("Please, input your Document Root.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                has_error = true;

            // Validate Document Root field - should be a valid directory.
            } else if (!Directory.Exists(settings_document_root.Text)) {
                MessageBox.Show("Invalid Document Root.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                has_error = true;
            } else {

                // Validate Host - should be a valid, reachable host.
                try
                {
                    Ping ping_sender = new Ping();
                    PingReply reply = ping_sender.Send(settings_host.Text);

                    if (reply.Status != IPStatus.Success)
                    {
                        MessageBox.Show("Invalid host.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        has_error = true;
                    }
                }
                catch
                {
                    MessageBox.Show("Invalid host.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    has_error = true;
                }

            }

            // If everything is fine, proceed with saving.
            if (!has_error)
            {
                // Fetch and save settings.
                this.Settings.UserHost = settings_host.Text;
                this.Settings.UserDocumentRoot = settings_document_root.Text;
                this.Settings.Save();

                // Modify the filewatcher path.
                fileWatcher.Path = settings_document_root.Text;

                // Display a success message.
                MessageBox.Show("Your settings have been saved.", "Success.");
            }
            
        }
        
        // An internal pointer to the settings object.
        internal LiveReloadSettings Settings { get; set; }

        // Called upon changing one of the watched files.
        // Used as a link between our main application form and the LiveReloadFile instances.
        private void FileWatcherChanged(object sender, FileSystemEventArgs e)
        {
            LiveReloadFile file = LiveReloadFileFactory.Get(e.FullPath);
            file.ProcessReload();
        }

    }
}
