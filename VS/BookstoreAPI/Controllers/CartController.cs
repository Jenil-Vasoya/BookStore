using Bookstore.models.Models;
using Bookstore.models.ViewModels;
using Bookstore.Repository;
using BookStore.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookstoreAPI.Controllers
{
    [ApiController]
    [Route("Cart")]

    public class CartController : Controller
    {
       private readonly CartRepository _cartRepository = new CartRepository();

        [HttpGet]
        [Route("list")]
        public IActionResult GetCartItems(int UserId, int pageIndex = 1, int pageSize = 10)
        {
            ListResponse<Cart> carts = _cartRepository.GetCartItems(UserId, pageIndex, pageSize);
            ListResponse<GetCartModel> cartModels = new ListResponse<GetCartModel>()
            {
                Records = carts.Records.Select(c => new GetCartModel(c.Id, c.Userid, new BookModel(c.Book), c.Quantity)).ToList(),
                TotalRecords = carts.TotalRecords
            };
            return Ok(cartModels);
        }


        [HttpPost]
        [Route("add")]
        public ActionResult<CartModel> AddCart(CartModel model)
        {
            if (model == null)
                return BadRequest();

            Cart cart = new Cart()
            {
                Id = model.Id,
                Quantity = 1,
                Bookid = model.Bookid,
                Userid = model.Userid
            };
            cart = _cartRepository.AddCart(cart);
            if (cart == null)
            {
                return StatusCode(500);
            }
            return new CartModel(cart);
        }

        [Route("update")]
        [HttpPut]
        public IActionResult UpdateCarts(CartModel model)
        {
            if (model == null)
                return BadRequest();

            Cart cart = new Cart()
            {
                Id = model.Id,
                Quantity = model.Quantity,
                Userid = model.Userid,
                Bookid = model.Bookid,
            };
            cart = _cartRepository.UpdateCart(cart);

            return Ok(new CartModel(cart));
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult DeleteCarts(int id)
        {
            var response = _cartRepository.DeleteCart(id);
            return Ok(response);
        }
    }
}
