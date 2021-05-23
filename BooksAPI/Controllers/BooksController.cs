using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using BooksAPI.Servicios;
using BooksAPI.Servicios.Entidades;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BooksAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //
        // GET: api/<BooksController>
        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await BooksService.Get();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Book>> Get(int id)
        {
            return await BooksService.Get(id);
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<string> Post([FromBody] Book book)
        {
            return await BooksService.Post(book);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public async Task<string> Put(int id, [FromBody] Book book)
        {
            return await BooksService.Put(book);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            return await BooksService.Delete(id);
        }
    }
}
