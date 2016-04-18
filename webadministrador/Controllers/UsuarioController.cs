using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelo.c2_aplicacion;
using Modelo.c3_dominio.entidad.servicios;
using Modelo.c3_dominio.entidad;

namespace webadministrador.Controllers
{
    public class UsuarioController : Controller
    {
        GestionarContactoServicio gestionarContactoServicio = new GestionarContactoServicio();
        GestionarCategoriaServicio gestionarCategoriaServicio = new GestionarCategoriaServicio();
        // GET: Usuario
        public ActionResult Index()
        {
            try
            {
                if (Session["LogedUserFullname"] != null)
                {
                    GestionarUsuarioServicio gestionarUsuarioServicio = new GestionarUsuarioServicio();
                    List<Usuario> listaUsuarios = new List<Usuario>();
                    List<Contacto> listaContactos = new List<Contacto>();
                    List<Categoria> listaCategoria = new List<Categoria>();
                    listaUsuarios = gestionarUsuarioServicio.listaUsuarios();
                    listaContactos = gestionarContactoServicio.listaContactos();
                    listaCategoria = gestionarCategoriaServicio.listarCategorias();
                    ContactoServicio contactoServicio = new ContactoServicio(listaContactos, listaCategoria, listaUsuarios);
                    return View(contactoServicio);
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }

            }
            catch (Exception e)
            {
                ContactoServicio contactoServicio = new ContactoServicio();
                contactoServicio.mensajeError = e.Message;
                return View("Error", contactoServicio);
            }
        }
        [AllowAnonymous]
        public ActionResult Crear()
        {
            try
            {
                ContactoServicio contactoServicio = new ContactoServicio(gestionarContactoServicio.listaContactos(), gestionarCategoriaServicio.listarCategorias());
                return View(contactoServicio);
            }
            catch (Exception e)
            {
                ContactoServicio contactoServicio = new ContactoServicio();
                contactoServicio.mensajeError = e.Message;
                return View("Error", contactoServicio);
            }
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "nombreUsuario, cuentaUsuario, claveUsuario,mensajeusuario,usuariousuario,categoriausuario")] Usuario usuario)
        {
            try
            {
                if (Session["LogedUserFullname"] != null)
                {
                    GestionarUsuarioServicio gestionarUsurioServicio = new GestionarUsuarioServicio();
                    gestionarUsurioServicio.crearUsuario(usuario);
                    ContactoServicio contactoServicio = new ContactoServicio(gestionarContactoServicio.listaContactos(), gestionarCategoriaServicio.listarCategorias(),
                    gestionarUsurioServicio.listaUsuarios());
                    contactoServicio.mensajecorrecto = "Usuario Creado correctamente";
                    return View("Index", contactoServicio);
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            catch (Exception e)
            {
                GestionarUsuarioServicio gestionarUsurioServicio = new GestionarUsuarioServicio();
                ContactoServicio contactoservicio = new ContactoServicio(gestionarContactoServicio.listaContactos(), gestionarCategoriaServicio.listarCategorias(), gestionarUsurioServicio.listaUsuarios());
                contactoservicio.mensajeError = e.Message;
                return View(contactoservicio);
            }
        }
        public ActionResult Eliminar(int codigoUsuario)
        {
            Usuario usuario = null;
            try
            {
                GestionarUsuarioServicio gestionarUsurioServicio = new GestionarUsuarioServicio();
                usuario = gestionarUsurioServicio.buscarUsuario(codigoUsuario);
                gestionarUsurioServicio.eliminar(usuario);
                ContactoServicio contactoServicio = new ContactoServicio(gestionarContactoServicio.listaContactos(),
                gestionarCategoriaServicio.listarCategorias(), gestionarUsurioServicio.listaUsuarios());
                contactoServicio.mensajecorrecto = "El Usuario " + usuario.nombreUsuario + " ha sido eliminada correctamente.";
                return View("Index", contactoServicio);
            }
            catch (Exception)
            {
                GestionarUsuarioServicio gestionarUsurioServicio = new GestionarUsuarioServicio();
                ContactoServicio contactoServicio = new ContactoServicio(gestionarContactoServicio.listaContactos(),
                gestionarCategoriaServicio.listarCategorias(), gestionarUsurioServicio.listaUsuarios());
                contactoServicio.mensajeError = "No se puede eliminar el Usuario " + usuario.nombreUsuario;
                return View("Index", contactoServicio);
            }

        }
    }
}