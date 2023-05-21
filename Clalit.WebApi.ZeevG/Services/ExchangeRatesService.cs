using Clalit.WebApi.ZeevG.DTOs;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace Clalit.WebApi.ZeevG.Services
{
    public class ExchangeRatesService : IExchangeRatesService
    {
        private string url = "https://boi.org.il/PublicApi/GetExchangeRates?asXML=true";
        private List<ExchangeRateResponseDTO> results = new List<ExchangeRateResponseDTO>();

        public async Task<IEnumerable<ExchangeRateResponseDTO>?> GetExchangeRatesAsync()
        {
            try
            {
                var client = InitializeClient(url);

                // Get data response
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    //// Parse the response body
                    var dataObjects = await response.Content.ReadAsStringAsync();

                    if (dataObjects != null)
                    {
                        ReturnNegativeChangeJson(dataObjects);
                    }
                }
                return results;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void ReturnNegativeChangeJson(string dataObjects)
        {
            var xmldoc = new XmlDocument();
            xmldoc.LoadXml(dataObjects);

            var elem = xmldoc?.DocumentElement?.ChildNodes[0];
            var fromXml = JsonConvert.SerializeXmlNode(elem);
            var fromJson = JsonConvert.DeserializeObject<ExchangeRatesResponseCollectioDTO>(fromXml);

            results.AddRange(from node in fromJson?.ExchangeRates?.ExchangeRateResponseDTO
                             where node.CurrentChange < 0
                             select node);
        }

        private HttpClient InitializeClient(string url)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);

            // Add headers for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("text/xml"));

            return client;
        }
    }
}
