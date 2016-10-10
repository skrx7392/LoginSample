using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace LoginService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public bool GetData(string userName, string password)
        {
            string conString = "Data Source=.;Initial Catalog=LoginTable;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Select *  from LoginTable", con))
                    using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        if(reader.GetString(0) == userName && reader.GetString(1)==password)
                        {
                            return true;
                        }
                    }
                }

            }
            return false;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
