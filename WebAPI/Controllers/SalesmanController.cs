using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using LSLIBWebBased;
using System.Data;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    public class SalesmanController : ApiController
    {
        // GET api/Salesman
        public IEnumerable<string> Get()
        {
            yield return WebAPI.Models.LIB_CRUD.LoadStaffInfo("All").ToString();
        }

        // GET api/Salesman/5
        public string Get(string psStaffID)
        {           
            return WebAPI.Models.LIB_CRUD.LoadStaffInfo(psStaffID).ToString();
        }


    }
}
