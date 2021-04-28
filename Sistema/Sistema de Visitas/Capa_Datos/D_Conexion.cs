using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Capa_Datos
{
    public class D_Conexion
    {
        private readonly string cnxx;

        protected SqlConnection cxn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconnect"].ConnectionString);

        public D_Conexion()
        {
            cnxx = (ConfigurationManager.ConnectionStrings["sqlconnect"].ConnectionString);

        }
        protected SqlConnection GetCnx()
        {
            return new SqlConnection(cnxx);
        }
    }
}
