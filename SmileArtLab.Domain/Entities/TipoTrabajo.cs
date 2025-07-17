using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileArtLab.Domain.Entities
{
    public class TipoTrabajo
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public TipoTrabajo()
        {
            Nombre = String.Empty;
        }
    }
}
