using lab_8.DbContext;
using lab_8.Hasher;
using lab_8.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static lab_8.Models.Order;
using lab_8.Validations;
using Microsoft.EntityFrameworkCore;

namespace lab_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private ApiDbContext _db;
        public OrderController(ApiDbContext db)
        {
            _db = db;
        }

        [HttpGet("order")]
        public IActionResult GetOrder(int id) 
        {
            var order = _db.Orders.Where(x=>x.Id == id).Include(x => x.Orders).ThenInclude(x => x.Product).FirstOrDefault();
            if (order is not null)
                return Ok(order);
            return NotFound();
        }
        [HttpGet("orders")]
        public IActionResult GetOrders()
        {
            var orders = _db.Orders.Include(x=>x.Owner).Include(x=>x.Orders).ThenInclude(x=>x.Product).ToList();
            if(orders is not null && orders.Any())
                return Ok(orders);
            return NotFound();
        }
        [HttpPost("create")]
        public IActionResult CreateOrder(OrderModel model) 
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var owner = _db.Users.Where(x => x.Email == model.Email).FirstOrDefault();
            if(!(owner is not null && PasswordHasher.VerifyPassword(model.Password, owner.Password)))
                return BadRequest();

            var orders = new List<OrderProduct>();

            foreach (var item in model.OrdersAndAmount)
            {
                if (item.Value < 0)
                    return BadRequest();

                var product = _db.Products.Where(x => x.Id == item.Key).FirstOrDefault();
                if (product is null)
                    return NotFound(item.Key);

                orders.Add(new OrderProduct(product, item.Value));
            }

            foreach (var item in orders)
            {
                item.Product.Amount -= item.Amount;
            }

            var order = new Order(owner, orders, Order.StatusOrder.BeingProcessed);
            _db.Orders.Add(order);
            _db.SaveChanges();

            return Ok();
        }
        [HttpPut("changestatus")]
        public IActionResult ChangeStatusOrder(int id, StatusOrder status)
        {
            if (!OrderValid.StatusOrderIsValid(status))
                BadRequest();

            var order = _db.Orders.Where(x => x.Id == id).FirstOrDefault();
            if (order is null)
                return NotFound();

            order.Status = status;
            _db.SaveChanges();
            return Ok();
        }
        [HttpPut("changeamount")]
        public IActionResult ChangeAmountProduct(int id, int idProduct, int newAmount)
        {
            if (newAmount < 0)
                return BadRequest();

            var order = _db.Orders.Where(x => x.Id == id).Include(x=>x.Orders).ThenInclude(x=>x.Product).FirstOrDefault();
            if (order is null)
                return NotFound();


            var orderProduct = order.Orders.Where(x=>x.Product.Id == idProduct).FirstOrDefault();
            if (orderProduct is null)
                return NotFound();

            int difference = newAmount - orderProduct.Amount;
            orderProduct.Product.Amount -= difference;
            orderProduct.Amount = newAmount;
            _db.SaveChanges();
            return Ok();

        }
    }
}
