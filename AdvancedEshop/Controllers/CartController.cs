using AdvancedEshop.Data;
using AdvancedEshop.Infrasstructure;
using AdvancedEshop.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace AdvancedEshop.Controllers
{
    public class CartController : Controller
    {   

        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index() 
        { 
            return View("Cart", HttpContext.Session.GetJson<Cart>("cart")); 
        }


        public Cart? Cart { get; set; }

        public IActionResult AddToCart(int? ProductId)
        {
            Product? product = _context.Products
                .FirstOrDefault(p => p.ProductId == ProductId);

            if (product != null) 
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, 1);
                HttpContext.Session.SetJson("cart", Cart);
            }

            return View("Cart", Cart);
        }

        public IActionResult UpdateCart(int ProductId)
        {
            Product? product = _context.Products
                .FirstOrDefault(p => p.ProductId == ProductId);

            if (product != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, -1);
                HttpContext.Session.SetJson("cart", Cart);
            }

            return View("Cart", Cart);
        }


        public IActionResult RemoveFromCart(int ProductId)
        {
            Product? product = _context.Products
                .FirstOrDefault(p => p.ProductId == ProductId);

            if (product != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart");
                Cart.RemoveLine(product);
                HttpContext.Session.SetJson("cart", Cart);
            }

            return View("Cart", Cart);
        }

    }
}
