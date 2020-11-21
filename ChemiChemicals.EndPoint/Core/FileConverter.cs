using System;
using System.Net;
using System.Text;

namespace ChemiChemicals.EndPoint.Core
{
    public static class FileConverter
    {
        //use this link to create the converter https://stackoverflow.com/questions/44560303/c-sharp-download-pdf-from-url-and-convert-it-into-base64-without-saving-it-on
        public static string ConvertLinkToBinaryData(string urlPath)
        {
            byte[] raw;
            using (var client = new WebClient())
            { 
                raw = client.DownloadData(urlPath);
            }
            string str = Convert.ToBase64String(raw);
            return EncodeBase64(str);
        }

        public static string EncodeBase64(string base64String)
        {
            //replace the special charcter with - and _ to not be removed in the query string
            base64String = base64String.Replace('+', '-');
            base64String = base64String.Replace('/', '_');
            return base64String;
        }

        public static string DecodeBase64(string base64String)
        {
            base64String = base64String.Replace('-', '+');
            base64String = base64String.Replace('_', '/');
            return base64String;
        }

        //get the extension type using this link https://stackoverflow.com/questions/24034951/checking-file-type-from-base64
        public static string GetExtensionTypeFromBase64(string basee64String)
        {
            var data = basee64String.Substring(0, 5);
            switch (data.ToUpper())
            {
                case "IVBOR":
                    return "png";
                case "/9J/4":
                    return "jpg";
                case "AAAAF":
                    return "mp4";
                case "JVBER":
                    return "pdf";
                case "AAABA":
                    return "ico";
                case "UMFYI":
                    return "rar";
                case "E1XYD":
                    return "rtf";
                case "U1PKC":
                    return "txt";
                case "MQOWM":
                case "77U/M":
                    return "srt";
                default:
                    return string.Empty;
            }
        }
    }
}
