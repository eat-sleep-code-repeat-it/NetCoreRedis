using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreRedis.Models;
using NetCoreRedis.Services;

namespace NetCoreRedis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisBooksController : ControllerBase
    {
        private readonly RedisService _redisService;
        public RedisBooksController(RedisService redisService) {
            _redisService = redisService;
        }

        [HttpGet("server/endpoints")]
        public ActionResult GetEndPoints()
        {
            return Ok(_redisService.GetEndPoints());
        }

        [HttpGet("server/lastsave")]
        public ActionResult GetLastSave()
        {
            return Ok(_redisService.GetLastSave());
        }
        [HttpGet("server/memstats")]
        public ActionResult GetSeverInfo()
        {
            return Ok(_redisService.MemoryStats());
        }

        [HttpGet("server/clientlist")]
        public ActionResult ClientList()
        {
            return Ok(_redisService.ClientList());
        }





        /// <summary>
        /// Get book by ISBN from Redis
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        [HttpGet("{isbn}")]
        public async Task<Book> Get(string isbn = "9781617290855")
        {
            // ISBN 9781617290855
            var sISBN = await _redisService.Get("book:ISBN");
            var sTitle = await _redisService.Get($"{isbn}:TITLE");
            return new Book() { ISBN = sISBN, Title = sTitle };
        }

        /// <summary>
        /// Post book with ISBN and Title to Redis
        /// </summary>
        /// <param name="isbn"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Book> Post(string isbn = "9781617290855", string title = "Redis in Action")
        {
            // ISBN 9781617290855
            await _redisService.Set("book:ISBN", $"{isbn}");
            await _redisService.Set($"{isbn}:TITLE", $"{title}");
            var sISBN = await _redisService.Get("book:ISBN");
            var sTitle = await _redisService.Get($"{isbn}:TITLE");            
            return new Book() { ISBN = sISBN, Title = sTitle };
        }
    }
}