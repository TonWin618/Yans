using MediatR;
using Microsoft.AspNetCore.Mvc;
using Yans.Base.Application.Validations;
using Yans.Modules.Demo.Application.Weathers.CreateWeather;
using Yans.Modules.Demo.Application.Weathers.GetWeathersByCount;

namespace Yans.Modules.Demo.WebAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class WeatherController : ControllerBase
{
    private readonly ILogger<WeatherController> _logger;
    private readonly IMediator _mediator;

    public WeatherController(ILogger<WeatherController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateWeather(CreateWeatherCommand request)
    {
        var res = await _mediator.Send(request);

        if (!res.Success)
        {
            return Ok(ErrorsResult.CreateFromErrors(res.Errors));
        }

        return Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> GetWeatherByCount(GetWeatherByCountQuery request)
    {
        var res = await _mediator.Send(request);

        if (!res.Success)
        {
            return Ok(ErrorsResult.CreateFromErrors(res.Errors));
        }

        return Ok(res);
    }
}
