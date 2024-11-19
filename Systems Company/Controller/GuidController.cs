using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Systems_Company.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuidController : ControllerBase
    {
        private readonly CustomGuidGenerator _guidGenerator;

        public GuidController(CustomGuidGenerator guidGenerator)
        {
            _guidGenerator = guidGenerator;
        }

        [HttpGet("generate")]
        public IActionResult GenerateGuid()
        {
            var guid = _guidGenerator.GenerateGuid();
            return Ok(new { Guid = guid });
        }
  
    }
}
