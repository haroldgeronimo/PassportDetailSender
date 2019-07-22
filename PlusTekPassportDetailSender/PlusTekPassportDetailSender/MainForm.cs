using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace PlusTekPassportDetailSender
{
    public partial class MainForm : Form
    {
        PassportDetailProcessor pdp = new PassportDetailProcessor();
        public void StartUp()
        {
            //Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.Startup));
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\Passport Detail Sender.lnk"))
            {
                SaveData.CreateShortcut(
                    "Passport Detail Sender",
                    Environment.GetFolderPath(Environment.SpecialFolder.Startup),
                    Application.ExecutablePath
                    );
            }
            else
            {
                SaveData.CheckExistingShortcut(
                    "Passport Detail Sender",
                    Environment.GetFolderPath(Environment.SpecialFolder.Startup),
                    Application.ExecutablePath
                    );
            }
        }
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Minimized();
            }
        }

        void Minimized()
        {
                            Hide();
                notifyIcon1.Visible = true;
        }




        private void MainForm_Load(object sender, EventArgs e)
        {

            if (System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Length > 1) {
                MessageBox.Show("Another instance of this application is already running!");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }

            try
            {

                StartUp();
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occured: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            pdp.UIMessage += NewMessageEventHandler;
            pdp.UIStatus += NewStatusEventHandler;

            //if (String.IsNullOrEmpty(SaveData.Username))
            //    SaveData.Username = Interaction.InputBox("Enter your login username", "Username Required!");

            this.WindowState = FormWindowState.Minimized;
            Minimized();
            pdp.Start();
           

        }

        private void MainForm_OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Minimized();
                return;

            }


        }

   

        private void StatusLogText_TextChanged(object sender, EventArgs e)
        {

        }

        void NewMessageEventHandler(object sender, UIMessageEventArgs e)
        {
            if (StatusLogText.InvokeRequired)
            {
                this.Invoke((MethodInvoker) delegate {
                    this.NewMessageEventHandler(sender, e);
                    });
                return;
            }
            StatusLogText.AppendText(DateTime.Now.ToString("[dd/MM/yyyy HH:mm:ss] ") +  e.Message);
            StatusLogText.AppendText(Environment.NewLine);
        }
        void NewStatusEventHandler(object sender, UIStatusEventArgs e)
        {
            if (statusStrip1.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate {
                    this.NewStatusEventHandler(sender, e);
                });
                return;
            }
            toolStripStatusLabel1.Text = e.Status;
        }

        

        private void SendTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pdp.Test();
        }

        private void SendLastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pdp.SendLast();
        }

        private void PreferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                pdp.Stop();
                this.Close();
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }

        private void SaveLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveLogDialog.ShowDialog();
            string saveLoc = saveLogDialog.FileName;
            if (String.IsNullOrEmpty(saveLoc)) return;

            System.IO.File.WriteAllText(saveLoc, StatusLogText.Text);



        }

        private void ClearLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatusLogText.Text = String.Empty;
        }

        private void ForceRestartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pdp.Stop();
            pdp.Start();
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }
    }
}
