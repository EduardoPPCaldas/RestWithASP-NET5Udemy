using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("/api/[controller]/v{version:ApiVersion}")]
    public class BookController : ControllerBase
    {

        private readonly ILogger<BookController> _logger;
        private IBookBusiness _bookBusiness;
        public BookController(ILogger<BookController> logger, IBookBusiness bookBusiness)
        {
            _logger = logger;
            _bookBusiness = bookBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());
        }

        [HttpGet("/{id}")]
        public IActionResult Get(long id)
        {
            if (!_bookBusiness.Exists(id))
            {
                return NotFound();
            }

            return Ok(_bookBusiness.FindById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]BookVO book)
        {
            if(book == null)
            {
                return BadRequest();
            }

            return Ok(_bookBusiness.Create(book));
        }

        [HttpPut]
        public IActionResult Put([FromBody]BookVO book)
        {
            if (book == null)
            {   
                return BadRequest();
            }

            return Ok(_bookBusiness.Update(book));
        }
    }
}
