using Clalit.WebApi.ZeevG.DTOs;

namespace Clalit.WebApi.ZeevG.Services
{
    public interface IExchangeRatesService
    {
        public Task<IEnumerable<ExchangeRateResponseDTO>?> GetExchangeRatesAsync();
    }
}
