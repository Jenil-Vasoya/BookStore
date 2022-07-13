using Bookstore.models.Models;
using Bookstore.models.ViewModels;
using Bookstore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookstoreAPI.Controllers
{
    [ApiController]
    [Route("Book")]
    public class BookController : Controller
    {
        BookRepository _bookRepository = new BookRepository();

        [Route("list")]
        [HttpGet]
        public IActionResult GetBooks(int pageIndex = 1, int pageSize = 10, string keyword = "")
        {
            var books = _bookRepository.GetBooks(pageIndex, pageSize, keyword);
            ListResponse<BookModel> listResponse = new ListResponse<BookModel>()
            {
                Records = books.Records.Select(c => new BookModel(c)).ToList(),
                TotalRecords = books.TotalRecords,
            };

            return Ok(listResponse);
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetBooks(int id)
        {
            var book = _bookRepository.GetBook(id);
            BookModel bookmodel = new BookModel(book);

            return Ok(bookmodel);
        }

        [Route("add")]
        [HttpPost]
        public IActionResult AddBooks(BookModel model)
        {
            Book book = new Book()
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Base64image = model.Base64image,
                Categoryid = model.Categoryid,
                Publisherid = model.Publisherid,
                Quantity = model.Quantity,
            };

            var response = _bookRepository.AddBook(book);
            BookModel bookModel = new BookModel(response);

            return Ok(bookModel);
        }

        [Route("update")]
        [HttpPut]
        public IActionResult UpdateBooks(BookModel model)
        {
            Book book = new Book()
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Base64image = model.Base64image,
                Categoryid = model.Categoryid,
                Publisherid = model.Publisherid,
                Quantity = model.Quantity,
            };

            var response = _bookRepository.UpdateBook(book);
            BookModel bookModel = new BookModel(response);

            return Ok(bookModel);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult DeleteBooks(int id)
        {
            var response = _bookRepository.DeleteBook(id);
            return Ok(response);
        }
    }
}
