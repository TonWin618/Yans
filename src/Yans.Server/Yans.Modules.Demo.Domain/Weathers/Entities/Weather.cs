using Yans.Base.Domain;
using Yans.Modules.Demo.Domain.Weathers.Events;

namespace Yans.Modules.Demo.Domain.Weathers.Entities;

public class Weather : EntityBase
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public string? Summary { get; set; }

    private Weather()
    {
        //Only for EFCore
    }

    public Weather(DateOnly date, int temperatureC, string? summary)
    {
        Date = date;
        TemperatureC = temperatureC;
        Summary = summary;

        AddDomainEvent(new WeatherCreatedDomainEvent(Date));
    }
}
