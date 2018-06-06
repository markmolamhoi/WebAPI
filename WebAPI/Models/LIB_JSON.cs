using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Script.Serialization;
using System.ComponentModel;

namespace WebAPI.Models
{
    public static class LIB_JSON
    {
        /// <summary>
        /// Convert DataTable to JSON using JavaScriptSerializer.
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static object DataTableToJSON_JavaScriptSerializer(DataTable table)
        {
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> lRowList = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow lDataRow in table.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    row.Add(col.ColumnName, lDataRow[col]);
                }
                lRowList.Add(row);
            }

            
            return serializer.Serialize(lRowList);
        }

        /// <summary>
        /// Convert DataTable to JSON using StringBuilder.
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
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


        public static DataTable JSONToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection lPropertyDescriptorCollection = TypeDescriptor.GetProperties(typeof(T));
            DataTable lDataTable = new DataTable();
            for (int i = 0; i < lPropertyDescriptorCollection.Count; i++)
            {
                PropertyDescriptor lPropertyDescriptor = lPropertyDescriptorCollection[i];
                lDataTable.Columns.Add(lPropertyDescriptor.Name, lPropertyDescriptor.PropertyType);
            }
            object[] values = new object[lPropertyDescriptorCollection.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = lPropertyDescriptorCollection[i].GetValue(item);
                }
                lDataTable.Rows.Add(values);
            }
            return lDataTable;
        }
    }
}