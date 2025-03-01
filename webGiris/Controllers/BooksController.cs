using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.OpenApi.Any;
using webGiris.Data;
using webGiris.Models;
using static System.Net.Mime.MediaTypeNames;

namespace webGiris.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAllBooks()
        {

            var books=ApplicationContext.Books;
            return Ok(books);

        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute]int id)
        {
            var books = ApplicationContext.Books.Where(b=>b.Id.Equals(id)).SingleOrDefault();

            if (books is null  )
                return NotFound();

            return Ok(books);

        }
        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {

            try
            {
                if (book is null)
                    return BadRequest();

                ApplicationContext.Books.Add(book);
                return StatusCode(201, book);
           
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute]int id,[FromBody] Book book)
        {
            var entity = ApplicationContext.Books.Find(b=> b.Id.Equals(id));
          
            if (entity is null )
                return NotFound();

            if (id!=book.Id)
                return BadRequest();

            ApplicationContext.Books.Remove(entity);
            book.Id = entity.Id;
            ApplicationContext.Books.Add(book);
            return Ok(book);


        }
        [HttpDelete("{id:int}")]
        public ActionResult DeleteOneBook([FromRoute] int id)
        {
            var entity=ApplicationContext.Books.Find(b=>b.Id.Equals(id));

            if(entity is null )
                return NotFound(new
                {
                    StatusCode=404,
                    message=$"Book with id:{id} could not found. "

                });

            ApplicationContext.Books.Remove(entity);
            return NoContent();

        }

    }
}
