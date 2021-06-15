using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public LoginController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<LoginController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list_users = await _context.Login.ToListAsync();
                return Ok(list_users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // GET api/<LoginController>/5
        [HttpGet("{user}")]
        public async Task<IActionResult> Get(string user)
        {
            try
            {
                var list_users = await _context.Login.ToListAsync();
                foreach (var login in list_users)
                {
                    if(user == login.User)
                    {
                        return Ok(login);
                    }
                }
                return BadRequest("El usuario no exite");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

      
        // POST api/<LoginController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Login user)
        {
            try
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Login user)
        {
            try
            {
                if ((id != user.Id)||(user.Mode != (true || false)))
                {
                    return NotFound();
                }
                _context.Update(user);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Usuario actualizado exitosamente!" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = await _context.Login.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                _context.Login.Remove(user);
                await _context.SaveChangesAsync();
                return Ok(new { message = " Usuario eliminado exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
