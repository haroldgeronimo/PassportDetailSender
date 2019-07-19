using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PlusTekPassportDetailSender
{
    static class WebHandler
    {
        private static string URL =SaveData.RequestURL;
        private static readonly HttpClient client = new HttpClient();

        public static void SendDataByJSON(string json)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
            }
            string response = "";
            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = result;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + " " + response);
                
            }
        }
    }
}
