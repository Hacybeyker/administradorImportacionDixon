using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.c3_dominio.entidad;

namespace Modelo.c3_dominio.contrato
{
    public interface IContactoDAO
    {
        void crearContacto(Contacto contacto);
        void agregarVisto(Contacto contacto);
        Contacto buscarContacto(int codigoContacto);
        List<Contacto> listaContactos();
        List<Contacto> listaContactoNoVisto();
        int cantidadContactosNoVistos();
    }
}
