using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileArtLab.Domain.Entities
{
    public class Trabajo
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public Guid? Id_TipoTrabajo { get; set; }
        public bool Activo { get; set; }

        public Trabajo()
        {
            Nombre = String.Empty;
        }
    }
}
