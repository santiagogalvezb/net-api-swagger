using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using net_api_swagger.Domain;
using net_api_swagger.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace net_api_swagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private DjCatalogDbContext _dbContext;

        public CountryController(DjCatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> Get()
        {
            return await _dbContext.Countries.AsNoTracking().ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Country>> CreateCountry(
            [FromBody] Country country
        )
        {
            _dbContext.Countries.Add(country);
            await _dbContext.SaveChangesAsync();
            return StatusCode(201, country);
        }
    }
}
