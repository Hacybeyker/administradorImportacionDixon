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
    public class LineaSubCategoriaDAOSqlServer : ILineaSubCategoriaDAO
    {
        GestorODBC gestorODBC;
        public LineaSubCategoriaDAOSqlServer(GestorODBC gestorODBC)
        {
            this.gestorODBC = gestorODBC;
        }

        public LineaSubCategoria buscarLineaSubCategoria(int codigoLineaSubCategoria)
        {
            try
            {
                LineaSubCategoria lineaSubCategoria = null;
                string consultaSQL = "SELECT codigosubcategoria, codigolineasubcategoria, nombrelineasubcategoria  FROM lineasubcategoria where codigolineasubcategoria=@codigolineasubcategoria";
                SqlDataReader resultado;
                SqlCommand sentencia;
                sentencia = gestorODBC.prepararSentencia(consultaSQL);
                sentencia.Parameters.Add("@codigolineasubcategoria", Int).Value = codigoLineaSubCategoria;
                resultado = sentencia.ExecuteReader();
                if (resultado.Read())
                {
                    lineaSubCategoria = new LineaSubCategoria();
                    lineaSubCategoria.codigosubcategoria = (int)resultado[0];
                    lineaSubCategoria.codigolinea = (int)resultado[1];
                    lineaSubCategoria.nombrelinea = (string)resultado[2];
                }
                resultado.Close();
                return lineaSubCategoria;
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorConsultar();
            }
        }

        public List<LineaSubCategoria> buscarLineaSubCategorias(SubCategoria subCategoria)
        {
            try
            {
                List<LineaSubCategoria> listaLineaSubCategoria = new List<LineaSubCategoria>();
                LineaSubCategoria lineaSubCategoria = null;
                string consultaSQL = "SELECT codigolineasubcategoria, nombrelineasubcategoria  FROM lineasubcategoria where codigosubcategoria=@codigosubcategoria order by codigolineasubcategoria desc";
                SqlCommand sentencia;
                sentencia = gestorODBC.prepararSentencia(consultaSQL);
                sentencia.Parameters.Add("@codigosubcategoria", Int).Value = subCategoria.codigosubcategoria;
                SqlDataReader resultado;
                resultado = sentencia.ExecuteReader();
                while (resultado.Read())
                {
                    lineaSubCategoria = new LineaSubCategoria();
                    lineaSubCategoria.codigolinea = (int)resultado[0];
                    lineaSubCategoria.nombrelinea = (string)resultado[1];
                    listaLineaSubCategoria.Add(lineaSubCategoria);
                }
                resultado.Close();
                return listaLineaSubCategoria;
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorConsultar();
            }
        }

        public LineaSubCategoria buscarProductosPorLinea(int codigoLineaSubCategoria)
        {
            try
            {
                LineaSubCategoria lineaSubCategoria = null;
                string consultaSQL = "SELECT lc.codigolineasubcategoria, lc.nombrelineasubcategoria FROM lineasubcategoria lc where lc.codigolineasubcategoria=@codigolineasubcategoria";
                SqlDataReader resultado;
                SqlCommand sentencia;
                sentencia = gestorODBC.prepararSentencia(consultaSQL);
                sentencia.Parameters.Add("@codigolineasubcategoria", Int).Value = codigoLineaSubCategoria;
                resultado = sentencia.ExecuteReader();
                if (resultado.Read())
                {
                    lineaSubCategoria = new LineaSubCategoria();
                    lineaSubCategoria.codigolinea = (int)resultado[0];
                    lineaSubCategoria.nombrelinea = (string)resultado[1];
                    lineaSubCategoria.listaProductos = listaProductos(lineaSubCategoria);
                }
                resultado.Close();
                return lineaSubCategoria;
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorConsultar();
            }
        }

        private List<Producto> listaProductos(LineaSubCategoria lineaSubCategoria)
        {
            try
            {
                List<Producto> listaproductos = new List<Producto>();
                Producto producto;
                string consultaSQL = "SELECT p.codigoproducto, p.nombreproducto, p.descripcionproducto, p.precioproducto, p.detallesproducto FROM producto p where p.codigolineasubcategoria=@codigolineasubcategoria";
                SqlDataReader resultado;
                SqlCommand sentencia;
                sentencia = gestorODBC.prepararSentencia(consultaSQL);
                sentencia.Parameters.Add("@codigolineasubcategoria", Int).Value = lineaSubCategoria.codigolinea;
                resultado = sentencia.ExecuteReader();
                while (resultado.Read())
                {
                    producto = new Producto();
                    producto.codigoProducto = (int)resultado[0];
                    producto.nombreProducto = (string)resultado[1];
                    producto.descripcionProducto = (string)resultado[2];
                    producto.precioProducto = (decimal)resultado[3];
                    producto.detalleProducto = (string)resultado[4];
                    ImagenProductoDAOSqlServer imagenProductoDAO = new ImagenProductoDAOSqlServer(gestorODBC);
                    producto.agregarImagen(imagenProductoDAO.buscarImagenPrincipalProducto(producto));
                    listaproductos.Add(producto);
                }
                resultado.Close();
                return listaproductos;
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorConsultar();
            }
        }
        public void crearLineaSubCategoria(LineaSubCategoria lineaSubCategoria, int codigoSubCategoria)
        {
            try
            {
                string sentenciaSQL = "INSERT INTO lineasubcategoria(codigosubcategoria, nombrelineasubcategoria) VALUES (@codigosubcategoria, @nombrelineasubcategoria)";
                SqlCommand sentencia;
                sentencia = gestorODBC.prepararSentencia(sentenciaSQL);
                sentencia.Parameters.Add("@codigosubcategoria", Int).Value = codigoSubCategoria;
                sentencia.Parameters.Add("nombrelineasubcategoria", VarChar, 50).Value = lineaSubCategoria.nombrelinea;
                sentencia.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorInsertar();
            }
        }

        public void editarLineaSubCategoria(LineaSubCategoria lineaSubCategoria)
        {
            try
            {
                string consultaSQL = "update lineasubcategoria set nombrelineasubcategoria=@nombrelineasubcategoria where codigolineasubcategoria = @codigolineasubcategoria ";
                SqlCommand sentencia;
                sentencia = gestorODBC.prepararSentencia(consultaSQL);
                sentencia.Parameters.Add("@nombrelineasubcategoria", VarChar, 50).Value = lineaSubCategoria.nombrelinea;
                sentencia.Parameters.Add("@codigolineasubcategoria", Int).Value = lineaSubCategoria.codigolinea;
                sentencia.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorModificar();
            }
        }

        public void eliminarLineaSubCategoria(LineaSubCategoria lineaSubCategoria)
        {
            try
            {
                string consultaSQL = "DELETE FROM lineasubcategoria WHERE codigolineasubcategoria = @codigolineasubcategoria";
                SqlCommand sentencia;
                sentencia = gestorODBC.prepararSentencia(consultaSQL);
                sentencia.Parameters.Add("@codigolineasubcategoria", Int).Value = lineaSubCategoria.codigolinea;
                sentencia.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorConsultar();
            }
        }

       
    }
}
