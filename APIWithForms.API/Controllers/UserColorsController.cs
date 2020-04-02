using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIWithForms.API.Data;
using APIWithForms.Models;
using APIWithForms.API.Extensions;
using APIWithForms.Entities;

namespace APIWithForms.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserColorsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public UserColorsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/UserColors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserColorModel>>> GetUserColor()
        {
            return await _context.UserColors.Select(x => x.ToModel()).ToListAsync();
        }

        // GET: api/UserColors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserColorModel>> GetUserColor(int id)
        {
            var userColor = await _context.UserColors.FindAsync(id);

            if (userColor == null)
            {
                return NotFound();
            }

            return userColor.ToModel();
        }

        // PUT: api/UserColors/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserColor(int id, UserColorModel userColorModel)
        {
            if (id != userColorModel.Id)
            {
                return BadRequest();
            }

            UserColor color = _context.UserColors.Find(id);

            if (!UserColorExists(id)) return BadRequest();

            color.Name = userColorModel.Name;
            color.Red = userColorModel.Red;
            color.Green = userColorModel.Green;
            color.Blue = userColorModel.Blue;
            color.Alpha = userColorModel.Alpha;

            _context.Entry(color).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserColorExists(id))
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

        // POST: api/UserColors
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UserColorModel>> PostUserColor(UserColorModel userColorModel)
        {
            UserColor userColor = userColorModel.ToEntity();
            _context.UserColors.Add(userColor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserColor", new { id = userColor.Id }, userColor);
        }

        [HttpPost("FromHex")]
        public async Task<ActionResult<UserColorModel>> PostFromHex(ColorFromHexModel colorFromHexModel)
        {
            string hex = colorFromHexModel.Hex;
            hex = hex.TrimStart('#');

            if (hex.Length == 6) hex = "FF" + hex;

            System.Drawing.Color c = System.Drawing.Color.FromArgb(Int32.Parse(hex, System.Globalization.NumberStyles.HexNumber));

            UserColor newColor = new UserColor
            {
                Name = colorFromHexModel.Name,
                Alpha = c.A,
                Red = c.R,
                Green = c.G,
                Blue = c.B
            };

            _context.UserColors.Add(newColor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserColor", new { id = newColor.Id }, newColor);
        }

        // DELETE: api/UserColors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserColorModel>> DeleteUserColor(int id)
        {
            var userColor = await _context.UserColors.FindAsync(id);
            if (userColor == null)
            {
                return NotFound();
            }

            _context.UserColors.Remove(userColor);
            await _context.SaveChangesAsync();

            return userColor.ToModel();
        }

        private bool UserColorExists(int id)
        {
            return _context.UserColors.Any(e => e.Id == id);
        }
    }
}
