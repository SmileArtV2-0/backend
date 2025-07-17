using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileArtLab.Auth.Application.Interfaces
{
    public interface ITenantService
    {
        Guid TenantId { get; set; }
    }
}
