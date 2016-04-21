using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.c3_dominio.contrato;
using Modelo.c3_dominio.entidad.servicios;
using Modelo.c3_dominio.entidad;
using Modelo.c4_persistencia.sqlserver;
using Modelo.c4_persistencia;

namespace Modelo.c2_aplicacion
{
    public class GestionarContactoServicio
    {
        GestorODBC gestorODBC;
        IContactoDAO contactoDAO;
        public GestionarContactoServicio()
        {
            gestorODBC = new ConexionSqlServer();
            contactoDAO = new ContactoDAOSqlServer(gestorODBC);
        }
       
        public void crearContacto(Contacto contacto)
        {
            try
            {
                gestorODBC.abrirConexion();
                contactoDAO.crearContacto(contacto);
                gestorODBC.cerrarConexion();
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }
        }

        public List<Contacto> listaContactos()
        {
            try
            {

                gestorODBC.abrirConexion();
                List<Contacto> listaContactos;
                listaContactos = contactoDAO.listaContactos();
                gestorODBC.cerrarConexion();
                return listaContactos;
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }
        }

        public Contacto buscarContacto(int codigoContacto)
        {
            try
            {

                gestorODBC.abrirConexion();
                Contacto contacto;
                contacto = contactoDAO.buscarContacto(codigoContacto);
                gestorODBC.cerrarConexion();
                return contacto;
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }

        }

        public void eliminarContacto(int codigoContacto)
        {
            try
            {
                gestorODBC.abrirConexion();
                contactoDAO.eliminarContacto(codigoContacto);
                gestorODBC.cerrarConexion();
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }
        }

        public void agregarVisto(Contacto contacto)
        {
            try
            {
                gestorODBC.abrirConexion();
                contactoDAO.agregarVisto(contacto);
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
