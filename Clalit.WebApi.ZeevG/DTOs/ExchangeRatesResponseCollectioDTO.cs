namespace Clalit.WebApi.ZeevG.DTOs
{
    public class ExchangeRate
    {
        public IEnumerable<ExchangeRateResponseDTO>? ExchangeRateResponseDTO { get; set; }
    }

    public class ExchangeRateResponseDTO
    {
        public float CurrentChange { get; set; }
        public float CurrentExchangeRate { get; set; }
        public string? Key { get; set; }
        public string? LastUpdate { get; set; }
        public string? Unit { get; set; }
    }

    public class ExchangeRatesResponseCollectioDTO
    {
        public ExchangeRate? ExchangeRates { get; set; }
    }

    public class Root
    {
        public ExchangeRatesResponseCollectioDTO? ExchangeRatesResponseCollectioDTO { get; set; }
    }
}
