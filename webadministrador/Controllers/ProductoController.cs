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
    public class ProductoController : Controller
    {
        GestionarCategoriaServicio gestionarCategoriaServicio = new GestionarCategoriaServicio();
        GestionarContactoServicio gestionarContactoServicio = new GestionarContactoServicio();
        GestionarSubCategoriaServicio gestionarSubCategoriaServicio = new GestionarSubCategoriaServicio();
        GestionarLineaSubCategoriaServicio gestionarLineaSubCategoriaservicio = new GestionarLineaSubCategoriaServicio();
        GestionarProductoServicio gestionarProductoServicio = new GestionarProductoServicio();
        // GET: Producto
        public ActionResult Index(int codigolinea)
        {
            try
            {
                if (Session["LogedUserFullname"] != null)
                {
                    LineaSubCategoria lineaSubcategoria = gestionarLineaSubCategoriaservicio.buscarLineaSubCategoria(codigolinea);
                    ContactoServicio contactoCategoria = new ContactoServicio(gestionarContactoServicio.listaContactos(),
                    gestionarCategoriaServicio.listarCategorias(), gestionarProductoServicio.buscarProductos(lineaSubcategoria), lineaSubcategoria);
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
            Producto producto = gestionarProductoServicio.buscarProducto(codigo);
            try
            {
                gestionarProductoServicio.eliminarProducto(producto);
                return RedirectToAction("Index", new { codigolinea = producto.codigolineasubcategoria});
            }
            catch (Exception)
            {
                return RedirectToAction("Index", new { codigolinea = producto.codigolineasubcategoria});
            }
        }
        [AllowAnonymous]
        public ActionResult Crear(int codigolineasubcategoria)
        {
            ContactoServicio contactoservicio = new ContactoServicio(gestionarContactoServicio.listaContactos(),
            gestionarLineaSubCategoriaservicio.buscarLineaSubCategoria(codigolineasubcategoria), gestionarCategoriaServicio.listarCategorias());
            return View(contactoservicio);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "codigolineasubcategoria, nombreProducto, precioProducto, descripcionProducto, detalleProducto")]Producto producto)
        {
            try
            {
                gestionarProductoServicio.crearProducto(producto, producto.codigolineasubcategoria);
                return RedirectToAction("Index", new { codigolinea = producto.codigolineasubcategoria });
            }
            catch (Exception)
            {
                return RedirectToAction("Crear", new { codigolineasubcategoria = producto.codigolineasubcategoria });
            }
        }

        public ActionResult Editar(int codigo)
        {
            ContactoServicio contactoservicio = new ContactoServicio(gestionarContactoServicio.listaContactos(),
            gestionarProductoServicio.buscarProducto(codigo), gestionarCategoriaServicio.listarCategorias());
            return View(contactoservicio);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "codigoProducto, codigolineasubcategoria, nombreProducto, precioProducto, descripcionProducto, detalleProducto")] Producto producto)
        {
            try
            {
                gestionarProductoServicio.modificarProducto(producto);
                return RedirectToAction("Index", new { codigolinea = producto.codigolineasubcategoria });

            }
            catch (Exception)
            {
                ContactoServicio contactoservicio = new ContactoServicio(gestionarContactoServicio.listaContactos(), gestionarCategoriaServicio.listarCategorias());
                return RedirectToAction("Editar", new { codigo = producto.codigoProducto});
            }

        }
    }
}