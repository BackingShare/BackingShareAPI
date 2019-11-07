using Backing_Share___API.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backing_Share___API.Controllers
{
    [Route("[controller]")]
    public class AudioController : Controller
    {
        private IAudioHelper _audioHelper;
        

        public AudioController(IAudioHelper audioHelper)
        {
            _audioHelper = audioHelper;
        }
        // GET: Audio


        // GET: Audio/Details/5

        [HttpPost]
        public ActionResult Create(string location)
        {
            _audioHelper.CreateAsync(location);
            return Ok();
        }

        [HttpGet]
        public ActionResult Get()
        {
            _audioHelper.GetAsync();
            return Ok();
        }

        public ActionResult DownloadFile(string filename, string location)
        {
            _audioHelper.DownloadFile(filename, location);
            return Ok();
        }

        public Task<List<string>> GetAll()
        {
            Task<List<string>> audios = _audioHelper.GetAllAsync();
            return audios;
        }



        // POST: Audio/Create



    }
}