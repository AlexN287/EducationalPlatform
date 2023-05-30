/*using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/
using System.Configuration;
using System.Data.SqlClient;
//using Microsoft.Extensions.Configuration;

namespace Tema3_MVP.Models.Models
{
    public static class DALHelper
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["myConStr"].ConnectionString;

        public static SqlConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
    }
}
