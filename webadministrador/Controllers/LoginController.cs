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
    public class LoginController : Controller
    {
        GestionarUsuarioServicio gestionarUsuarioServicio = new GestionarUsuarioServicio();
        public ActionResult Index()
        {
            if (Session["LogedUserFullname"] != null)
            {
                Session.Remove("LogedUserID");
                Session.Remove("LogedUserFullname");
                Session["LogedUserID"] = null;
                Session["LogedUserFullname"] = null;
                return View("Index");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Acceder([Bind(Include = "cuentaUsuario,claveUsuario")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                Usuario user = gestionarUsuarioServicio.buscarUsuario(usuario.cuentaUsuario, usuario.claveUsuario);
                if (user != null)
                {
                    Session["LogedUserID"] = user.codigoUsuario.ToString();
                    Session["LogedUserFullname"] = user.nombreUsuario.ToString();

                    Session["PermisoMensaje"] = user.mensajeusuario.ToString();
                    Session["PermisoUsuario"] = user.usuariousuario.ToString();
                    Session["PermisoCategoria"] = user.categoriausuario.ToString();

                    string ver1 = user.mensajeusuario.ToString();
                    string ver2 = Session["PermisoMensaje"].ToString();

                    string ver3 = user.usuariousuario.ToString();
                    string ver4 = Session["PermisoUsuario"].ToString();

                    string ver5 = user.categoriausuario.ToString();
                    string ver6 = Session["PermisoCategoria"].ToString();

                    string a = "Hola muindito";

                    return RedirectToAction("Index", "Home");
                }
            }
            return View("Index");
        }
    }
}