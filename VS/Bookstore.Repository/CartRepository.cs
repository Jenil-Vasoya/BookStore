﻿using Bookstore.models.Models;
using Bookstore.models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Repository
{
    public class CartRepository : BaseRepository
    {
            public ListResponse<Cart> GetCartItems(int UserId, int pageIndex, int pageSize)
            {
                //var query = _context.Carts.Include(c => c.Book).Where(c => c.Userid = UserId).AsQueryable
                var query = _context.Carts.Where(c => c.Userid == UserId).AsQueryable();
                return new ListResponse<Cart>()
                {
                    Records = (from Cart in query.Skip((pageIndex - 1) * pageSize).Take(pageSize)
                               join Book in _context.Books on Cart.Bookid equals Book.Id
                               select new Cart
                               {
                                   Id = Cart.Id,
                                   Userid = Cart.Userid,
                                   Bookid = Cart.Bookid,
                                   Quantity = Cart.Quantity,
                                   Book = Book
                               }).ToList(),
                    TotalRecords = query.Count(),
                };
            }

        

        public Cart AddCart(Cart cart)
        {

            try
            {
                var cartInDb = _context.Carts.FirstOrDefault(c => c.Userid == cart.Userid && c.Bookid == cart.Bookid);

                if (cartInDb == null)
                {
                    _context.Carts.Add(cart);
                    _context.SaveChanges();
                    return cart;
                }
                else
                {
                    throw new Exception($"book {cart.Bookid} already exists in the cart for user {cart.Userid}. Update the quantity of existing item in the cart.");
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public Cart UpdateCart(Cart category)
        {
            var id = category.Id;
            var uc = _context.Carts.Where(x => x.Id == id).FirstOrDefault();
            uc.Quantity = category.Quantity;
            var entry = _context.Carts.Update(uc);
            _context.SaveChanges();
            return entry.Entity;
        }

        public bool DeleteCart(int id)
        {
            var Cart = _context.Carts.FirstOrDefault(c => c.Id == id);
            if (Cart == null)
                return false;

            _context.Carts.Remove(Cart);
            _context.SaveChanges();
            return true;
        }
    }
}
