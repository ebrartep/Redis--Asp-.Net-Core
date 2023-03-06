using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RedisExampleCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly IDatabase _database;
        public CacheController(IDatabase database)
        {
            _database = database;
        }

        //get api/<cachecontroller>/5
        [HttpGet]
        public string Get([FromQuery] string key)
        {
            return _database.StringGet(key);
        }

        // post api/<cachecontroller>
        [HttpPost]
        public void Post([FromBody] KeyValuePair<string, string> keyvalue)
        {
            _database.StringSet(keyvalue.Key, keyvalue.Value);

        }


    }
}
