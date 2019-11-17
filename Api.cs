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
        private const string _site = "https://www.gitignore.io/api/";

        public List<string> GetListIgnores()
        {
            try
            {
                List<string> listIgnores;

                WebRequest request = WebRequest.Create(_site + "list");

                using (WebResponse response = request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            listIgnores = reader.ReadToEnd().Split(',').ToList();
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
                    Console.WriteLine("Error code: {0} - {1}",
                        (int) httpResponse.StatusCode, httpResponse.StatusCode);
                }

                return new List<string> {""};
            }
        }

        public string GetIgnore(string types)
        {
            try
            {
                string ignore;

                WebRequest request = WebRequest.Create(_site + types);

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
                    Console.WriteLine("Error code: {0} - {1}",
                        (int) httpResponse.StatusCode, httpResponse.StatusCode);
                }

                return "";
            }
        }
    }
}