using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using payback4marvin;
using payback4marvin.Model;

namespace payback4marvin.Controllers
{
    [EnableCors("*")]
    [Route("api/[controller]")]
    [ApiController]
    public class VergehenController : ControllerBase
    {
        private readonly PayBackContext _context;
 
        public VergehenController(PayBackContext context)
        {
            _context = context;
        }

        
    }
}