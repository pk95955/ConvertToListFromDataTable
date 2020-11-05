using System;
using System.Data;
using System.Collections.Generic;
namespace ConvertToListFromDataTable
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dtEmp = emplClass.getEmpData();
            var employee = dtEmp.ConvetToList<employees>();
        }       
    }
   
    internal static class ExtClass
    {
        public static List<T> ConvetToList<T>(this DataTable tbl)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in tbl.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();
            var sss = obj ;
            foreach (DataColumn column in dr.Table.Columns)
            {
                var v = temp.GetProperties();
                foreach (System.Reflection.PropertyInfo pro in temp.GetProperties() )
                {
                    if (pro.Name == column.ColumnName && DBNull.Value != dr[column.ColumnName])
                        pro.SetValue(obj, Convert.ChangeType(dr[column.ColumnName], pro.PropertyType), null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }
    internal class emplClass {
        internal static DataTable getEmpData()
        {
            // create datatable of an employees 
            DataTable dtEmp = new DataTable();
            dtEmp.Columns.AddRange(new DataColumn[] {
                new DataColumn("empID", typeof(short)),
                new DataColumn("empName", typeof(string)),
                new DataColumn("salary", typeof(decimal)) ,
                new DataColumn("salaryMonth", typeof(DateTime))
            });
            // adding rows employees 
            DataRow drEmp = dtEmp.NewRow();
            drEmp["empID"] = 1;
            drEmp["empName"] = "Praesh";
            drEmp["salary"] = 7000;
            drEmp["salaryMonth"] = "1 Jan 2020";
            dtEmp.Rows.Add(drEmp);

            drEmp = dtEmp.NewRow();
            drEmp["empID"] = 2;
            drEmp["empName"] = "Umesh";
            drEmp["salary"] = 9000;
            drEmp["salaryMonth"] = "1 Jan 2020";
         
            dtEmp.Rows.Add(drEmp);

            drEmp = dtEmp.NewRow();
            drEmp["empID"] = 3;
            drEmp["empName"] = "Prakash";
            drEmp["salary"] = 14000;
            drEmp["salaryMonth"] = "1 Jan 2020";
            dtEmp.Rows.Add(drEmp);

            drEmp = dtEmp.NewRow();
            drEmp["empID"] = 3;
            drEmp["empName"] = "Rupesh";
            drEmp["salary"] = 13000;
            drEmp["salaryMonth"] = "1 Jan 2020";
            dtEmp.Rows.Add(drEmp);
            // returnj employees data 
            return dtEmp;
        }
    }
    // employee class 
    public class employees
    {
        public short empID { get; set; }
        public string empName { get; set; }
        public decimal salary { get; set; }
        public DateTime salaryMonth { get; set; }
        

    }

}
