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
    public class SubCategoriaController : Controller
    {
        GestionarCategoriaServicio gestionarCategoriaServicio = new GestionarCategoriaServicio();
        GestionarContactoServicio gestionarContactoServicio = new GestionarContactoServicio();
        GestionarSubCategoriaServicio gestionarSubCategoriaServicio = new GestionarSubCategoriaServicio();
        // GET: SubCategoria
        public ActionResult Index(int codigocategoria)
        {
            try
            {
                if (Session["LogedUserFullname"] != null)
                {
                    Categoria categoria = gestionarCategoriaServicio.buscarCategoria(codigocategoria);
                    ContactoServicio contactoCategoria = new ContactoServicio(gestionarContactoServicio.listaContactos(),
                    gestionarCategoriaServicio.listarCategorias(), gestionarSubCategoriaServicio.buscarSubCategorias(categoria), categoria);
                    return View(contactoCategoria);
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
        public ActionResult Crear(int codigocategoria)
        {
            ContactoServicio contactoservicio = new ContactoServicio(gestionarContactoServicio.listaContactos(),
            gestionarCategoriaServicio.buscarCategoria(codigocategoria), gestionarCategoriaServicio.listarCategorias());
            return View(contactoservicio);
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "codigocategoria, nombresubcategoria")]SubCategoria subcategoria)
        {
            if (subcategoria.nombresubcategoria != null)
            {
                gestionarSubCategoriaServicio.crearSubCategoria(subcategoria,subcategoria.codigocategoria);
                return RedirectToAction("Index", new { codigocategoria =subcategoria.codigocategoria });
            }
            else
                return RedirectToAction("Crear", new { codigocategoria = subcategoria.codigocategoria });
        }

        public ActionResult Eliminar(int codigo)
        {
            SubCategoria subCategoria=gestionarSubCategoriaServicio.buscarSubCategoria(codigo);
            try
            {
                gestionarSubCategoriaServicio.eliminarSubCategoria(subCategoria);
                return RedirectToAction("Index", new { codigocategoria = subCategoria.codigocategoria });
            }
            catch (Exception)
            {
                return RedirectToAction("Index", new { codigocategoria = subCategoria.codigocategoria });
            }
        }

        public ActionResult Editar(int codigo)
        {
            ContactoServicio contactoservicio = new ContactoServicio(gestionarContactoServicio.listaContactos(),
            gestionarSubCategoriaServicio.buscarSubCategoria(codigo), gestionarCategoriaServicio.listarCategorias());
            return View(contactoservicio);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "codigocategoria,codigosubcategoria,nombresubcategoria")] SubCategoria subcategoria)
        {
            try
            {
                gestionarSubCategoriaServicio.editarSubCategoria(subcategoria);
                return RedirectToAction("Index", new { codigocategoria = subcategoria.codigocategoria });
            }
            catch (Exception)
            {

                ContactoServicio contactoservicio = new ContactoServicio(gestionarContactoServicio.listaContactos(), gestionarCategoriaServicio.listarCategorias());
                return RedirectToAction("Editar", new { codigo = subcategoria.codigosubcategoria });
            }
        }

    }
}