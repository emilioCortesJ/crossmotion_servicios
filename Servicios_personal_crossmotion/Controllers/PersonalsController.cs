#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Servicios_personal_crossmotion.Data;
using Servicios_personal_crossmotion.Models;

namespace Servicios_personal_crossmotion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalController : ControllerBase
    {
        private readonly Personal_CrossmotionContext _context;

        public PersonalController(Personal_CrossmotionContext context)
        {
            _context = context;
        }

        [HttpGet("obtenerPersonal")]
        public async Task<IEnumerable<ObtenerPersonal>> Get()
        {
            return await _context.ObtenerPersonal.ToListAsync();
        }

        [HttpPost("agregar")]
        public async Task<ActionResult> AgregarPersonal(Personal personal)
        {
            try
            {
                await _context.GetProcedures().agregarPersonalAsync(personal.Nombre, personal.Apellido, personal.FechaNacimiento, personal.FkDepartamento);
                return Ok();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("editar")]
        public async Task<ActionResult> EditarPersonal(Personal personal)
        {
            try
            {
                await _context.GetProcedures().editarPersonalAsync(personal.IdPersonal, personal.Nombre, personal.Apellido, personal.FechaNacimiento, personal.FkDepartamento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("eliminar")]
        public async Task<ActionResult> EliminarPersonal(Personal personal)
        {
            try
            {
                await _context.GetProcedures().eliminarPersonalAsync(personal.IdPersonal, personal.Estatus);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool PersonalExists(int id)
        {
            return _context.Personal.Any(e => e.IdPersonal == id);
        }
    }
}
