using App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AppMvc.net.Controllers{
    public class FirstController : Controller{
        ILogger<FirstController> _logger {get;set;}
        ProductService _productservice {get;set;}
        public FirstController(ILogger<FirstController> logger,ProductService productservice){
            _logger = logger;
            _productservice = productservice;
        }

        public IActionResult Privacy(){
            var url = Url.Action("Privacy","Home");
            _logger.LogInformation("Chyen huong den privacy");
            return LocalRedirect(url);
        }
        public IActionResult Google(){
            var url = "https://google.com";
            _logger.LogInformation ("Chyen huong den " + url);
            return Redirect(url);
        }
        public IActionResult HelloView(string username){
            if(string.IsNullOrEmpty(username)){
                username = "Khach";
            }
            // View(template) - template duong dan tuyet doi .cshtml
            // View(template.model)
           // return View("/MyView/xinchao1.cshtml",username);
            

            //neu khong co duong dan tuyet doi thi no se tim file cshtml trong thu muc View/First/xinchao2.cshtml
            // return View("xinchao2",username);
            //neu khong co doi so no se tim file trong view giong voi ten cua action 
            
            // return View((object)username);


            return View("xinchao3",username);
        }
        // [AcceptVerbs("POST")] chi dung phuong thu post moi co the truy cap vao view
        public IActionResult ViewProduct(int? id){
            var product = _productservice.Where(p => p.Id == id).FirstOrDefault();
            if(product == null) return NotFound();
            return View(product);


            //  co the dung ViewData de truyen model

            // this.ViewData["Product"] = product;
            // return View("ViewProduct2");
        }
    }
}