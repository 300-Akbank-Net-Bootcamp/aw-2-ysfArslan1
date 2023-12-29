using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vb.Data;
using Vb.Data.Entity;

namespace VbApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly VbDbContext dbContext;

    public ContactController(VbDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        try
        {
            var _list = await dbContext.Set<Contact>().ToListAsync();
            if (_list == null)
            {
                return NotFound(); // 404 Not Found : Ýstenen kaynak bulunamadý.
            }
            return Ok(_list); // 200 OK: Yapýlan istek baþarýlý.
        }
        catch (Exception ex)
        {// 500: Sunucu hatasý nedeniyle iþlem
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id)
    {
        try
        {
            var item = await dbContext.Set<Contact>().Where(x => x.Id == id).FirstOrDefaultAsync();
            if (item == null)
            {
                return NotFound(); //404 Not Found : Ýstenen kaynak bulunamadý.
            }

            return Ok(item); //200 OK: Yapýlan istek baþarýlý.
        }
        catch (Exception ex)
        {// 500: Sunucu hatasý nedeniyle iþlem
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Contact item)
    {
        try
        {
            if (item == null)
            {
                return BadRequest(); // 400 Bad Request: Ýstek geçersiz veya eksik bilgi içeriyor.
            }


            await dbContext.Set<Contact>().AddAsync(item);
            await dbContext.SaveChangesAsync();
            return new ObjectResult(item)
            {
                StatusCode = StatusCodes.Status201Created // 201 Created: Kayýt baþarýlý.
            };

        }
        catch (Exception ex)
        {// 500: Sunucu hatasý nedeniyle iþlem
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] Contact item)
    {
        try
        {
            if (id != item.Id)
            {
                return BadRequest();// 400 Bad Request: Ýstek geçersiz veya eksik bilgi içeriyor.
            }

            var _item = await dbContext.Set<Contact>().Where(x => x.Id == id).FirstOrDefaultAsync();
            if (_item == null)
            {
                return NotFound(); // 404 Not Found : Ýstenen kaynak bulunamadý.
            }
            dbContext.Contacts.Update(_item);
            await dbContext.SaveChangesAsync();
            return Ok(); //200 OK: Yapýlan istek baþarýlý.


        }
        catch (Exception ex)
        {// 500: Sunucu hatasý nedeniyle iþlem
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {

            var item = await dbContext.Set<Contact>().Where(x => x.Id == id).FirstOrDefaultAsync();

            if (item == null)
            {
                return NotFound(); // 404 Not Found : Ýstenen kaynak bulunamadý.
            }

            item.IsActive = false;
            dbContext.Update(item);
            await dbContext.SaveChangesAsync();
            return Ok(); //200 OK: Yapýlan istek baþarýlý.
        }
        catch (Exception ex)
        {// 500: Sunucu hatasý nedeniyle iþlem
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}