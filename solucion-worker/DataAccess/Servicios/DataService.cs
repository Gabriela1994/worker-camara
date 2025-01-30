using DataAccess.Models;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Servicios
{
    public class DataService
    {
        private readonly BdInfraccionesContext _context;

        public DataService(BdInfraccionesContext context)
        {
            _context = context;
        }

        public async Task<List<Camara>> ObtenerCamarasAsync(CancellationToken stoppingToken)
        {
            return await _context.Camaras.ToListAsync(stoppingToken);
        }
    }
}
