using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/chess")]
    public class ChessController : ControllerBase
    {
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok();
        }

        [HttpGet("startGame")]
        public IActionResult StartGame()
        {
            return Ok();
        }
    }
}
