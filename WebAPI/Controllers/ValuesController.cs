using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LSLIBWebBased;
using System.Data;
using System.Web.Script.Serialization;


namespace WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
            ClsLoadFieldHelper.fAddSqlParameter("@username", id);
            ClsLoadFieldHelper.fAddSqlParameter("@ContentType", "");

            ClsLoadFieldHelper.fBuildDataSet("stp_wf_rss_scs_API_GridInformationTable");
            return DataTableToJSON(ClsLoadFieldHelper.fGetDataSet().Tables[0]).ToString();
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
        public static object DataTableToJSON(DataTable table)
        {
            var list = new List<Dictionary<string, object>>();

            foreach (DataRow row in table.Rows)
            {
                var dict = new Dictionary<string, object>();

                foreach (DataColumn col in table.Columns)
                {
                    dict[col.ColumnName] = (Convert.ToString(row[col]));
                }
                list.Add(dict);
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            return serializer.Serialize(list);
        }
    }
}
