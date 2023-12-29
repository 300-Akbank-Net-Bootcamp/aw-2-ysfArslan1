using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vb.Data;
using Vb.Data.Entity;

namespace VbApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountTransactionController : ControllerBase
{
    private readonly VbDbContext dbContext;

    public AccountTransactionController(VbDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet]
    public async Task<List<AccountTransaction>> Get()
    {
        return await dbContext.Set<AccountTransaction>()
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<AccountTransaction> Get(int id)
    {
        var item =  await dbContext.Set<AccountTransaction>()
            .Where(x => x.Id == id).FirstOrDefaultAsync();
       
        return item;
    }

    [HttpPost]
    public async Task Post([FromBody] AccountTransaction item)
    {
        await dbContext.Set<AccountTransaction>().AddAsync(item);
        await dbContext.SaveChangesAsync();
    }

    [HttpPut("{id}")]
    public async Task Put(int id, [FromBody] AccountTransaction item)
    {
        var _item = await dbContext.Set<AccountTransaction>().Where(x => x.Id == id).FirstOrDefaultAsync();
        dbContext.AccountTransactions.Update(item);

        await dbContext.SaveChangesAsync();
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        var _item = await dbContext.Set<AccountTransaction>().Where(x => x.Id == id).FirstOrDefaultAsync();
        _item.IsActive = false;
        await dbContext.SaveChangesAsync();
    }
}