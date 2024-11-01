using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Data;
using OrderManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SOOrderController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SOOrderController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/SOOrder
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SOOrder>>> GetOrders()
        {
            // Include SOItems to get all related items for each SOOrder
            return await _context.SOOrders.Include(o => o.Items).ToListAsync();
        }

        // GET: api/SOOrder/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<SOOrder>> GetOrder(long id)
        {
            // Include SOItems to get related items for the specific SOOrder
            var order = await _context.SOOrders.Include(o => o.Items).FirstOrDefaultAsync(o => o.SO_ORDER_ID == id);

            if (order == null)
                return NotFound();

            return order;
        }

        // POST: api/SOOrder
        [HttpPost]
        public async Task<ActionResult<SOOrder>> CreateOrder(SOOrder order)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Menambahkan order beserta items-nya
            _context.SOOrders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrder), new { id = order.SO_ORDER_ID }, order);
        }

       // PUT: api/SOOrder/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(long id, SOOrder order)
        {
            if (id != order.SO_ORDER_ID)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingOrder = await _context.SOOrders.Include(o => o.Items).FirstOrDefaultAsync(o => o.SO_ORDER_ID == id);
            if (existingOrder == null)
                return NotFound();

            existingOrder.ORDER_NO = order.ORDER_NO;
            existingOrder.ORDER_DATE = order.ORDER_DATE;
            existingOrder.COM_CUSTOMER_ID = order.COM_CUSTOMER_ID;
            existingOrder.ADDRESS = order.ADDRESS;

            // Handle SOItems update
            foreach (var item in order.Items)
            {
                var existingItem = existingOrder.Items.FirstOrDefault(i => i.SO_ITEM_ID == item.SO_ITEM_ID); // Assuming SOItem has an Id
                if (existingItem != null)
                {
                    existingItem.ITEM_NAME = item.ITEM_NAME;
                    existingItem.QUANTITY = item.QUANTITY;
                    existingItem.PRICE = item.PRICE;
                }
                else
                {
                    existingOrder.Items.Add(new SOItem
                    {
                        ITEM_NAME = item.ITEM_NAME,
                        QUANTITY = item.QUANTITY,
                        PRICE = item.PRICE
                    });
                }
            }

            // Optional: Remove items that are not in the updated order
            var itemsToRemove = existingOrder.Items.Where(i => !order.Items.Any(oi => oi.SO_ITEM_ID == i.SO_ITEM_ID)).ToList();
            foreach (var itemToRemove in itemsToRemove)
            {
                existingOrder.Items.Remove(itemToRemove);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/SOOrder/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(long id)
        {
            var order = await _context.SOOrders.Include(o => o.Items).FirstOrDefaultAsync(o => o.SO_ORDER_ID == id);
            if (order == null)
                return NotFound();

            _context.SOOrders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(long id) => _context.SOOrders.Any(e => e.SO_ORDER_ID == id);
    }
}
