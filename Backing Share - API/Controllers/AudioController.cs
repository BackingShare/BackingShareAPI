using Backing_Share___API.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Backing_Share___API.Controllers
{
    [Route("[controller]")]
    public class AudioController : Controller
    {
        private IAudioHelper _audioHelper;
        private IConfiguration _configuration;

        public AudioController(IAudioHelper audioHelper, IConfiguration configuration)
        {
            _audioHelper = audioHelper;
            _configuration = configuration;
        }
        // GET: Audio


        // GET: Audio/Details/5

        // GET: Audio/Create
        //public ActionResult Create()
        //{
        //    _audioHelper.CreateAsync(_configuration);
        //    return Ok();
        //}

        public ActionResult Get()
        {
            _audioHelper.GetAsync();
            return Ok();
        }

        // POST: Audio/Create



    }
}