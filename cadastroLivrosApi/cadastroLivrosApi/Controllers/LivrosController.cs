using cadastroLivrosApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadastroLivrosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private ILivrosService _livrosService;

        public LivrosController(ILivrosService livrosService)
        {
            _livrosService = livrosService;
        }
    }
}
