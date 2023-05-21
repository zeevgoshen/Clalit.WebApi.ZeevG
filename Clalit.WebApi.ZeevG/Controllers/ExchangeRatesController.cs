using Clalit.WebApi.ZeevG.DTOs;
using Clalit.WebApi.ZeevG.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clalit.WebApi.ZeevG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchangeRatesController : ControllerBase
    {
        private readonly IExchangeRatesService service;

        public ExchangeRatesController(
            ILogger<WeatherForecastController> logger,
            IExchangeRatesService service)
        {
            this.service = service;
        }

        [HttpGet(Name = "GetExchangeRates")]
        public async Task<IEnumerable<ExchangeRateResponseDTO>> GetExchangeRates()
        {
            return await service.GetExchangeRatesAsync();
            //.ToArray();
        }
    }
}
