using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.c3_dominio.entidad.servicios
{
    public class ContactoServicio
    {
        public ContactoServicio()
        {
            this.listaContacto = new List<Contacto>();
            this.listacategoria = new List<Categoria>();
        }
        public ContactoServicio(List<Contacto> listacontactos,Categoria _categoria,
            List<Categoria> listaCategorias)
        {
            this.listaContacto = listacontactos;
            this.listacategoria = listaCategorias;
            this.categoria = _categoria;
            this.subCategoria = new SubCategoria();
            this.subCategoria.codigocategoria = _categoria.codigocategoria;
        }
        public ContactoServicio(List<Contacto> listacontactos, SubCategoria _subcategoria,
          List<Categoria> listaCategorias)
        {
            this.listaContacto = listacontactos;
            this.listacategoria = listaCategorias;
            this.subCategoria = _subcategoria;
            this.lineasubcategoria = new LineaSubCategoria();
            this.lineasubcategoria.codigosubcategoria = _subcategoria.codigosubcategoria;
        }
        public ContactoServicio(List<Contacto> listacontactos, LineaSubCategoria _lineaSubcategoria,
         List<Categoria> listaCategorias)
        {
            this.listaContacto = listacontactos;
            this.listacategoria = listaCategorias;
            this.lineasubcategoria = _lineaSubcategoria;
            this.producto = new Producto();
            this.producto.codigolineasubcategoria = _lineaSubcategoria.codigolinea;
        }
        public ContactoServicio(List<Contacto> listacontactos, Producto _producto,
        List<Categoria> listaCategorias)
        {
            this.listaContacto = listacontactos;
            this.listacategoria = listaCategorias;
            this.producto = _producto;
            this.imagenProducto = new ImagenProducto();
            this.imagenProducto.codigoproducto = _producto.codigoProducto;
        }
        public ContactoServicio(List<Contacto> listacontactos, ImagenProducto _imagenProducto,
        List<Categoria> listaCategorias)
        {
            this.listaContacto = listacontactos;
            this.listacategoria = listaCategorias;
            this.imagenProducto = _imagenProducto;
        }


        public ContactoServicio(List<Contacto> listacontactos,Contacto _contacto,
            List<Categoria> listaCategorias)
        {
            this.listacategoria = listaCategorias;
            this.listaContacto = listacontactos;
            this.contacto = _contacto;
        }
     
        public ContactoServicio(List<Contacto> listacontactos, List<Categoria> listaCategorias, List<SubCategoria> listaSubCategorias, Categoria _categoria) {
            this.listaContacto = listacontactos;
            this.listacategoria = listaCategorias;
            this.listaSubCategoria = listaSubCategorias;
            this.categoria = _categoria;
        }
     
        public ContactoServicio(List<Contacto> listacontactos, List<Categoria> listaCategorias, List<LineaSubCategoria> listaLineaSubCategorias, SubCategoria _subcategoria)
        {
            this.listaContacto = listacontactos;
            this.listacategoria = listaCategorias;
            this.listaLineaSubCategoria = listaLineaSubCategorias;
            this.subCategoria = _subcategoria;
        }
        public ContactoServicio(List<Contacto> listacontactos, List<Categoria> listaCategorias, List<Producto> listaProductos, LineaSubCategoria _lineasubcategoria)
        {
            this.listaContacto = listacontactos;
            this.listacategoria = listaCategorias;
            this.listaProducto = listaProductos;
            this.lineasubcategoria = _lineasubcategoria;
        }
        public ContactoServicio(List<Contacto> listacontactos, List<Categoria> listaCategorias, List<ImagenProducto> listaImagenProductos, Producto _producto)
        {
            this.listaContacto = listacontactos;
            this.listacategoria = listaCategorias;
            this.listaImaagenProducto = listaImagenProductos;
            this.producto = _producto;
        }
        public ContactoServicio(List<Contacto> listaContactos, List<Categoria> listaCategoria, List<Usuario> listaUsuarios)
        {
            this.listaContacto = listaContactos;
            this.listacategoria = listaCategoria;
            this.listaUsuarios = listaUsuarios;
        }
        public ContactoServicio(List<Contacto> listacontactos, List<Categoria> listaCategorias)
        {
            this.listaContacto = listacontactos;
            this.listacategoria = listaCategorias;
        }
        public List<Categoria> listacategoria { get; set; }
        public List<SubCategoria> listaSubCategoria { get; set; }
        public List<LineaSubCategoria> listaLineaSubCategoria { get; set; }
        public List<Producto> listaProducto { get; set; }
        public List<ImagenProducto> listaImaagenProducto { get; set; }
        public List<Contacto> listaContacto { get; set; }
        public Contacto contacto { get; set; }
        public Categoria categoria { get; set; }
        public SubCategoria subCategoria { get; set; }
        public LineaSubCategoria lineasubcategoria { get; set; }
        public Producto producto { get; set; }
        public ImagenProducto imagenProducto { get; set; }
        public Usuario usuario { get; set; }
        public List<Usuario> listaUsuarios { get; set; }
        public string mensajeError { get; set; }
        public string mensajecorrecto{ get; set; }
        public int cantidadMensajeContacto()
        {
            int contador = 0;
            foreach(var contacto in listaContacto)
                {
                    if (!contacto.visto)
                        contador++;
                }
            return contador;
        }

        public int cantidadMensaje()
        {
            return listaContacto.Count();
        }

        public int cantidadCategoria()
        {
            return listacategoria.Count();
        }

        public bool existeImgPrincipal() {
            bool _siExiste = false;
            foreach (var img in listaImaagenProducto) {
                if (img.principal) {
                    _siExiste = true;
                    break;
                }
            }
            return _siExiste;
        }
        public string nombrecompletocontacto() {
            return contacto.apellidoContacto + ", " + contacto.nombreContacto;
        }
    }
}
