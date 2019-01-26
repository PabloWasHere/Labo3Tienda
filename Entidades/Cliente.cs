using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente : Estado
    {
        private Usuario propietario;
        private bool esOrganizacion;
        private string nombreOrganizacion;
        private char genero;
        private string primerNombre;
        private string segundoNombre;
        private string apellido;
        private string correoElectronico;
        private string numeroTelefono;
        private string direccion;
        private string puebloCiudad;
        private string pais;

        public Cliente() { }

        public Cliente(Usuario propietario, bool esOrganizacion, string nombreOrganizacion, char genero, string primerNombre, string segundoNombre, string apellido, string correoElectronico, string numeroTelefono, string direccion, string puebloCiudad, string pais)
        {
            this.propietario = propietario;
            this.esOrganizacion = esOrganizacion;
            this.nombreOrganizacion = nombreOrganizacion;
            this.genero = genero;
            this.primerNombre = primerNombre;
            this.segundoNombre = segundoNombre;
            this.apellido = apellido;
            this.correoElectronico = correoElectronico;
            this.numeroTelefono = numeroTelefono;
            this.direccion = direccion;
            this.puebloCiudad = puebloCiudad;
            this.pais = pais;
        }

        public Usuario Propietario { get => propietario; set => propietario = value; }
        public bool EsOrganizacion { get => esOrganizacion; set => esOrganizacion = value; }
        public string NombreOrganizacion { get => nombreOrganizacion; set => nombreOrganizacion = value; }
        public char Genero { get => genero; set => genero = value; }
        public string PrimerNombre { get => primerNombre; set => primerNombre = value; }
        public string SegundoNombre { get => segundoNombre; set => segundoNombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string CorreoElectronico { get => correoElectronico; set => correoElectronico = value; }
        public string NumeroTelefono { get => numeroTelefono; set => numeroTelefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string PuebloCiudad { get => puebloCiudad; set => puebloCiudad = value; }
        public string Pais { get => pais; set => pais = value; }
    }
}
