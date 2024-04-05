using Microsoft.EntityFrameworkCore;
using Yans.Modules.Demo.Domain.Weathers;
using Yans.Modules.Demo.Domain.Weathers.Entities;

namespace Yans.Modules.Demo.Infrastructure;

public class DemoRepository : IDemoRepository
{
    private readonly DemoDbContext _demoDbContext;

    public DemoRepository(DemoDbContext demoDbContext) 
    {
        _demoDbContext = demoDbContext;
    }

    public async Task CreateWeatherAsync(Weather weather)
    {
        await _demoDbContext.Weathers.AddAsync(weather);
    }

    public async Task<List<Weather>> GetWeathersAsync(int count)
    {
        return await _demoDbContext.Weathers
            .OrderBy(x=> x.Date)
            .Take(count)
            .ToListAsync();
    }
}
