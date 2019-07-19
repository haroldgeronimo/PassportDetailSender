using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using IWshRuntimeLibrary;

namespace PlusTekPassportDetailSender
{
    static class SaveData
    {
        public static string dbLocation {
            get { return Properties.Settings.Default["dbLocation"].ToString(); }
            set { Properties.Settings.Default["dbLocation"] = value;
                Properties.Settings.Default.Save();
            }
        }
        public static string RequestURL
        {
            get { return Properties.Settings.Default["API_URL"].ToString(); }
            set { Properties.Settings.Default["API_URL"] = value;
                Properties.Settings.Default.Save();
            }
        }
        public static string Username
        {
            get { return Properties.Settings.Default["username"].ToString(); }
            set
            {
                Properties.Settings.Default["username"] = value;
                Properties.Settings.Default.Save();
            }
        }

        public static void CreateShortcut(string shortcutName, string shortcutPath, string targetFileLocation)
        {
            string shortcutLocation = System.IO.Path.Combine(shortcutPath, shortcutName + ".lnk");
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.Description = "Passport Detail Sender";   // The description of the shortcut
                      // The icon of the shortcut
            shortcut.TargetPath = targetFileLocation;                 // The path of the file that will launch when the shortcut is run
            shortcut.Save();                                    // Save the shortcut
        }

       
    }
}
