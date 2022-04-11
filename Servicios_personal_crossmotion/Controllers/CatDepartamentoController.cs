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
    public class CatDepartamentoController : ControllerBase
    {
        private readonly Personal_CrossmotionContext _context;

        public CatDepartamentoController(Personal_CrossmotionContext context)
        {
            _context = context;
        }

        // GET: api/CatDepartamento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatDepartamento>>> GetCatDepartamento()
        {
            return await _context.CatDepartamento.ToListAsync();
        }

        // GET: api/CatDepartamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatDepartamento>> GetCatDepartamento(int id)
        {
            var catDepartamento = await _context.CatDepartamento.FindAsync(id);

            if (catDepartamento == null)
            {
                return NotFound();
            }
            return catDepartamento;
        }
    }
}
