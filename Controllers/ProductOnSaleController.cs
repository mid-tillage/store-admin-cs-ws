using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store_admin_cs_ws.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace store_admin_cs_ws.Controllers;

[ApiController]
[Route("product-on-sale")]
public class ProductOnSaleController : ControllerBase
{
    // TODO: Send post, put and delete requests through the orchestrator
    private readonly string orchestratorEndpoint =
        Environment.GetEnvironmentVariable("STORE_ENGINE_ORCHESTRATOR_PROTOCOL")
        + "://" + Environment.GetEnvironmentVariable("STORE_ENGINE_ORCHESTRATOR_IP")
        + ":" + Environment.GetEnvironmentVariable("STORE_ENGINE_ORCHESTRATOR_PORT");

    private readonly SaleManagementSystemContext _context;
    public ProductOnSaleController(SaleManagementSystemContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductOnSale>>> GetAll() =>
        await _context.ProductOnSales
            .Include(p => p.Product)
            .Include(p => p.Product.Enterprise)
            .Include(p => p.Catalog)
            .ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductOnSale>> Get(long id)
    {
        var productOnSale = await _context.ProductOnSales
            .Include(p => p.Product)
            .Include(p => p.Product.Enterprise)
            .Include(p => p.Catalog)
            .FirstOrDefaultAsync(p => p.IdProductOnSale == id);

        if (productOnSale == null)
            return NotFound();

        return productOnSale;
    }

    [HttpPost]
    public async Task<ActionResult<ProductOnSale>> Create(ProductOnSale productOnSale)
    {
        productOnSale.Product = null;
        productOnSale.Catalog = null;
        _context.ProductOnSales.Add(productOnSale);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = productOnSale.IdProductOnSale }, productOnSale);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, ProductOnSale productOnSale)
    {
        if (id != productOnSale.IdProductOnSale)
            return BadRequest();

        _context.Entry(productOnSale).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductOnSaleExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var productOnSale = await _context.ProductOnSales.FindAsync(id);
        if (productOnSale == null)
        {
            return NotFound();
        }

        _context.ProductOnSales.Remove(productOnSale);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductOnSaleExists(long id)
    {
        return _context.ProductOnSales.Any(e => e.IdProductOnSale == id);
    }
}