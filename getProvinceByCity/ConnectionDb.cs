using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace getProvinceByCity
{
    class ConnectionDb
    {
        public static void initDb(DataGridView dataGridView)
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=citys.mdb");
            OleDbCommand cmd = conn.CreateCommand();

            string sql = "select city_name,city_type, province_name from citys where city_name_abbr =?";


            cmd.CommandText = "select * from citys";
            conn.Open();
         
            OleDbDataReader sdr = cmd.ExecuteReader();
            //SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            if (sdr.HasRows)
            {
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    dt.Columns.Add(sdr.GetName(i));
                }
                dt.Rows.Clear();
            }
            while (sdr.Read())
            {
                DataRow row = dt.NewRow();
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    row[i] = sdr[i];
                }
                dt.Rows.Add(row);
            }
            cmd.Dispose();
            conn.Close();
            dataGridView.DataSource = dt;
        }
    }
}
