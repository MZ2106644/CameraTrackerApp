using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CameraTrackerApp.Models;

namespace CameraTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CamerasAPIController : ControllerBase
    {
        private readonly Context _context;

        public CamerasAPIController(Context context)
        {
            _context = context;
        }

        // GET: api/CamerasAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Camera>>> GetCamera()
        {
            return await _context.Camera.ToListAsync();
        }

        // GET: api/CamerasAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Camera>> GetCamera(int id)
        {
            var camera = await _context.Camera.FindAsync(id);

            if (camera == null)
            {
                return NotFound();
            }

            return camera;
        }

        // PUT: api/CamerasAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCamera(int id, Camera camera)
        {
            if (id != camera.CameraID)
            {
                return BadRequest();
            }

            _context.Entry(camera).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CameraExists(id))
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

        // POST: api/CamerasAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Camera>> PostCamera(Camera camera)
        {
            _context.Camera.Add(camera);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCamera", new { id = camera.CameraID }, camera);
        }

        // DELETE: api/CamerasAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCamera(int id)
        {
            var camera = await _context.Camera.FindAsync(id);
            if (camera == null)
            {
                return NotFound();
            }

            _context.Camera.Remove(camera);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CameraExists(int id)
        {
            return _context.Camera.Any(e => e.CameraID == id);
        }
    }
}
