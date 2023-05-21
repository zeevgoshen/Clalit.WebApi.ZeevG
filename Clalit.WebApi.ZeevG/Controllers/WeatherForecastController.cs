using Clalit.WebApi.ZeevG.DTOs;
using Clalit.WebApi.ZeevG.Services;
using Microsoft.AspNetCore.Mvc;

namespace Clalit.WebApi.ZeevG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IExchangeRatesService service;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IExchangeRatesService service)
        {
            _logger = logger;
            this.service = service;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        //[HttpGet(Name = "GetExchangeRates")]
        //public async Task<ExchangeRateResponseDTO> GetExchangeRates()
        //{
        //    return await service.GetExchangeRatesAsync();
        //    //.ToArray();
        //}
    }
}