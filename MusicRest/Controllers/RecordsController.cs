using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLib;
using MusicRest.DBUtil;

namespace MusicRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        #region Manager

        private RecordManager _manager = new RecordManager();

        #endregion

        private static readonly List<Record> records = new List<Record>()
        {
            new Record("Kono Andu da!", "Andu", 420.69, 2018, "Andus største hits"),
            new Record("Kono Hoarchim da!", "Hoarchim", 380.69, 2012, "Hoarchims største hits"),
            new Record("Kono Nikolai da!", "Nikolai", 400.69, 2018, "Nikolais største hits")
        };

        // GET: api/Records
        [HttpGet]
        public IEnumerable<Record> Get()
        {
            return _manager.Get();
        }

        // GET: api/Records/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("{search}")]
        public List<Record> SearchForTitle([FromQuery] Record value)
        {
            List<Record> tempRecords = new List<Record>();

            
            

            if (!string.IsNullOrEmpty(value.Title))
            {
                foreach (Record record in records.FindAll(r => r.Title.Contains(value.Title)))
                {
                    tempRecords.Add(record);
                }
            }

            return tempRecords;
        }

        // POST: api/Records
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Records/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
