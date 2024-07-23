using Microsoft.AspNetCore.Mvc;
using RepositoryPatternExample.API.Models;
using RepositoryPatternExample.API.Repository;
using RepositoryPatternExample.API.UnitOfWork;
using System.Data.Entity;

namespace RepositoryPatternExample.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IGenericRepository<Product> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public WeatherForecastController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet(Name = "Get")]
        public async Task<List<Product>> Get()
        {
            return await _repository.GetAll().ToListAsync();
        }

        [HttpPost(Name = "Add")]
        public async Task Add(Product model)
        {
            await _repository.AddAsync(model);
            await _unitOfWork.CompleteAsync();
        }
    }
}
