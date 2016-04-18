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
    public class GestionarLineaSubCategoriaServicio
    {
        GestorODBC gestoriODBC;
        ILineaSubCategoriaDAO lineaSubCategoriaDAO;

        public GestionarLineaSubCategoriaServicio()
        {
            gestoriODBC = new ConexionSqlServer();
            lineaSubCategoriaDAO = new LineaSubCategoriaDAOSqlServer(gestoriODBC);
        }
        public LineaSubCategoria buscarLineaSubCategoria(int codigoLineaSubCategoria)
        {
            try
            {
                gestoriODBC.abrirConexion();
                LineaSubCategoria lineaSubCategoria;
                lineaSubCategoria = lineaSubCategoriaDAO.buscarLineaSubCategoria(codigoLineaSubCategoria);
                gestoriODBC.cerrarConexion();
                return lineaSubCategoria;
            }
            catch (Exception e)
            {
                gestoriODBC.cerrarConexion();
                throw e;
            }
        }

        public List<LineaSubCategoria> buscarLineaSubCategorias(SubCategoria subCategoria)
        {
            try
            {
                gestoriODBC.abrirConexion();
                List<LineaSubCategoria> listaSubCategorias;
                listaSubCategorias = lineaSubCategoriaDAO.buscarLineaSubCategorias(subCategoria);
                gestoriODBC.cerrarConexion();
                return listaSubCategorias;
            }
            catch (Exception e)
            {
                gestoriODBC.cerrarConexion();
                throw e;
            }
        }

        public LineaSubCategoria buscarProductosPorLinea(int codigoLineaSubCategoria)
        {
            try
            {

                gestoriODBC.abrirConexion();
                LineaSubCategoria lineaSubCategoria;
                lineaSubCategoria = lineaSubCategoriaDAO.buscarProductosPorLinea(codigoLineaSubCategoria);
                gestoriODBC.cerrarConexion();
                return lineaSubCategoria;
            }
            catch (Exception e)
            {
                gestoriODBC.cerrarConexion();
                throw e;
            }
        }

        public void crearLineaSubCategoria(LineaSubCategoria lineaSubCategoria, int codigoSubCategoria)
        {
            try
            {
                gestoriODBC.abrirConexion();
                lineaSubCategoriaDAO.crearLineaSubCategoria(lineaSubCategoria, codigoSubCategoria);
                gestoriODBC.cerrarConexion();
            }
            catch (Exception e)
            {
                gestoriODBC.cerrarConexion();
                throw e;
            }
        }

        public void editarLineaSubCategoria(LineaSubCategoria lineaSubCategoria)
        {
            try
            {
                gestoriODBC.abrirConexion();
                lineaSubCategoriaDAO.editarLineaSubCategoria(lineaSubCategoria);
                gestoriODBC.cerrarConexion();
            }
            catch (Exception e)
            {
                gestoriODBC.cerrarConexion();
                throw e;
            }
        }

        public void eliminarLineaSubCategoria(LineaSubCategoria lineaSubCategoria)
        {
            try
            {
                gestoriODBC.abrirConexion();
                lineaSubCategoriaDAO.eliminarLineaSubCategoria(lineaSubCategoria);
                gestoriODBC.cerrarConexion();
            }
            catch (Exception e)
            {
                gestoriODBC.cerrarConexion();
                throw e;
            }
        }
    }
}
