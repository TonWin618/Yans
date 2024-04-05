﻿namespace Yans.Modules.Demo.Application.Weathers.DTOs;

public class WeatherDto
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }

    public WeatherDto(DateOnly date, int temperatureC, string? summary)
    {
        Date = date;
        TemperatureC = temperatureC;
        Summary = summary;
    }
}
