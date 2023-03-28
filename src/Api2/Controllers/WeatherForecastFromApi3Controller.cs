using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Api2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class WeatherForecastFromApi3Controller : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastFromApi3Controller> _logger;

        public WeatherForecastFromApi3Controller(ILogger<WeatherForecastFromApi3Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecastFromApi3")]
        public async Task<IEnumerable<WeatherForecast>> GetAsync()
        {
            // discover endpoints from metadata
            var client = new HttpClient();

            var disco = await client.GetDiscoveryDocumentAsync("https://server-devops:7000/Idp");
            /*if (disco.IsError)
            {
                //Console.WriteLine(disco.Error);
                return disco.Error;
            }*/

            // request token
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "api2.client",
                ClientSecret = "secret",

                Scope = "api3"
            });

            /*if (tokenResponse.IsError)
            {
                //Console.WriteLine(tokenResponse.Error);
                return tokenResponse.Error;
            }*/

            //Console.WriteLine(tokenResponse.Json);
            //Console.WriteLine("\n\n");

            // call api
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var response = await apiClient.GetFromJsonAsync<WeatherForecast[]>("https://server-devops:7000/Api3/WeatherForecast");

            return response;
        }
    }
}