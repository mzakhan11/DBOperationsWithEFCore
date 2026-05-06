using DBOperationsWithEFCoreApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DBOperationsWithEFCoreApp.Controllers
{
    [Route("api/currencies")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDBContext _appDBContext;

        public CurrencyController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCurrencies()
        {
            //var result = _appDBContext.Currencies.ToList();

            //var result = (from currencies in _appDBContext.Currencies
            //              select currencies).ToList();

            //var result = await _appDBContext.Currencies.ToListAsync();
            var result = await (from currencies in _appDBContext.Currencies
                                select currencies).ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCurrencyByIdAsync([FromRoute] int id)
        {
            
            var result = await _appDBContext.Currencies.FindAsync(id);

            //var result = await (from currencies in _appDBContext.Currencies
            //                    select currencies).ToListAsync();

            return Ok(result);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetCurrencyByNameAsync([FromRoute] string name, [FromQuery] string? description)
        {

            //var result = await _appDBContext.Currencies
            //    .FirstOrDefaultAsync(x =>
            //    x.Title == name
            //    && (string.IsNullOrEmpty(description) || x.Description == description)
            //    );

            var result = await _appDBContext.Currencies
                .Where(x =>
                x.Title == name
                && (string.IsNullOrEmpty(description) || x.Description == description)
                ).ToListAsync();

            //var result = await (from currencies in _appDBContext.Currencies
            //                    select currencies).ToListAsync();

            return Ok(result);
        }

        [HttpPost("all")]
        public async Task<IActionResult> GetCurrenciesByIdsAsync([FromBody] List<int> ids)
        {
            //var ids = new List<int> {1,6,3,4};
            var result = await _appDBContext.Currencies
               .Where(x => ids.Contains(x.Id))                
               .ToListAsync();

            return Ok(result);
        }
    }
}
