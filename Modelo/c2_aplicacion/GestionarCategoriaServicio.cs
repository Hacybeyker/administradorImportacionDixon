using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.c3_dominio.contrato;
using Modelo.c3_dominio.entidad;
using Modelo.c4_persistencia;
using Modelo.c4_persistencia.sqlserver;

namespace Modelo.c2_aplicacion
{
    public class GestionarCategoriaServicio
    {
        GestorODBC gestorODBC;
        ICategoriaDAO categoriaDAO;
        public GestionarCategoriaServicio()
        {
            gestorODBC = new ConexionSqlServer();
            categoriaDAO = new CategoriaDAOSqlServer(gestorODBC);
        }
        public Categoria buscarCategoria(int codigocategoria)
        {
            try
            {
                gestorODBC.abrirConexion();
                Categoria categoria;
                categoria = categoriaDAO.buscarCategoria(codigocategoria);
                gestorODBC.cerrarConexion();
                return categoria;
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }
        }

        public void crearCategoria(Categoria categoria)
        {
            try
            {
                gestorODBC.abrirConexion();
                categoriaDAO.crearCategoria(categoria);
                gestorODBC.cerrarConexion();
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }
        }

        public void editarCategoria(Categoria categoria)
        {
            try
            {
                gestorODBC.abrirConexion();
                categoriaDAO.editarCategoria(categoria);
                gestorODBC.cerrarConexion();
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }
        }

        public void eliminarCategoria(Categoria categoria)
        {
            try
            {
                gestorODBC.abrirConexion();
                categoriaDAO.eliminarCategoria(categoria);
                gestorODBC.cerrarConexion();
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }
        }

        public List<Categoria> listarCategorias()
        {
            try
            {
                gestorODBC.abrirConexion();
                List<Categoria> listaCategorias;
                listaCategorias = categoriaDAO.listarCategorias();
                gestorODBC.cerrarConexion();
                return listaCategorias;
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }
        }

        public Categoria buscarProductosPorCategoria(int codigoCategoria)
        {
            try
            {
                gestorODBC.abrirConexion();
                Categoria categoria;
                categoria = categoriaDAO.buscarProductosPorCategoria(codigoCategoria);
                gestorODBC.cerrarConexion();
                return categoria;
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }
        }
        public List<Categoria> listaCategoriaMenu()
        {
            try
            {
                gestorODBC.abrirConexion();
                List<Categoria> listaCategoriaMenu;
                listaCategoriaMenu = categoriaDAO.listaCategoriaMenu();
                return listaCategoriaMenu;
            }
            catch (Exception)
            {
                gestorODBC.cerrarConexion();
                throw;
            }
        }
    }
}
