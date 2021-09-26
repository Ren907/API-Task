using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

using System.Web.Mvc;
using System.Web.Script.Serialization;
using API_Task.Models;
using Newtonsoft.Json;

namespace API_Task.Controllers
{
    public class AdviceSlipSearchController : Controller
    {
        private int slipId;
        private string slipAdvice;
        private string slipDate;


        [HttpGet]
        public ActionResult AdviceSlipSearchView()
        {

            return View();

        }

      [HttpPost]
        public ActionResult AdviceSlipSearchView(string SearchName)
        {
            string URL = String.Format("https://api.adviceslip.com/advice/search/");
            string GetURL = URL + SearchName;
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

            Rootobject obj = JsonConvert.DeserializeObject<Rootobject>(strResult);

            Rootobject model = new Rootobject()
            {

                total_results = obj.total_results,
                query = obj.query,
                slips = obj.slips

            };

            if (model.total_results == null)
            {
                ModelState.AddModelError("NoRecords", "No Records found when Searching: " + SearchName);
                return View();
            }

            else
            {


                foreach (Slip item in obj.slips)
                {

                    {
                        slipId = item.id;
                        slipDate = item.date;
                        slipAdvice = item.advice;

                    }
                }

    
                ModelState.AddModelError("RecordsFound", "Records Found Successfully");
                return View(model);

            }
        }
    }
}
