﻿using System;
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
            new Record("Kono Andu Da!", "Andu", 29.4, 2018),
            new Record("Hoarchim Da!", "Roachim", 56.3, 2000),
            new Record("Kono Nikolairu da!", "Nikolai", 30, 2019)
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

        [HttpGet]
        [Route("Search")]
        public List<Record> SearchForTitle([FromQuery] Record record)
        {
            return _manager.GetByTitle(record.Title);
        }

        [HttpGet]
        [Route("Title/{title}")]
        public List<Record> SearchTitleTest(string title)
        {
            return _manager.GetByTitle(title);
        }

        // POST: api/Records
        [HttpPost]
        public void Post([FromBody] Record value)
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
            //hejsa
        }
    }
}
