using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.c3_dominio.entidad
{
    public class Contacto
    {
        public Contacto(int codigo) {
            this.codigoContacto = codigo;
        }
        public int codigoContacto { get; set; }
        public string nombreContacto { get; set; }
        public string apellidoContacto { get; set; }
        public string telefonoContacto { get; set; }
        public string correoContacto { get; set; }
        public string empresaContacto { get; set; }
        public string comentarioContacto { get; set; }
        public bool visto { get; set; }
        public Contacto()
        {
            this.codigoContacto = 0;
            this.visto = false;
        }
    }
}
