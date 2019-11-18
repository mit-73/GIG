using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GIG
{
    public class Api
    {
        private const string Site = "https://www.gitignore.io/api/";

        public static List<string> GetIgnores()
        {
            try
            {
                List<string> listIgnores;
                char[] separators = {',', '\n'};

                WebRequest request = WebRequest.Create(Site + "list");

                using (WebResponse response = request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            listIgnores = reader.ReadToEnd().Split(separators).ToList();
                        }
                    }
                }

                return listIgnores;
            }
            catch (WebException ex)
            {
                WebExceptionStatus status = ex.Status;

                if (status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse) ex.Response;
                    Console.WriteLine($"Error code: {(int) httpResponse.StatusCode} - {httpResponse.StatusCode}");
                }

                return new List<string> {""};
            }
        }

        public static string GetIgnore(string types)
        {
            try
            {
                string ignore;

                WebRequest request = WebRequest.Create(Site + types);

                using (WebResponse response = request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            ignore = reader.ReadToEnd();
                        }
                    }
                }

                return ignore;
            }
            catch (WebException ex)
            {
                WebExceptionStatus status = ex.Status;

                if (status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse) ex.Response;
                    Console.WriteLine($"Error code: {(int) httpResponse.StatusCode} - {httpResponse.StatusCode}");
                }

                return "";
            }
        }
    }
}