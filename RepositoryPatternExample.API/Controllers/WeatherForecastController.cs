using Microsoft.AspNetCore.Mvc;
using RepositoryPatternExample.API.Models;
using RepositoryPatternExample.API.Repository;
using System.Data.Entity;

namespace RepositoryPatternExample.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IGenericRepository<Product> _repository;
        private readonly IGenericRepository<WeatherForecast> _repository2;

        [HttpGet(Name = "Get")]
        public async Task<List<Product>> Get()
        {
            return await _repository.GetAll().ToListAsync();
        }

        [HttpGet(Name = "Add")]
        public async Task<List<Product>> Add()
        {
            var product = new Product
            {
                Name = "Deneme Ürün",
                Price = 19;
            };
            return await _repository.GetAll().ToListAsync();
        }
    }
}
