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
    public class ImagenProductoDAOSqlServer : IImagenProductoDAO
    {
        GestorODBC gestorODBC;
        public ImagenProductoDAOSqlServer(GestorODBC gestorODBC)
        {
            this.gestorODBC = gestorODBC;
        }

        public ImagenProducto buscarImagenPrincipalProducto(Producto producto)
        {
            try
            {
                ImagenProducto ImagenProducto = null;
                string consultaSQL = "SELECT img.codigoimagenproducto,  img.direccionimagenproducto, img.nombreimagenproducto, img.principalimagenproducto  FROM imagenproducto img where img.codigoproducto=@codigoproducto and img.principalimagenproducto='TRUE'";
                SqlDataReader resultado;
                SqlCommand sentencia;
                sentencia = gestorODBC.prepararSentencia(consultaSQL);
                sentencia.Parameters.Add("@codigoproducto", Int).Value = producto.codigoProducto;
                resultado = sentencia.ExecuteReader();
                if (resultado.Read())
                {
                    ImagenProducto = new ImagenProducto();
                    ImagenProducto.codigoimagen = (int)resultado[0];
                    ImagenProducto.urlimagen = (string)resultado[1];
                    ImagenProducto.nombreimagen = (string)resultado[2];
                    ImagenProducto.principal = (bool)resultado[3];
                }
                resultado.Close();
                return ImagenProducto;
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorConsultar();
            }
        }

        public ImagenProducto buscarImagenProducto(int codigoimagenproducto)
        {
            try
            {
                ImagenProducto ImagenProducto = null;
                string consultaSQL = "SELECT img.codigoproducto, img.codigoimagenproducto,  img.direccionimagenproducto, img.nombreimagenproducto, img.principalimagenproducto  FROM imagenproducto img where img.codigoimagenproducto=@codigoimagenproducto";
                SqlDataReader resultado;
                SqlCommand sentencia;
                sentencia = gestorODBC.prepararSentencia(consultaSQL);
                sentencia.Parameters.Add("@codigoimagenproducto", Int).Value = codigoimagenproducto;
                resultado = sentencia.ExecuteReader();
                if (resultado.Read())
                {
                    ImagenProducto = new ImagenProducto();
                    ImagenProducto.codigoproducto = (int)resultado[0];
                    ImagenProducto.codigoimagen = (int)resultado[1];
                    ImagenProducto.urlimagen = (string)resultado[2];
                    ImagenProducto.nombreimagen = (string)resultado[3];
                    ImagenProducto.principal = (bool)resultado[4];
                }
                resultado.Close();
                return ImagenProducto;
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorConsultar();
            }
        }

        public void crearImagenProducto(ImagenProducto ImagenProducto, int codigoproducto)
        {
            try
            {
                string sentenciaSQL = "INSERT INTO imagenproducto(codigoproducto,direccionimagenproducto,nombreimagenproducto,principalimagenproducto) VALUES(@codigoproducto,@direccionimagenproducto,@nombreimagenproducto,@principalimagenproducto)";
                SqlCommand sentencia;
                sentencia = gestorODBC.prepararSentencia(sentenciaSQL);
                sentencia.Parameters.Add("@codigoproducto", Int).Value = codigoproducto;
                sentencia.Parameters.Add("@direccionimagenproducto", VarChar, 500).Value = ImagenProducto.urlimagen;
                sentencia.Parameters.Add("@nombreimagenproducto", VarChar, 100).Value = ImagenProducto.nombreimagen;
                sentencia.Parameters.Add("@principalimagenproducto", Bit).Value = ImagenProducto.principal;
                sentencia.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorInsertar();
            }
        }

        public void eliminarImagenProducto(ImagenProducto ImagenProducto)
        {
            try
            {
                string sentenciaSQL = "delete imagenproducto where codigoimagenproducto=@codigoimagenproducto";
                SqlCommand sentencia;
                sentencia = gestorODBC.prepararSentencia(sentenciaSQL);
                sentencia.Parameters.Add("@codigoimagenproducto", Int).Value = ImagenProducto.codigoimagen;
                sentencia.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorEliminar();
            }
        }

        public List<ImagenProducto> listarImagenesPorProducto(Producto producto)
        {
            try
            {
                List<ImagenProducto> listaImagenProducto = new List<ImagenProducto>();
                ImagenProducto ImagenProducto = null;
                string consultaSQL = "select img.codigoimagenproducto,img.direccionimagenproducto, img.nombreimagenproducto, img.principalimagenproducto from imagenproducto img where img.codigoproducto = @codigoProducto ";
                SqlCommand sentencia;
                SqlDataReader resultado;
                sentencia = gestorODBC.prepararSentencia(consultaSQL);
                sentencia.Parameters.Add("@codigoProducto", Int).Value = producto.codigoProducto;
                resultado = sentencia.ExecuteReader();
                while (resultado.Read())
                {
                    ImagenProducto = new ImagenProducto();
                    ImagenProducto.codigoimagen = (int)resultado[0];
                    ImagenProducto.urlimagen = (string)resultado[1];
                    ImagenProducto.nombreimagen = (string)resultado[2];
                    ImagenProducto.principal = (bool)resultado[3];
                    listaImagenProducto.Add(ImagenProducto);
                }
                resultado.Close();
                return listaImagenProducto;
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorConsultar(); ;
            }
        }

        public void modificarImagenProducto(ImagenProducto ImagenProducto)
        {
            try
            {
                string sentenciaSQL = "UPDATE imagenproducto SET direccionimagenproducto=@direccionimagenproducto,  nombreimagenproducto=@nombreimagenproducto, principalimagenproducto=@principalimagenproducto WHERE codigoimagenproducto=@codigoimagenproducto";
                SqlCommand sentencia;
                sentencia = gestorODBC.prepararSentencia(sentenciaSQL);
                sentencia.Parameters.Add("@direccionimagenproducto", VarChar, 100).Value = ImagenProducto.urlimagen;
                sentencia.Parameters.Add("@nombreimagenproducto", VarChar, 200).Value = ImagenProducto.nombreimagen;
                sentencia.Parameters.Add("@principalimagenproducto", Bit).Value = ImagenProducto.principal;
                sentencia.Parameters.Add("@codigoimagenproducto", Int).Value = ImagenProducto.codigoimagen;
                sentencia.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw ExcepcionSQL.crearErrorModificar();
            }
        }
    }
}
