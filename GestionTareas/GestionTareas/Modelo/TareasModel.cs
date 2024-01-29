using System;
using System.Collections.Generic;
using System.Text;

namespace GestionTareas.Modelo
{
    public class TareasModel
    {
        public string Nombre {  get; set; }
        public string Descripcion { get; set; }
        public string Status { get; set; }
        public Guid IdTareas { get; set; }

    }
}
