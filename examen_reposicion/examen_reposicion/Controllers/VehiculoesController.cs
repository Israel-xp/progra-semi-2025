using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using examen_reposicion.Models;

namespace examen_reposicion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoesController : ControllerBase
    {
        private readonly VehiculoDbContext _context;

        public VehiculoesController(VehiculoDbContext context)
        {
            _context = context;
        }

        // GET: api/Vehiculoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehiculo>>> Gettbl_vehiculos()
        {
            return await _context.tbl_vehiculos.ToListAsync();
        }

        // GET: api/Vehiculoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehiculo>> GetVehiculo(int id)
        {
            var vehiculo = await _context.tbl_vehiculos.FindAsync(id);

            if (vehiculo == null)
            {
                return NotFound();
            }

            return vehiculo;
        }

        [HttpGet("buscar")]
        public async Task<ActionResult<IEnumerable<Vehiculo>>> BuscarVehiculo([FromQuery] VehiculoBusquedaParametros parametros)
        {
            var consulta = _context.tbl_vehiculos.AsQueryable();

            if (!string.IsNullOrEmpty(parametros.buscar))
            {
                consulta = consulta.Where(vehiculo => vehiculo.marca.Contains(parametros.buscar));
            }

            if (!string.IsNullOrEmpty(parametros.buscar) && consulta.Count() <= 0)
            {
                consulta = _context.tbl_vehiculos.AsQueryable();
                consulta = consulta.Where(vehiculo => vehiculo.modelo.Contains(parametros.buscar));
            }

            return await consulta.ToListAsync();
        }


        // PUT: api/Vehiculoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehiculo(int id, Vehiculo vehiculo)
        {
            if (id != vehiculo.idVehiculo)
            {
                return BadRequest();
            }

            _context.Entry(vehiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vehiculoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vehiculo>> PostVehiculo(Vehiculo vehiculo)
        {
            _context.tbl_vehiculos.Add(vehiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehiculo", new { id = vehiculo.idVehiculo }, vehiculo);
        }

        // DELETE: api/Vehiculoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehiculo(int id)
        {
            var vehiculo = await _context.tbl_vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            _context.tbl_vehiculos.Remove(vehiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehiculoExists(int id)
        {
            return _context.tbl_vehiculos.Any(e => e.idVehiculo == id);
        }
    }
}
