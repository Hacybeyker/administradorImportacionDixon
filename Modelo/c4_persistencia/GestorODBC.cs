using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Modelo.c5_transversal.excepcion;
 

namespace Modelo.c4_persistencia
{
    public abstract class GestorODBC
    {
        protected SqlConnection conexion;
        public abstract void abrirConexion();
        public void cerrarConexion()
        {
            try
            {
                conexion.Close();
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorCerrarConexion();
            }
        }

        //Aun no se ha probado el metodo
        public void iniciarTransaccion()
        {
            try
            {
                conexion.BeginTransaction().InitializeLifetimeService();
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorIniciarTransaccion();
            }
        }
        //Aun no se ha probado el metodo
        public void terminarTransaccion()
        {
            try
            {
                conexion.BeginTransaction().Commit();
                conexion.Close();
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorTerminarTransaccion();
            }
        }
        //Aun no se ha probado el metodo
        public void cancelarTransaccion()
        {
            try
            {
                conexion.BeginTransaction().Rollback();
                conexion.Close();
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorCancelarTransaccion();
            }
        }
        public SqlCommand prepararSentencia(string sql)
        {
            SqlCommand sentencia;
            return sentencia = new SqlCommand(sql, conexion);
        }
        public SqlDataReader ejecutarConsulta(string sql)
        {
            SqlDataReader resultado;
            SqlCommand sentencia = prepararSentencia(sql);
            resultado = sentencia.ExecuteReader();
            return resultado;
        }
    }
}
