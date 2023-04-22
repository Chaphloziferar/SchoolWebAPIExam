using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolWebAPI.Db;

namespace SchoolWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly SchoolContext _context;

        public UserController(SchoolContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Devuelve el listado de todos los usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            if (_context.Users == null) return NotFound();

            return await _context.Users.ToListAsync();
        }

        /// <summary>
        /// Devuelve un usuario especifico
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<ActionResult<User>> GetUser(int userId)
        {
            if (_context.Users == null) return NotFound();

            var user = await _context.Users.FindAsync(userId);

            if (user == null) return NotFound();

            return Ok(user);
        }

        /// <summary>
        /// Crear un nuevo registro de usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> PostUser(User user)
        {
            if (_context.Users == null) return NotFound();

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostUser), user);
        }

        /// <summary>
        /// Modificar un usuario existente
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("{userId}")]
        public async Task<ActionResult> PutUser(int userId, User user)
        {
            if (userId != user.UserId) return BadRequest();

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(userId)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        /// <summary>
        /// Elimina a un usuario especifico
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpDelete("{userId}")]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            if (_context.Users == null) return NotFound();

            var userToDelete = await _context.Users.FindAsync(userId);

            if (userToDelete == null) return NotFound();

            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int userId)
        {
            return (_context.Users?.Any(user => user.UserId == userId)).GetValueOrDefault();
        }
    }
}
