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
    public class SongController : ControllerBase
    {
        private DjCatalogDbContext _dbContext;
        public SongController(DjCatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> Get()
        {
            return await _dbContext.Songs.AsNoTracking().ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Artist>> CreateSong(
            [FromBody] Song song
        )
        {
            _dbContext.Songs.Add(song);
            await _dbContext.SaveChangesAsync();
            return StatusCode(201, song);
        }
    }
}
