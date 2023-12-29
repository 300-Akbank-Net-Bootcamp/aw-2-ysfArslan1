using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vb.Data;
using Vb.Data.Entity;

namespace VbApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly VbDbContext dbContext;

    public AddressController(VbDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        try
        {
            var _list = await dbContext.Set<Address>().ToListAsync();
            if (_list == null)
            {
                return NotFound(); // 404 Not Found : �stenen kaynak bulunamad�.
            }
            return Ok(_list); // 200 OK: Yap�lan istek ba�ar�l�.
        }
        catch (Exception ex)
        {// 500: Sunucu hatas� nedeniyle i�lem
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id)
    {
        try
        {
            var item = await dbContext.Set<Address>().Where(x => x.Id == id).FirstOrDefaultAsync();
            if (item == null)
            {
                return NotFound(); //404 Not Found : �stenen kaynak bulunamad�.
            }

            return Ok(item); //200 OK: Yap�lan istek ba�ar�l�.
        }
        catch (Exception ex)
        {// 500: Sunucu hatas� nedeniyle i�lem
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Address item)
    {
        try
        {
            if (item == null)
            {
                return BadRequest(); // 400 Bad Request: �stek ge�ersiz veya eksik bilgi i�eriyor.
            }


            await dbContext.Set<Address>().AddAsync(item);
            await dbContext.SaveChangesAsync();
            return new ObjectResult(item)
            {
                StatusCode = StatusCodes.Status201Created // 201 Created: Kay�t ba�ar�l�.
            };

        }
        catch (Exception ex)
        {// 500: Sunucu hatas� nedeniyle i�lem
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] Address item)
    {
        try
        {
            if (id != item.Id)
            {
                return BadRequest();// 400 Bad Request: �stek ge�ersiz veya eksik bilgi i�eriyor.
            }

            var _item = await dbContext.Set<Address>().Where(x => x.Id == id).FirstOrDefaultAsync();
            if (_item == null)
            {
                return NotFound(); // 404 Not Found : �stenen kaynak bulunamad�.
            }
            dbContext.Addresses.Update(_item);
            await dbContext.SaveChangesAsync();
            return Ok(); //200 OK: Yap�lan istek ba�ar�l�.


        }
        catch (Exception ex)
        {// 500: Sunucu hatas� nedeniyle i�lem
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {

            var item = await dbContext.Set<Address>().Where(x => x.Id == id).FirstOrDefaultAsync();

            if (item == null)
            {
                return NotFound(); // 404 Not Found : �stenen kaynak bulunamad�.
            }

            item.IsActive = false;
            dbContext.Update(item);
            await dbContext.SaveChangesAsync();
            return Ok(); //200 OK: Yap�lan istek ba�ar�l�.
        }
        catch (Exception ex)
        {// 500: Sunucu hatas� nedeniyle i�lem
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}