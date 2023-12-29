using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Security.Principal;
using Vb.Data;
using Vb.Data.Entity;

namespace VbApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly VbDbContext dbContext;
    
    public AccountController(VbDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        //return await dbContext.Set<Account>()
        //    .ToListAsync();

        try
        {
            var _list = await dbContext.Set<Account>().ToListAsync();
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
        //var account =  await dbContext.Set<Account>().Where(x => x.Id == id).FirstOrDefaultAsync();

        //return account;

        try
        {
            var account = await dbContext.Set<Account>().Where(x => x.Id == id).FirstOrDefaultAsync();
            if (account == null)
            {
                return NotFound(); //404 Not Found : Ýstenen kaynak bulunamadý.
            }

            return Ok(account); //200 OK: Yapýlan istek baþarýlý.
        }
        catch (Exception ex)
        {// 500: Sunucu hatasý nedeniyle iþlem
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }

    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Account account)
    {
        //await dbContext.Set<Account>().AddAsync(account);
        //await dbContext.SaveChangesAsync();
        try
        {
            if (account == null)
            {
                return BadRequest(); // 400 Bad Request: Ýstek geçersiz veya eksik bilgi içeriyor.
            }

            
            await dbContext.Set<Account>().AddAsync(account);
            await dbContext.SaveChangesAsync();
            return new ObjectResult(account)
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
    public async Task<ActionResult> Put(int id, [FromBody] Account updateAccount)
    {
        //var _account = await dbContext.Set<Account>().Where(x => x.Id == id).FirstOrDefaultAsync();

        //dbContext.Accounts.Update(_account);
        //await dbContext.SaveChangesAsync();
        try
        {
            if (id != updateAccount.Id)
            {
                return BadRequest();// 400 Bad Request: Ýstek geçersiz veya eksik bilgi içeriyor.
            }

                var account = await dbContext.Set<Account>().Where(x => x.Id == id).FirstOrDefaultAsync();
                if (account == null)
                {
                    return NotFound(); // 404 Not Found : Ýstenen kaynak bulunamadý.
                }
                dbContext.Accounts.Update(account);
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
        //var _account = await dbContext.Set<Account>().Where(x => x.Id == id).FirstOrDefaultAsync();
        //_account.IsActive = false;
        //await dbContext.SaveChangesAsync();

        try
        {

            var account = await dbContext.Set<Account>().Where(x => x.Id == id).FirstOrDefaultAsync();

            if (account == null)
            {
                return NotFound(); // 404 Not Found : Ýstenen kaynak bulunamadý.
            }

            account.IsActive= false;
            dbContext.Update(account);
            await dbContext.SaveChangesAsync();
            return Ok(); //200 OK: Yapýlan istek baþarýlý.
        }
        catch (Exception ex)
        {// 500: Sunucu hatasý nedeniyle iþlem
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }


    }
}