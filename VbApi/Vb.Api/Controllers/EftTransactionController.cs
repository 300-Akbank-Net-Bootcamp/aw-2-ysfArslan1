using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vb.Data;
using Vb.Data.Entity;

namespace VbApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EftTransactionController : ControllerBase
{
    private readonly VbDbContext dbContext;

    public EftTransactionController(VbDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet]
    public async Task<List<EftTransaction>> Get()
    {
        return await dbContext.Set<EftTransaction>()
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<EftTransaction> Get(int id)
    {
        var item =  await dbContext.Set<EftTransaction>()
            .Where(x => x.Id == id).FirstOrDefaultAsync();
       
        return item;
    }

    [HttpPost]
    public async Task Post([FromBody] EftTransaction item)
    {
        await dbContext.Set<EftTransaction>().AddAsync(item);
        await dbContext.SaveChangesAsync();
    }

    [HttpPut("{id}")]
    public async Task Put(int id, [FromBody] EftTransaction item)
    {
        var _item = await dbContext.Set<EftTransaction>().Where(x => x.Id == id).FirstOrDefaultAsync();
        dbContext.Set<EftTransaction>().Update(_item);

        await dbContext.SaveChangesAsync();
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        var _item = await dbContext.Set<EftTransaction>().Where(x => x.Id == id).FirstOrDefaultAsync();
        _item.IsActive = false;
        await dbContext.SaveChangesAsync();
    }
}