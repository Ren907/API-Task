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

     
    }
}
