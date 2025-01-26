using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Servicios
{
    public class DataService
    {
        private readonly BdInfraccionesContext _context;

        public DataService(BdInfraccionesContext context)
        {
            _context = context;
        }

        public async Task<List<EstadoCamara>> ObtenerEstadoCamarasAsync(CancellationToken stoppingToken)
        {
            return await _context.EstadoCamaras.ToListAsync(stoppingToken);
        }
    }
}
