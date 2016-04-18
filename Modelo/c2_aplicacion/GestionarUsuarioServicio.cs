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
    public class GestionarUsuarioServicio
    {
        GestorODBC gestorODBC;
        IUsuarioDAO ususuarioDAO;

        public GestionarUsuarioServicio()
        {
            gestorODBC = new ConexionSqlServer();
            ususuarioDAO = new UsuarioDAOSqlServer(gestorODBC);
        }

        public Usuario buscarUsuario(string cuentaUsuario, string claveUsuario)
        {
            try
            {
                gestorODBC.abrirConexion();
                Usuario usuario;
                usuario = ususuarioDAO.buscarUsuario(cuentaUsuario, claveUsuario);
                gestorODBC.cerrarConexion();
                return usuario;
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }
        }

        public void crearUsuario(Usuario usuario)
        {
            try
            {
                gestorODBC.abrirConexion();
                ususuarioDAO.crearUsuario(usuario);
                gestorODBC.cerrarConexion();
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }
        }
        public Usuario buscarUsuario(int codigoUsuario)
        {
            try
            {
                gestorODBC.abrirConexion();
                Usuario usuario = null;
                usuario = ususuarioDAO.buscarUsuario(codigoUsuario);
                gestorODBC.cerrarConexion();
                return usuario;
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }
        }
        public void eliminar(Usuario usuario)
        {
            try
            {
                gestorODBC.abrirConexion();
                ususuarioDAO.eliminar(usuario);
                gestorODBC.cerrarConexion();
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }
        }

        public List<Usuario> listaUsuarios()
        {
            try
            {
                gestorODBC.abrirConexion();
                List<Usuario> listaUsuarios;
                listaUsuarios = ususuarioDAO.listaUsuarios();
                gestorODBC.cerrarConexion();
                return listaUsuarios;
            }
            catch (Exception e)
            {
                gestorODBC.cerrarConexion();
                throw e;
            }
        }

    }
}
