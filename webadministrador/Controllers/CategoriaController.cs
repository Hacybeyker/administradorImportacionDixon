using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelo.c2_aplicacion;
using Modelo.c3_dominio.entidad;
using Modelo.c3_dominio.entidad.servicios;

namespace webadministrador.Controllers
{
    public class CategoriaController : Controller
    {
        GestionarCategoriaServicio gestionarCategoriaServicio = new GestionarCategoriaServicio();
        GestionarContactoServicio gestionarContactoServicio = new GestionarContactoServicio();
        // GET: Categoria
        public ActionResult Index()
        {
            try
            {
                if (Session["LogedUserFullname"] != null)
                {
                    ContactoServicio contactoServicio = new ContactoServicio(gestionarContactoServicio.listaContactos(),
                    gestionarCategoriaServicio.listarCategorias());
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
                ContactoServicio contactoservicio = new ContactoServicio(gestionarContactoServicio.listaContactos(), gestionarCategoriaServicio.listarCategorias());
                return View(contactoservicio);
            }
            catch (Exception)
            {
                return View("Error");
            }

        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "nombrecategoria")] Categoria categoria)
        {
            try
            {
                gestionarCategoriaServicio.crearCategoria(categoria);
                ContactoServicio contactoServicio = new ContactoServicio(gestionarContactoServicio.listaContactos(),
                gestionarCategoriaServicio.listarCategorias());
                contactoServicio.mensajecorrecto = "Familia de Categoria creada correctamente.";
                return View("Index", contactoServicio);
            }
            catch (Exception e)
            {
                ContactoServicio contactoservicio = new ContactoServicio(gestionarContactoServicio.listaContactos(), gestionarCategoriaServicio.listarCategorias());
                contactoservicio.mensajeError = e.Message;
                return View(contactoservicio);
            }

        }

        public ActionResult Eliminar(int codigo)
        {
            Categoria categoria = null;
            try
            {
                categoria = gestionarCategoriaServicio.buscarCategoria(codigo);
                gestionarCategoriaServicio.eliminarCategoria(categoria);
                ContactoServicio contactoServicio = new ContactoServicio(gestionarContactoServicio.listaContactos(),
                gestionarCategoriaServicio.listarCategorias());
                contactoServicio.mensajecorrecto = "La Familia " + categoria.nombrecategoria + " ha sido eliminada correctamente.";
                return View("Index", contactoServicio);
            }
            catch (Exception)
            {
                ContactoServicio contactoServicio = new ContactoServicio(gestionarContactoServicio.listaContactos(),
                gestionarCategoriaServicio.listarCategorias());
                contactoServicio.mensajeError = "No se puede eliminar la Familia " + categoria.nombrecategoria + " debido a que tiene Sub Familias.";
                return View("Index", contactoServicio);
            }

        }
        public ActionResult Editar(int codigo)
        {
            try
            {
                ContactoServicio contactoservicio = new ContactoServicio(gestionarContactoServicio.listaContactos(),
                gestionarCategoriaServicio.buscarCategoria(codigo), gestionarCategoriaServicio.listarCategorias());
                return View(contactoservicio);
            }
            catch (Exception e)
            {
                ContactoServicio contactoServicio = new ContactoServicio(gestionarContactoServicio.listaContactos(),
                gestionarCategoriaServicio.listarCategorias());
                contactoServicio.mensajeError = e.Message;
                return View("Error", contactoServicio);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "codigocategoria, nombrecategoria")] Categoria categoria)
        {
            try
            {
                gestionarCategoriaServicio.editarCategoria(categoria);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ContactoServicio contactoservicio = new ContactoServicio(gestionarContactoServicio.listaContactos(), gestionarCategoriaServicio.listarCategorias());
                return RedirectToAction("Editar", new { codigo = categoria.codigocategoria });
            }
        }

    }
   
}