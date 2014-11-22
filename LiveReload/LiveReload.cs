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
    public partial class LiveReload : Form
    {
        public LiveReload()
        {
            InitializeComponent();

            this.Settings = new LiveReloadSettings();
            settings_host.Text = this.Settings.UserHost;
            settings_document_root.Text = this.Settings.UserDocumentRoot;
            fileWatcher.Path = this.Settings.UserDocumentRoot;
        }

        public static string[] allowedFormats = { ".css", ".html", ".htm", ".js" };

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

        private void ExitApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShowMainForm(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void SaveSettings(object sender, EventArgs e)
        {
            Boolean has_error = false;
            if (settings_host.Text.Length < 1)
            {
                MessageBox.Show("Please, input your Host.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                has_error = true;
            } else if (settings_document_root.Text.Length < 1)
            {
                MessageBox.Show("Please, input your Document Root.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                has_error = true;
            } else if (!Directory.Exists(settings_document_root.Text)) {
                MessageBox.Show("Invalid Document Root.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                has_error = true;
            } else {

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

            if (!has_error)
            {
                this.Settings.UserHost = settings_host.Text;
                this.Settings.UserDocumentRoot = settings_document_root.Text;
                this.Settings.Save();

                fileWatcher.Path = settings_document_root.Text;

                MessageBox.Show("Your settings have been saved.", "Success.");
            }
            
        }

        internal LiveReloadSettings Settings { get; set; }

        private void FileWatcherChanged(object sender, FileSystemEventArgs e)
        {
            LiveReloadFile file = LiveReloadFileFactory.Get(e.FullPath);
            file.Process();
        }

    }
}