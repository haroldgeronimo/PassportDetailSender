using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Net;
using System.Net.Sockets;

namespace PlusTekPassportDetailSender
{
    class Passport
    {

        public DateTime dateScanned;
        public string firstName;
        public string lastName;
        public DateTime dateOfBirth;
        public string gender;
        public string documentNumber;
        public string nationality;
        public DateTime validUntil;
        //public string address;
        public string mrz1;
        public string mrz2;

        public string imageContent;
        public string imageFilename;
        // public string mrz3;
        // public string remarks;

        public Passport(DataRow r)
        {
            dateScanned = Convert.ToDateTime(r["Date"] + " " + r["Time"]);
            firstName = r["First Name"].ToString();
            lastName = r["Last Name"].ToString();
            string dob = r["Date of Birth"].ToString().Substring(0, 4) + "-" + r["Date of Birth"].ToString().Substring(4, 2) + "-" + r["Date of Birth"].ToString().Substring(6, 2);
            dateOfBirth = DateTime.ParseExact(dob, "yyyy-MM-dd", null);
            gender = r["Gender"].ToString();
            documentNumber = r["Document Number"].ToString();
            nationality = r["Nationality"].ToString();
            string vu = r["Valid Until"].ToString().Substring(0, 4) + "-" + r["Valid Until"].ToString().Substring(4, 2) + "-" + r["Valid Until"].ToString().Substring(6, 2);
            validUntil = DateTime.ParseExact(vu, "yyyy-MM-dd", null);
            mrz1 = r["MRZ1"].ToString();
            mrz2 = r["MRZ2"].ToString();

            imageContent = GetBase64StringForImage(r["General"].ToString());
            imageFilename = Path.GetFileName(r["General"].ToString());
            // mrz3 = r["MRZ3"].ToString();
            // remarks = r["Remarks"].ToString();

        }

        public Passport(string documentNumber)
        {
            this.documentNumber = documentNumber;
        }

        public string ToJSON()
        {
            string jsonStr = new JavaScriptSerializer().Serialize(new PassportString(this));
            Console.WriteLine(jsonStr);
            return jsonStr;
        }

        public class PassportString
        {
            public string DateScanned;
            public string FirstName;
            public string LastName;
            public string DateOfBirth;
            public string Gender;
            public string DocumentNumber;
            public string Nationality;
            public string ValidUntil;
            public string MRZ1;
            public string MRZ2;
            public string ImageContent;
            public string ImageFilename;
            public string LocalIP;
            public PassportString(Passport p)
            {
                this.DateScanned = p.dateScanned.ToString("yyyy-MM-dd");
                this.FirstName = p.firstName;
                this.LastName = p.lastName;
                this.DateOfBirth = p.dateOfBirth.ToString("yyyy-MM-dd"); ;
                this.Gender = p.gender;
                this.DocumentNumber = p.documentNumber;
                this.Nationality = p.nationality;
                this.ValidUntil = p.validUntil.ToString("yyyy-MM-dd");
                this.MRZ1 = p.mrz1;
                this.MRZ2 = p.mrz2;
                this.ImageContent = p.imageContent;
                this.ImageFilename = p.imageFilename;
                try
                {


                    this.LocalIP = GetLocalIPAddress();
                }
                catch (Exception e)
                {
                }
        }
        }

        string GetBase64StringForImage(string imgPath)
        {
            byte[] imageBytes = System.IO.File.ReadAllBytes(imgPath);
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }



    }
}
