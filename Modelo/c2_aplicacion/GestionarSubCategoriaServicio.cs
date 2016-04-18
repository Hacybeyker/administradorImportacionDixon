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
    public class GestionarSubCategoriaServicio
    {
        GestorODBC gestorODBC;
        ISubCategoriaDAO subCategoriaDAO;

        public GestionarSubCategoriaServicio()
        {
            gestorODBC = new ConexionSqlServer();
            subCategoriaDAO = new SubCategoriaDAOSqlServer(gestorODBC);
        }

        public SubCategoria buscarProductosPorSubCategoria(int codigoSubCategoria)
        {
            try
            {
                gestorODBC.abrirConexion();
                SubCategoria subCategoria;
                subCategoria = subCategoriaDAO.buscarProductosPorSubCategoria(codigoSubCategoria);
                gestorODBC.cerrarConexion();
                return subCategoria;
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }
        }

        public SubCategoria buscarSubCategoria(int codigoSubCategoria)
        {
            try
            {
                gestorODBC.abrirConexion();
                SubCategoria subCategoria;
                subCategoria = subCategoriaDAO.buscarSubCategoria(codigoSubCategoria);
                gestorODBC.cerrarConexion();
                return subCategoria;
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }

        }

        public List<SubCategoria> buscarSubCategorias(Categoria categoria)
        {
            try
            {
                gestorODBC.abrirConexion();
                List<SubCategoria> listaSubCategorias;
                listaSubCategorias = subCategoriaDAO.buscarSubCategorias(categoria);
                gestorODBC.cerrarConexion();
                return listaSubCategorias;
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }

        }

        public void crearSubCategoria(SubCategoria subCategoria, int codigoCategoria)
        {
            try
            {
                gestorODBC.abrirConexion();
                subCategoriaDAO.crearSubCategoria(subCategoria, codigoCategoria);
                gestorODBC.cerrarConexion();
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }
        }

        public void editarSubCategoria(SubCategoria subCategoria)
        {
            try
            {
                gestorODBC.abrirConexion();
                subCategoriaDAO.editarSubCategoria(subCategoria);
                gestorODBC.cerrarConexion();
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }
        }

        public void eliminarSubCategoria(SubCategoria subCategoria)
        {
            try
            {
                gestorODBC.abrirConexion();
                subCategoriaDAO.eliminarSubCategoria(subCategoria);
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
                List<Categoria> categorias = new List<Categoria>();
                gestorODBC.abrirConexion();
                categorias = subCategoriaDAO.listarCategorias();
                gestorODBC.cerrarConexion();
                return categorias;
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }
        }
    }
}
