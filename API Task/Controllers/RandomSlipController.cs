using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;


using API_Task.Models;
namespace API_Task.Controllers
{
    public class RandomSlipController : Controller
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public string Get(int id)
        {
            return "value";
        }

        public ActionResult RandomSlipView()
        {
            string GetURL = String.Format("	https://api.adviceslip.com/advice");
            WebRequest requestObject = WebRequest.Create(GetURL);
            requestObject.Method = "GET";
            HttpWebResponse responseObject = null;
            responseObject = (HttpWebResponse)requestObject.GetResponse();

            string strResult = null;
            using (Stream str = responseObject.GetResponseStream())
            {
                StreamReader sr = new StreamReader(str);
                strResult = sr.ReadToEnd();
                sr.Close();
            }


            dynamic Obj = JsonConvert.DeserializeObject(strResult);

            Slip model = new Slip()
            {
                id = Obj.slip.id,
                advice = Obj.slip.advice
            };

            return View(model);

        }

        
    }
}
