using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.c3_dominio.contrato;
using Modelo.c3_dominio.entidad;
using Modelo.c4_persistencia.sqlserver;
using Modelo.c4_persistencia;

namespace Modelo.c2_aplicacion
{
    public class GestionarimagenProductoServicio
    {
        GestorODBC gestorODBC;
        IImagenProductoDAO imagenProductoDAO;
        public GestionarimagenProductoServicio()
        {
            gestorODBC = new ConexionSqlServer();
            imagenProductoDAO = new ImagenProductoDAOSqlServer(gestorODBC);
        }

        public ImagenProducto buscarImagenPrincipalProducto(Producto producto)
        {
            try
            {
                gestorODBC.abrirConexion();
                ImagenProducto imagenProducto;
                imagenProducto = imagenProductoDAO.buscarImagenPrincipalProducto(producto);
                gestorODBC.cerrarConexion();
                return imagenProducto;
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }
        }
        public ImagenProducto buscarImagenProducto(int codigoimagenproducto) {
            try
            {
                gestorODBC.abrirConexion();
                ImagenProducto imagenProducto;
                imagenProducto = imagenProductoDAO.buscarImagenProducto(codigoimagenproducto);
                gestorODBC.cerrarConexion();
                return imagenProducto;
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }

        }
        public void crearimagenProducto(ImagenProducto imagenProducto, int codigoproducto)
        {
            try
            {
                gestorODBC.abrirConexion();
                imagenProductoDAO.crearImagenProducto(imagenProducto, codigoproducto);
                gestorODBC.cerrarConexion();
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }
        }

        public void eliminarimagenProducto(ImagenProducto imagenProducto)
        {
            try
            {
                gestorODBC.abrirConexion();
                imagenProducto.validarPrincipal(imagenProducto);
                imagenProductoDAO.eliminarImagenProducto(imagenProducto);
                gestorODBC.cerrarConexion();
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }
        }

        public List<ImagenProducto> listarImagenesPorProducto(Producto producto)
        {
            try
            {
                gestorODBC.abrirConexion();
                List<ImagenProducto> listaimagenProductoPorProducto;
                listaimagenProductoPorProducto = imagenProductoDAO.listarImagenesPorProducto(producto);
                gestorODBC.cerrarConexion();
                return listaimagenProductoPorProducto;
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }
        }

        public void modificarimagenProducto(ImagenProducto imagenProducto)
        {
            try
            {
                gestorODBC.abrirConexion();
                imagenProductoDAO.modificarImagenProducto(imagenProducto);
                gestorODBC.cerrarConexion();
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }
        }
    }
}
