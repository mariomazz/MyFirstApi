using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Controllers.models;

namespace MyFirstApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return Ok(await _context.Users.ToListAsync<User>());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(string id)
        {
            var user = await _context.Users.FindAsync(id);
            
            if (user == null)
            {
                return BadRequest("Utente Non Trovato");
            }

            return Ok(user);
        }


        [HttpPost]
        public async Task<ActionResult<IEnumerable<User>>> Add([FromBody] User user)
        {

            user.Id = Guid.NewGuid().ToString();

            if (user == default || !(user!.isValid()))
            {
                return BadRequest("Utente Non Valido");
            }

            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();

            return Ok(await _context.Users.ToListAsync());

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<User>>> UpdateUser(string id,[FromBody] UserBase user)
        {

            if (user == default || !(user!.isValid()))
            {
                return BadRequest("Utente Non Valido");
            }

            var userFound = await _context.Users.FindAsync(id);

            if (userFound == null)
            {
                return BadRequest("Utente Non Trovato, impossibile aggiornare");
            }

            userFound.Name = user.Name;
            userFound.Surname = user.Surname;
            userFound.Age = user.Age;

            _context.Update(userFound);

            await _context.SaveChangesAsync();

            return Ok(await _context.Users.ToListAsync());

        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<string>> DeleteUser(string id)
        {

            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return BadRequest("Non Trovato");
            }

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return Ok("Utente Cancellato");
        }


    }
}
