using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static System.Data.SqlDbType;
using Modelo.c3_dominio.contrato;
using Modelo.c3_dominio.entidad;
using Modelo.c5_transversal.excepcion;

namespace Modelo.c4_persistencia.sqlserver
{
    public class ContactoDAOSqlServer : IContactoDAO
    {
        GestorODBC gestorODBC;
        public ContactoDAOSqlServer(GestorODBC gestorODBC)
        {
            this.gestorODBC = gestorODBC;
        }

        public void agregarVisto(Contacto contacto)
        {
            try
            {
                string sentenciaSQL = "UPDATE contacto  SET vistocontacto='TRUE' WHERE codigocontacto = @codigocontacto";
                SqlCommand sentencia;
                sentencia = gestorODBC.prepararSentencia(sentenciaSQL);
                sentencia.Parameters.Add("@codigocontacto", Int).Value = contacto.codigoContacto;
                sentencia.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorModificar();
            }
        }

        public Contacto buscarContacto(int codigoContacto)
        {
            try
            {
                Contacto contacto = null;
                string consultaSQL = "SELECT codigocontacto, nombrecontacto, apellidoscontacto, empresacontacto, telefonocontacto, correocontacto, comentariocontacto, vistocontacto FROM contacto where codigocontacto=@codigocontacto";
                SqlDataReader resultado;
                SqlCommand sentencia;
                sentencia = gestorODBC.prepararSentencia(consultaSQL);
                sentencia.Parameters.Add("@codigocontacto", Int).Value = codigoContacto;
                resultado = sentencia.ExecuteReader();
                if (resultado.Read())
                {
                    contacto = new Contacto();
                    contacto.codigoContacto = (int)resultado[0];
                    contacto.nombreContacto = (string)resultado[1];
                    contacto.apellidoContacto = (string)resultado[2];
                    contacto.empresaContacto = (string)resultado[3];
                    contacto.telefonoContacto = (string)resultado[4];
                    contacto.correoContacto = (string)resultado[5];
                    contacto.comentarioContacto = (string)resultado[6];
                    contacto.visto = (bool)resultado[7];
                }
                resultado.Close();
                return contacto;
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorConsultar();
            }
        }

        public int cantidadContactosNoVistos()
        {
            try
            {
                int cantidad = 0;
                string consultaSQL = "select count(*)as cantidad from contacto where vistocontacto = 0";
                SqlDataReader resultado;
                resultado = gestorODBC.ejecutarConsulta(consultaSQL);
                if (resultado.Read()) {
                    cantidad = (int)resultado[0];
                }
                return cantidad;
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorConsultar();
            }
        }

        public void crearContacto(Contacto contacto)
        {
            try
            {
                string consultaSQL = "INSERT INTO contacto(nombrecontacto, correocontacto, comentariocontacto, vistocontacto) VALUES (@nombrecontacto, @correocontacto, @comentariocontacto, @vistocontacto)";
                SqlCommand sentencia;
                sentencia = gestorODBC.prepararSentencia(consultaSQL);
                sentencia.Parameters.Add("@nombrecontacto", VarChar, 50).Value = contacto.nombreContacto;
                sentencia.Parameters.Add("@correocontacto", VarChar, 100).Value = contacto.correoContacto;
                sentencia.Parameters.Add("@comentariocontacto", VarChar, 200).Value = contacto.comentarioContacto;
                sentencia.Parameters.Add("@vistocontacto", Bit).Value = contacto.visto;
                sentencia.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorConsultar();
            }
        }

        public List<Contacto> listaContactoNoVisto()
        {
            try
            {
                List<Contacto> listacontacto = new List<Contacto>();
                Contacto contacto = null;
                string consultaSQL = "select top 4 codigocontacto,nombrecontacto,apellidoscontacto,empresacontacto,telefonocontacto,correocontacto,comentariocontacto,vistocontacto from contacto where vistocontacto=0";
                SqlDataReader resultado;
                resultado = gestorODBC.ejecutarConsulta(consultaSQL);
                while (resultado.Read())
                {
                    contacto = new Contacto();
                    contacto.codigoContacto = (int)resultado[0];
                    contacto.nombreContacto = (string)resultado[1];
                    contacto.apellidoContacto = (string)resultado[2];
                    contacto.empresaContacto = (string)resultado[3];
                    contacto.telefonoContacto = (string)resultado[4];
                    contacto.correoContacto = (string)resultado[5];
                    contacto.comentarioContacto = (string)resultado[6];
                    contacto.visto = (bool)resultado[7];
                    listacontacto.Add(contacto);
                }
                resultado.Close();
                return listacontacto;
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorConsultar();
            }
        }

        public List<Contacto> listaContactos()
        {
            try
            {
                List<Contacto> listacontacto = new List<Contacto>();
                Contacto contacto = null;
                string consultaSQL = "SELECT codigocontacto, nombrecontacto, correocontacto, comentariocontacto, vistocontacto FROM contacto order by codigocontacto desc";
                SqlDataReader resultado;
                resultado = gestorODBC.ejecutarConsulta(consultaSQL);
                while (resultado.Read())
                {
                    contacto = new Contacto();
                    contacto.codigoContacto = (int)resultado[0];
                    contacto.nombreContacto = (string)resultado[1];
                    contacto.correoContacto = (string)resultado[2];
                    contacto.comentarioContacto = (string)resultado[3];
                    contacto.visto = (bool)resultado[4];
                    listacontacto.Add(contacto);
                }
                resultado.Close();
                return listacontacto;
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorConsultar();
            }
        }
    }
}