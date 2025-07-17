using SmileArtLab.Auth.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileArtLab.Auth.Application.Services
{
    public class TenantService : ITenantService
    {
        public Guid TenantId { get; set; }
    }
}
