using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebCore6.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NoteController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<NoteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allData = await _context.Notepads.ToListAsync();
            return Ok(allData);
        }

        // GET api/<NoteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _context.Notepads.Where(x=> x.Id == id).ToList();
            if(result.Count() > 0)
                return Ok(result);
            else
                return BadRequest("Note Not Found Id="+id );
        }

        // POST api/<NoteController>
        [HttpPost]
        public async Task<IActionResult> Create(Notepad notepad)
        {
             _context.Add(notepad);
            int count = _context.SaveChanges();
            if(Convert.ToInt32(count)> 0)
                return Ok("Add SuccessFully");
            else
                return BadRequest();
        }

        // PUT api/<NoteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Notepad notepad)
        {
            var data = _context.Notepads.Where(x=> x.Id==notepad.Id).ToList();
            if (data.Count() ==  0)
                return BadRequest("Data not found");

            var note = new Notepad()
            {
                Id = notepad.Id,
                Note= notepad.Note
            };

            _context.Update(note);
            int count = _context.SaveChanges();
            if (Convert.ToInt32(count)> 0)
                return Ok("Add SuccessFully");
            else
                return BadRequest();
        }

        // DELETE api/<NoteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = _context.Notepads.Find(id);
            if (data == null)
            {
                return BadRequest("not found");
            }

            _context.Remove(data);
            _context.SaveChanges();

            return Ok();
        }
    }
}
