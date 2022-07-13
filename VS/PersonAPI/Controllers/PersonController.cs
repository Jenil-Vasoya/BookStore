using Microsoft.AspNetCore.Mvc;
using PersonAPI.Model;

namespace PersonAPI.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonDbContext _context;
       public PersonController(PersonDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/[controller]s")]
        public ActionResult<List<Person>> GetAll()
        {
            List<Person> persons = new List<Person>();
            persons = _context.People.ToList();
            return persons;

        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public ActionResult<Person> GetById(int id)
        {
            Person person = new Person();
            person = _context.People.Find(id);
            return person;
        }

        [HttpPost]
        [Route("api/[controller]/")]
        public ActionResult AddPerson(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("api/[controller]")]
        public ActionResult UpdatePerson(Person person)
        {
            _context.Update(person);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public ActionResult DeletePerson(int id)
        {
            Person person = _context.People.Find(id);
            _context.People.Remove(person);
            _context.SaveChanges();
            return Ok();
        }
    }
}
