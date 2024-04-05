using Yans.Modules.Demo.Domain.Weathers.Entities;

namespace Yans.Modules.Demo.Domain.Weathers;

public interface IDemoRepository
{
    Task<List<Weather>> GetWeathersAsync(int count);

    Task CreateWeatherAsync(Weather weather);
}
