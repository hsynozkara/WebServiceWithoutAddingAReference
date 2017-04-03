using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWebServiceApplication
{
    class Program
    {


        /* Basic Usage */
        public static string CallWebService(string URL)
        {
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(URL);
            objRequest.Method = "GET";
            objRequest.KeepAlive = false;
            objRequest.UseDefaultCredentials = true;

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
           
            string result = "";
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                sr.Close();
            }
            return result;
        }

        static void Main(string[] args)
        {

            /* Basic Usage */
            string JSONresponse = CallWebService("http://www.inorthwind.com/Service1.svc/getAllCustomers");
            List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(JSONresponse);



            // hard way
            WebService ws = new WebService("service_url", "method_name");
            ws.Params.Add("param1", "value_1");
            ws.Params.Add("param2", "value_2");
            ws.Invoke();
            // you can get result ws.ResultXML or ws.ResultString
        }


    }
}
