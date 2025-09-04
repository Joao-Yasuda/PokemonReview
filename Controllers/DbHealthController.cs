using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;

namespace Pokemon_Review_App.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class DbHealthController : ControllerBase
    {
        private readonly OracleConnection _conn;
        public DbHealthController(OracleConnection conn) => _conn = conn;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _conn.OpenAsync();
            using var cmd = _conn.CreateCommand();
            cmd.CommandText = "SELECT 'OK' AS status FROM dual";
            var result = (await cmd.ExecuteScalarAsync())?.ToString();
            return Ok(new { db = result });
        }
    }