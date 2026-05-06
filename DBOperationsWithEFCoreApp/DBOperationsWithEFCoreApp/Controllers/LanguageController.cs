using DBOperationsWithEFCoreApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBOperationsWithEFCoreApp.Controllers
{
    [Route("api/languages")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly AppDBContext _appDBContext;

        public LanguageController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllLanguages()
        {
            var result = await (from languages in _appDBContext.Languages
                                select languages).ToListAsync();
            return Ok(result);
        }
    }
}
