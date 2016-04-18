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
    public class ProductoImagenController : Controller
    {
        GestionarCategoriaServicio gestionarCategoriaServicio = new GestionarCategoriaServicio();
        GestionarContactoServicio gestionarContactoServicio = new GestionarContactoServicio();
        GestionarProductoServicio gestionarProductoServicio = new GestionarProductoServicio();
        GestionarimagenProductoServicio gestionarImagenServicio = new GestionarimagenProductoServicio();
        // GET: ProductoImagen
        public ActionResult Index(int codigo)
        {
            try
            {
                if (Session["LogedUserFullname"] != null)
                {
                    Producto producto = gestionarProductoServicio.buscarProducto(codigo);
                    ContactoServicio contactoCategoria = new ContactoServicio(gestionarContactoServicio.listaContactos(),
                    gestionarCategoriaServicio.listarCategorias(), gestionarImagenServicio.listarImagenesPorProducto(producto), producto);
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
        public ActionResult Eliminar(int codigo)
        {
            ImagenProducto imagenproducto = gestionarImagenServicio.buscarImagenProducto(codigo);
            try
            {
                gestionarImagenServicio.eliminarimagenProducto(imagenproducto);
                return RedirectToAction("Index", new { codigo = imagenproducto.codigoproducto });
            }
            catch (Exception)
            {
                return RedirectToAction("Index", new { codigo = imagenproducto.codigoproducto });
            }
        }
        [AllowAnonymous]
        public ActionResult CrearPrincipal(int codigo)
        {
            ContactoServicio contactoservicio = new ContactoServicio(gestionarContactoServicio.listaContactos(),
            gestionarProductoServicio.buscarProducto(codigo), gestionarCategoriaServicio.listarCategorias());
            return View(contactoservicio);
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult CrearPrincipal([Bind(Include = "codigoproducto, nombreimagen, urlimagen")]ImagenProducto imagenProducto)
        {
            try
            {
                imagenProducto.principal = true;
                gestionarImagenServicio.crearimagenProducto(imagenProducto, imagenProducto.codigoproducto);
                return RedirectToAction("Index", new { codigo = imagenProducto.codigoproducto });
            }
            catch (Exception)
            {
                return RedirectToAction("Crear", new { codigo = imagenProducto.codigoproducto });
            }
        }

        [AllowAnonymous]
        public ActionResult Crear(int codigo)
        {
            ContactoServicio contactoservicio = new ContactoServicio(gestionarContactoServicio.listaContactos(),
            gestionarProductoServicio.buscarProducto(codigo), gestionarCategoriaServicio.listarCategorias());
            return View(contactoservicio);
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "codigoproducto, nombreimagen, urlimagen")]ImagenProducto imagenProducto)
        {
            try
            {
                gestionarImagenServicio.crearimagenProducto(imagenProducto, imagenProducto.codigoproducto);
                return RedirectToAction("Index", new { codigo = imagenProducto.codigoproducto });
            }
            catch (Exception)
            {
                return RedirectToAction("Crear", new { codigo = imagenProducto.codigoproducto });
            }
        }

        private ContactoServicio crearCotnactoServicio(int codigo)
        {
            ContactoServicio contactoservicio = new ContactoServicio(gestionarContactoServicio.listaContactos(),
            gestionarImagenServicio.buscarImagenProducto(codigo), gestionarCategoriaServicio.listarCategorias());
            return contactoservicio;
        }

        public ActionResult EditarPrincipal(int codigo)
        {
            ContactoServicio contactoservicio = crearCotnactoServicio(codigo);
            return View(contactoservicio);
        }
        public ActionResult Editar(int codigo)
        {
            ContactoServicio contactoservicio = crearCotnactoServicio(codigo);
            return View(contactoservicio);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "codigoimagen, codigoproducto, nombreimagen, urlimagen")] ImagenProducto imagenProducto)
        {
            try
            {
                gestionarImagenServicio.modificarimagenProducto(imagenProducto);
                return RedirectToAction("Index", new { codigo = imagenProducto.codigoproducto });

            }
            catch (Exception)
            {
                ContactoServicio contactoservicio = new ContactoServicio(gestionarContactoServicio.listaContactos(), gestionarCategoriaServicio.listarCategorias());
                return RedirectToAction("Editar", new { codigo = imagenProducto.codigoproducto });
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarPrincipal([Bind(Include = "codigoimagen, codigoproducto, nombreimagen, urlimagen")] ImagenProducto imagenProducto)
        {
            try
            {
                imagenProducto.principal = true;
                gestionarImagenServicio.modificarimagenProducto(imagenProducto);
                return RedirectToAction("Index", new { codigo = imagenProducto.codigoproducto });

            }
            catch (Exception)
            {
                ContactoServicio contactoservicio = new ContactoServicio(gestionarContactoServicio.listaContactos(), gestionarCategoriaServicio.listarCategorias());
                return RedirectToAction("Editar", new { codigo = imagenProducto.codigoproducto });
            }

        }
    }
}