using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using IISI.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VoxelmapsTask1WebApp.Models;

namespace VoxelmapsTask1WebApp.Controllers
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
        private readonly IRequestService _clientFactory;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IRequestService clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

       

    
       

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("Covid")]
        public async Task<ActionResult<dynamic>> GetCovidInfoAsync()
        {

            CovidResponse PullRequests = new CovidResponse();

            PullRequests = await _clientFactory.GetAsync<CovidResponse>("https://services1.arcgis.com/0MSEUqKaxRlEPj5g/arcgis/rest/services/ncov_cases2_v1/FeatureServer/2/query?where=1%3D1&outFields=Country_Region,Lat,Long_,Confirmed,Deaths,Recovered,UID,ISO3&returnGeometry=false&outSR=4326&f=json");


            return Ok(PullRequests);
        }
    }
}
