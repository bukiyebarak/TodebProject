using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApıMVC.Models;
using Newtonsoft.Json;

namespace WebApıMVC.Controllers
{
    public class ApartmentController : Controller
    {
        Uri baseAdress=new Uri("http://localhost:5000/api");
        HttpClient client;
        public ApartmentController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAdress;
        }
        public ActionResult Index()
        {
            List<ApartmentViewModel> apartmentViewModels = new List<ApartmentViewModel>();
            HttpResponseMessage responseMessage = client.GetAsync(client.BaseAddress + "/apartment").Result;
            if(responseMessage.IsSuccessStatusCode)
            {
                string data = responseMessage.Content.ReadAsStringAsync().Result;
                apartmentViewModels = JsonConvert.DeserializeObject<List<ApartmentViewModel>>(data);
            }
            return View(apartmentViewModels);
        }
    }
}