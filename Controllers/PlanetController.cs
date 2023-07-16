using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{

    public class PlanetController : Controller

    {
        private readonly PlanetService _planetService;
        private readonly ILogger<PlanetController> _logger;

        public PlanetController(PlanetService planetService, ILogger<PlanetController> logger)
        {
            _planetService = planetService;
            _logger = logger;
        }
        [Route("danh-sach-cach")]
        public IActionResult Index()
        {
            return View();
        }
        [BindProperty(SupportsGet = true,Name = "action")]
        public string Name {get;set;}
        public IActionResult Mercury(){
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail",planet);
        }
        public IActionResult Venus(){
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail",planet);
        }
        public IActionResult Earth(){
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail",planet);
        }
        public IActionResult Mars(){
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail",planet);
        }
        public IActionResult Jupiter(){
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail",planet);
        }
        public IActionResult Saturn(){
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail",planet);
        }
        public IActionResult Uranus(){
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail",planet);
        }
        // [Route("ten duong dan")] khi co cac [controller] [action] [area] thi phai co cacs [controller] [action] [area] sau duong dan thi moi co the truy cap vao cac trang 
        // khi co nhieu cac route thi co the truy cap vao trang tu bat ki route da tao
        //con he thong se tu lua chon cac route da tao de tu generator cac duong dan cho anchor tag 
        [Route("sao/[action]", Order = 3, Name = "neptune1")]
        [Route("sao/[controller]/[action]",Order = 3, Name = "neptune2")]
        [Route("sao/[controller]-[action].html",Order = 3, Name = "neptune3")]

        public IActionResult Neptune(){
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail",planet);
        }
        [Route("hanh-tinh/{id:int}")]   
        public IActionResult PlanetInfo(int id){
            var planet = _planetService.Where(p => p.Id == id ).FirstOrDefault();
            return View("Detail",planet);
        }
    }
}