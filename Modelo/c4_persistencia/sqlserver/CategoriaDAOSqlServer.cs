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
    public class CategoriaDAOSqlServer : ICategoriaDAO
    {
        GestorODBC gestorODBC;
        public CategoriaDAOSqlServer(GestorODBC gestorODBC)
        {
            this.gestorODBC = gestorODBC;
        }

        public Categoria buscarCategoria(int codigocategoria)
        {
            try
            {
                Categoria categoria = null;
                string consultaSQL = "select codigocategoria,nombrecategoria from categoria where codigocategoria = @codigocategoria";
                SqlDataReader resultado;
                SqlCommand sentencia;
                sentencia = gestorODBC.prepararSentencia(consultaSQL);
                sentencia.Parameters.Add("@codigocategoria", Int).Value = codigocategoria;
                resultado = sentencia.ExecuteReader();
                if (resultado.Read())
                {
                    categoria = new Categoria();
                    categoria.codigocategoria = (int)resultado[0];
                    categoria.nombrecategoria = (string)resultado[1];
                }
                resultado.Close();
                return categoria;
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorConsultar(); ;
            }
        }

        public Categoria buscarProductosPorCategoria(int codigoCategoria)
        {
            try
            {
                Categoria categoria = null;
                string consultaSQL = "SELECT c.codigocategoria, c.nombrecategoria FROM categoria c where c.codigocategoria=@codigocategoria";
                SqlDataReader resultado;
                SqlCommand sentencia;
                sentencia = gestorODBC.prepararSentencia(consultaSQL);
                sentencia.Parameters.Add("@codigocategoria", Int).Value = codigoCategoria;
                resultado = sentencia.ExecuteReader();
                if (resultado.Read())
                {
                    categoria = new Categoria();
                    categoria.codigocategoria = (int)resultado[0];
                    categoria.nombrecategoria = (string)resultado[1];
                    categoria.listaSubCategoria = listaSubCategorias(categoria);
                }
                resultado.Close();
                return categoria;
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorConsultar();
            }

        }

        private List<SubCategoria> listaSubCategorias(Categoria categoria)
        {
            try
            {
                List<SubCategoria> listasubcategorias = new List<SubCategoria>();
                SubCategoria subCategoria;
                string consultaSQL = "SELECT sc.codigosubcategoria,sc.nombresubcategoria FROM subcategoria sc where sc.codigocategoria=@codigocategoria";
                SqlDataReader resultado;
                SqlCommand sentencia;
                sentencia = gestorODBC.prepararSentencia(consultaSQL);
                sentencia.Parameters.Add("@codigocategoria", Int).Value = categoria.codigocategoria;
                resultado = sentencia.ExecuteReader();
                while (resultado.Read())
                {
                    subCategoria = new SubCategoria();
                    subCategoria.codigosubcategoria = (int)resultado[0];
                    subCategoria.nombresubcategoria = (string)resultado[1];
                    subCategoria.listaLineaSubCategoria = listaLineaSubCategoria(subCategoria);
                    listasubcategorias.Add(subCategoria);
                }
                resultado.Close();
                return listasubcategorias;
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorConsultar();
            }
        }
        private List<LineaSubCategoria> listaLineaSubCategoria(SubCategoria subCategoria)
        {
            try
            {
                List<LineaSubCategoria> listalineasubcategoria = new List<LineaSubCategoria>();
                LineaSubCategoria lineaSubCategoria;
                string consultaSQL = "SELECT lc.codigolineasubcategoria, lc.nombrelineasubcategoria FROM lineasubcategoria lc where lc.codigosubcategoria=@codigosubcategoria";
                SqlDataReader resultado;
                SqlCommand sentencia;
                sentencia = gestorODBC.prepararSentencia(consultaSQL);
                sentencia.Parameters.Add("@codigosubcategoria", Int).Value = subCategoria.codigosubcategoria;
                resultado = sentencia.ExecuteReader();
                while (resultado.Read())
                {
                    lineaSubCategoria = new LineaSubCategoria();
                    lineaSubCategoria.codigolinea = (int)resultado[0];
                    lineaSubCategoria.nombrelinea = (string)resultado[1];
                    lineaSubCategoria.listaProductos = listaProductos(lineaSubCategoria);
                    listalineasubcategoria.Add(lineaSubCategoria);
                }
                resultado.Close();
                return listalineasubcategoria;
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
                    ImagenProductoDAOSqlServer imagenProductoDao = new ImagenProductoDAOSqlServer(gestorODBC);
                    producto.agregarImagen(imagenProductoDao.buscarImagenPrincipalProducto(producto));
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

        public void crearCategoria(Categoria categoria)
        {
            try
            {
                string sentenciaSQL = "INSERT INTO categoria(nombrecategoria ) VALUES(@nombrecategoria)";
                SqlCommand sentencia;
                sentencia = gestorODBC.prepararSentencia(sentenciaSQL);
                sentencia.Parameters.Add("@nombrecategoria", VarChar, 50).Value = categoria.nombrecategoria;
                sentencia.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorInsertar();
            }
        }

        public void editarCategoria(Categoria categoria)
        {
            try
            {
                string sentenciaSQL = "update categoria set nombrecategoria=@nombrecategoria where codigocategoria = @codigocategoria ";
                SqlCommand sentencia;
                sentencia = gestorODBC.prepararSentencia(sentenciaSQL);
                sentencia.Parameters.Add("@nombrecategoria", VarChar, 50).Value = categoria.nombrecategoria;
                sentencia.Parameters.Add("@codigocategoria", Int).Value = categoria.codigocategoria;
                sentencia.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorModificar();
            }
        }

        public void eliminarCategoria(Categoria categoria)
        {
            try
            {
                string sentenciaSQL = "DELETE FROM categoria WHERE codigocategoria = @codigocategoria";
                SqlCommand sentencia;
                sentencia = gestorODBC.prepararSentencia(sentenciaSQL);
                sentencia.Parameters.Add("@codigocategoria", Int).Value = categoria.codigocategoria;
                sentencia.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorEliminar();
            }
        }

        public List<Categoria> listarCategorias()
        {
            try
            {
                List<Categoria> listaCategoria = new List<Categoria>();
                Categoria categoria = null;
                string consultaSQL = "select codigocategoria,nombrecategoria from categoria order by codigocategoria desc";
                SqlDataReader resultado;
                resultado = gestorODBC.ejecutarConsulta(consultaSQL);
                while (resultado.Read())
                {
                    categoria = new Categoria();
                    categoria.codigocategoria = (int)resultado[0];
                    categoria.nombrecategoria = (string)resultado[1];
                    listaCategoria.Add(categoria);
                }
                resultado.Close();
                return listaCategoria;
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorConsultar();
            }
        }

        public List<Categoria> listaCategoriaMenu()
        {
            try
            {
                List<Categoria> listaCategoria = new List<Categoria>();
                Categoria categoria = null;
                string consultaSQL = "select codigocategoria,nombrecategoria from categoria";
                SqlDataReader resultado;
                resultado = gestorODBC.ejecutarConsulta(consultaSQL);
                while (resultado.Read())
                {
                    categoria = new Categoria();
                    categoria.codigocategoria = (int)resultado[0];
                    categoria.nombrecategoria = (string)resultado[1];
                    SubCategoriaDAOSqlServer subCategoria = new SubCategoriaDAOSqlServer(gestorODBC);
                    categoria.listaSubCategoria = subCategoria.listarSubCategoriaMenu(categoria);
                    listaCategoria.Add(categoria);
                }
                resultado.Close();
                return listaCategoria;
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorConsultar();
            }
        }
    }
}
