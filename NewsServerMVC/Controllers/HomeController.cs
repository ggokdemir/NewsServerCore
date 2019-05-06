using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsServerMVC.Data;
using NewsServerMVC.Models;

namespace NewsServerMVC.Controllers
{
    
    public class HomeController : Controller // ControllerBase
    {
        //[Route("/[controller]")]C:\Users\Kan\Desktop\NewsServerMVC\NewsServerMVC\Data\DataAccess.cs
        public IActionResult Index(NewsModel news)
        {
            if (news.newsId != 0 && Param.newsAddList.Contains(news) != true)
            {
            news.newsDate = DateTime.Now;
            Param.newsAddList.Add(news);
            RequestProcess.CreateNews(news.newsId, news.newsTitle, news.newsContent, news.newsTopic, news.newsImage, news.newsDate);
            }
            return View();
        }

        public IActionResult Added()
        {
           
            return View(Param.newsAddList);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        //// GET: api/<controller>
        //[Route("api/[controller]")]
        //[HttpGet]
        //[Produces("application/json")]
        //public IEnumerable<string> Get()
        //{
        //    //return new string[] { "value1", "value2" };
        //    return new string[] { Regex.Unescape(RequestProcess.Serializer(RequestProcess.LoadValues()).Replace(@"\\", "")) };
        //}

        // GET: api/<controller>
        [Route("api/[controller]")]
        [HttpGet]
        [Produces("application/json")]
        public IActionResult Get()
        {
            //return new string[] { "value1", "value2" };
            return Ok(new string[] { RequestProcess.Serializer(RequestProcess.LoadValues()) });
        }

        // GET api/<controller>/5
        [Route("api/[controller]/id={id}")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new string[] { RequestProcess.Serializer(RequestProcess.LoadValuesInt(id)) });
        }

        // GET api/<controller>/World
        [Route("api/[controller]/query={query}")]
        [HttpGet("{query}")]
        public IActionResult Get(string query)
        {
            return Ok(new string[] { RequestProcess.Serializer(RequestProcess.LoadValuesString(query)) });
            // return Ok(new Value { newsId=id , newsContent="value"+id});
        }

        // GET api/Rate/<controller>
        [Route("api/rate/[controller]/id={id}")]
        [HttpGet("{id}")]
        public IActionResult GetInfo(int id)
        {
            return Ok(new string[] { RequestProcess.SerializerRate(RequestProcess.LoadValuesRate(id)) });
            // return Ok(new Value { newsId=id , newsContent="value"+id});
        }

        // POST api/<controller>
        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult Post([FromBody]NewsModel value)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            //save the value to the DB
            return CreatedAtAction("Get", new { id = value }, value);
        }

        // PUT api/<controller>/5
        [Route("api/[controller]")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [Route("api/[controller]")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [Route("api/static/[controller]")]
        [HttpGet]
        [Produces("application/json")]
        public IEnumerable<string> GetStatic()
        {
            return new string[] { "{\"newsId\":3,\"newsTitle\":\"A shocking high school massacre \",\"newsTopic\":\"Education\",\"newsDate\":\"2018-02-16T00:00:00\"}", "{\"newsId\":4,\"newsTitle\":\"Horrific Texas school shooting kills 10 \",\"newsImage\":null,\"newsContent\":null,\"newsTopic\":\"Education\",\"newsDate\":\"2018-05-19T00:00:00}" };
        }
    }
}

