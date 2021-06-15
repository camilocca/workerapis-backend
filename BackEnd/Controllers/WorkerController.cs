using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public WorkerController(AplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<WorkerController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list_workers = await _context.WorkersApsi.ToListAsync();
                return Ok(list_workers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<WorkerController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var worker = await _context.WorkersApsi.FindAsync(id);
                if (worker == null)
                {
                    return NotFound();
                }
                return Ok(worker);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<WorkerController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WorkersApsi worker)
        {
            try
            {
                _context.Add(worker);
                await _context.SaveChangesAsync();
                return Ok(worker);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<WorkerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] WorkersApsi worker)
        {
            try
            {
                if (id != worker.Id)
                {
                    return NotFound();
                }
                _context.Update(worker);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Empleado actualizado exitosamente!" });

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<WorkerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var worker = await _context.WorkersApsi.FindAsync(id);
                if(worker == null)
                {
                    return NotFound();
                }
                _context.WorkersApsi.Remove(worker);
                await _context.SaveChangesAsync();
                return Ok(new { message =" Empleado eliminado exitosamente" });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
