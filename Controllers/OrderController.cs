using BethanysPieShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Controllers
{
    public class OrderController : Controller
    {


        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrderRepository _orderRepository;

        public OrderController(AppDbContext appDbContext, ShoppingCart shoppingCart , IOrderRepository orderRepository)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
            _orderRepository = orderRepository;
        }


        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count==0)
            {
                ModelState.AddModelError("", "Your shopping cart is empty,add somes pies first");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(order);

        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order.You will soon enjour your delicious pie";
            return View();
        }
    }
}
