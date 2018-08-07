using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace beerApp.RestClient
{
    class RestClient
    {
        public string endPoint { get; set; }
        public HttpCommand httpMethod { get; set; }

        public RestClient()
        {
            endPoint = string.Empty; 
            httpMethod = HttpCommand.Get;
        }

        public string MakeRequest()
        {
            string strResponseValue = string.Empty;
            // Using cast as in class doc
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(endPoint);
            request.Method = httpMethod.ToString();

            using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("Error code: " + response.StatusCode);
                }
                // Getting the data from API response
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                        // Read all the data available
                    }
                }
                // End of getting data

            }
            //End of response
            return strResponseValue;
        }


    }

    public enum HttpCommand
    {
        Get,
    }
}
