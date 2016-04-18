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
    public class GestionarProductoServicio
    {
        GestorODBC gestorODBC;
        IProductoDAO productoDAO;
        public GestionarProductoServicio()
        {
            gestorODBC = new ConexionSqlServer();
            productoDAO = new ProductoDAOSqlServer(gestorODBC);
        }

        public Producto buscarProducto(int codigoProducto)
        {
            try
            {
                gestorODBC.abrirConexion();
                Producto producto;
                producto = productoDAO.buscarProducto(codigoProducto);
                return producto;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<Producto> buscarProductos()
        {
            try
            {
                gestorODBC.abrirConexion();
                List<Producto> listaProducto;
                listaProducto = productoDAO.buscarProductos();
                gestorODBC.cerrarConexion();
                return listaProducto;
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }
        }

        public void crearProducto(Producto producto, int codigoLinea)
        {
            try
            {
                gestorODBC.abrirConexion();
                productoDAO.crearProducto(producto, codigoLinea);
                gestorODBC.cerrarConexion();
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }
        }

        public void eliminarProducto(Producto producto)
        {
            try
            {
                gestorODBC.abrirConexion();
                productoDAO.eliminarProducto(producto);
                gestorODBC.cerrarConexion();
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }
        }

        public void modificarProducto(Producto producto)
        {
            try
            {
                gestorODBC.abrirConexion();
                productoDAO.modificarProducto(producto);
                gestorODBC.cerrarConexion();
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }
        }
        public List<Producto> buscarProductos(LineaSubCategoria lineaSubCategoria)
        {
            try
            {
                gestorODBC.abrirConexion();
                List<Producto> listaProductos;
                listaProductos = productoDAO.buscarProductos(lineaSubCategoria);
                gestorODBC.cerrarConexion();
                return listaProductos;
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }
        }
    }
}