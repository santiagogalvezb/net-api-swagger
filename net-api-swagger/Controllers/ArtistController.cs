using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using net_api_swagger.Domain;
using net_api_swagger.Infrastructure;

namespace net_api_swagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private DjCatalogDbContext _dbContext;

        public ArtistController(DjCatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> Get()
        {
            return await _dbContext.Artists.AsNoTracking().ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Artist>> CreateArtist(
            [FromBody] Artist artist
        )
        {
            _dbContext.Artists.Add(artist);
            await _dbContext.SaveChangesAsync();
            return StatusCode(201, artist);
        }
    }
}
