using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlusTekPassportDetailSender
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            fileLocationTxt.Text = SaveData.dbLocation;
            URLTxt.Text = SaveData.RequestURL;
            UsernameTxt.Text = SaveData.Username;
        }

        public void SaveChanges()
        {
            SaveData.dbLocation = fileLocationTxt.Text;
            SaveData.RequestURL = URLTxt.Text;
            SaveData.Username = UsernameTxt.Text;

        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SaveChanges();
            this.Close();
        }

        private void LocateBtn_Click(object sender, EventArgs e)
        {
            locateDbFileDialogue.InitialDirectory = @"C:\Users\Public\Documents\Plustek-SecureScan\";
            locateDbFileDialogue.ShowDialog();
            if(!String.IsNullOrEmpty(locateDbFileDialogue.FileName))
                fileLocationTxt.Text = locateDbFileDialogue.FileName;
        }

        private void TestBtn_Click(object sender, EventArgs e)
        {
            TestAPIUrl();
        }

        void TestAPIUrl()
        {
            string html = String.Empty;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URLTxt.Text + "/Test");
                request.AutomaticDecompression = DecompressionMethods.GZip;
                request.Method = "GET";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {


                MessageBox.Show("Request Error: " + e.Message, "Result");
                return;
            }
         

            MessageBox.Show(html,"Result");
        }
        
    }
}
