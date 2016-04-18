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
    public class LineaSubCategoriaController : Controller
    {
        GestionarCategoriaServicio gestionarCategoriaServicio = new GestionarCategoriaServicio();
        GestionarContactoServicio gestionarContactoServicio = new GestionarContactoServicio();
        GestionarSubCategoriaServicio gestionarSubCategoriaServicio = new GestionarSubCategoriaServicio();
        GestionarLineaSubCategoriaServicio gestionarLineaSubCategoriaservicio = new GestionarLineaSubCategoriaServicio();
        // GET: LineaSubCategoria
        public ActionResult Index(int codigosubcategoria)
        {
            try
            {
                if (Session["LogedUserFullname"] != null)
                {
                    SubCategoria subcategoria = gestionarSubCategoriaServicio.buscarSubCategoria(codigosubcategoria);
                    ContactoServicio contactoCategoria = new ContactoServicio(gestionarContactoServicio.listaContactos(),
                    gestionarCategoriaServicio.listarCategorias(), gestionarLineaSubCategoriaservicio.buscarLineaSubCategorias(subcategoria), subcategoria);
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
        public ActionResult Crear(int codigosubcategoria)
        {
            ContactoServicio contactoservicio = new ContactoServicio(gestionarContactoServicio.listaContactos(),
            gestionarSubCategoriaServicio.buscarSubCategoria(codigosubcategoria), gestionarCategoriaServicio.listarCategorias());
            return View(contactoservicio);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "codigosubcategoria, nombrelinea")]LineaSubCategoria lineaSubcategoria)
        {
            if (lineaSubcategoria.nombrelinea != null)
            {
                gestionarLineaSubCategoriaservicio.crearLineaSubCategoria(lineaSubcategoria, lineaSubcategoria.codigosubcategoria);
                return RedirectToAction("Index", new { codigosubcategoria = lineaSubcategoria.codigosubcategoria });
            }
            else
                return RedirectToAction("Crear", new { codigosubcategoria = lineaSubcategoria.codigosubcategoria });
        }
        public ActionResult Eliminar(int codigo)
        {
            LineaSubCategoria lineasubCategoria = gestionarLineaSubCategoriaservicio.buscarLineaSubCategoria(codigo);
            try
            {
                gestionarLineaSubCategoriaservicio.eliminarLineaSubCategoria(lineasubCategoria);
                return RedirectToAction("Index", new { codigosubcategoria = lineasubCategoria.codigosubcategoria });
            }
            catch (Exception)
            {
                return RedirectToAction("Index", new { codigodubcategoria = lineasubCategoria.codigosubcategoria });
            }
        }
        public ActionResult Editar(int codigo)
        {
            ContactoServicio contactoservicio = new ContactoServicio(gestionarContactoServicio.listaContactos(),
            gestionarLineaSubCategoriaservicio.buscarLineaSubCategoria(codigo), gestionarCategoriaServicio.listarCategorias());
            return View(contactoservicio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "codigosubcategoria,codigolinea,nombrelinea")] LineaSubCategoria lineaSubcategoria)
        {
            try
            {
                 gestionarLineaSubCategoriaservicio.editarLineaSubCategoria(lineaSubcategoria);
                 return RedirectToAction("Index", new { codigosubcategoria = lineaSubcategoria.codigosubcategoria });
                
            }
            catch (Exception)
            {
                ContactoServicio contactoservicio = new ContactoServicio(gestionarContactoServicio.listaContactos(), gestionarCategoriaServicio.listarCategorias());
                return RedirectToAction("Editar", new { codigo = lineaSubcategoria.codigolinea });
            }
          
        }



    }
}