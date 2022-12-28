using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.WeatherForecasts.Queries.GetWeatherForecasts;

namespace MovieApi.WebUI.Controllers;
public class WeatherForecastController : ApiControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await Mediator.Send(new GetWeatherForecastsQuery());
    }
}
