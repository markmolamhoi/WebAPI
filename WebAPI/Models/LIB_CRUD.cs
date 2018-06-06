using LSLIBWebBased;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public static class LIB_CRUD
    {
        public static object LoadStaffInfo(string psStaffID)
        {
            ClassLoadFieldHelper ClsLoadFieldHelper = new ClassLoadFieldHelper();
            ClsLoadFieldHelper.fAddSqlParameter("@staff_id", psStaffID);
            ClsLoadFieldHelper.fAddSqlParameter("@lang", "sc");

            ClsLoadFieldHelper.fBuildDataSet("stp_getStaffInfo");

            return WebAPI.Models.LIB_JSON.DataTableToJSON_JavaScriptSerializer(ClsLoadFieldHelper.fGetDataSet().Tables[0]).ToString().Replace("\\", "");
        }

    }
}