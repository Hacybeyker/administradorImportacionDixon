using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Modelo.c5_transversal.excepcion;

namespace Modelo.c4_persistencia.sqlserver
{
    public class ConexionSqlServer : GestorODBC
    {
        public override void abrirConexion()
        {
            try
            {
                string url = "data source=184.168.194.75;initial catalog=usaimportsUser_01;persist security info=True;user id=snet;password=Peru@Peru2016;MultipleActiveResultSets=True;";
                //string url = "data source=DESKTOP-BR8KL83;initial catalog=paginaweb2;persist security info=True;user id=desarrollador;password=123;MultipleActiveResultSets=True;";
                conexion = new SqlConnection(url);
                conexion.Open();
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorAbrirConexion(); ;
            }
        }
    }
}
