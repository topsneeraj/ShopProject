using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SHOP.PL.Controllers
{
    public class SellerController : Controller
    {
        // GET: Seller
        static string BaseAddressUrl = "https://localhost:44360/";
        public async Task <ActionResult> Index()
        {
            var tokenbased = string.Empty;
            using(var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(BaseAddressUrl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(mediaType: "application/json"));
                var responcesMessage = await client.GetAsync(requestUri: "Seller/validLogin/?username=admin&password=admin");
                if(responcesMessage.IsSuccessStatusCode)
                {
                    var resultMessage = responcesMessage.Content.ReadAsStringAsync().Result;
                    tokenbased = JsonConvert.DeserializeObject<string>(resultMessage);
                    Session["TokenNumber"] = tokenbased;
                    Session["UserName"] = "admin";

                }



            }

            return Content(tokenbased);
        }

        public async Task< ActionResult> GetAllSeller()
        {
            //string ReturnMessage = string.Empty;
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(BaseAddressUrl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(mediaType: "application/json"));
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(scheme: "Bearer", parameter: Session["TokenNumber"].ToString() +":"+Session["UserName"].ToString());

                var responcesMessage = await client.GetAsync(requestUri: "Seller/sellerList/");
                if(responcesMessage.IsSuccessStatusCode)
                {
                    var resultMessage = responcesMessage.Content.ReadAsStringAsync().Result;
                  var  ReturnMessage = JsonConvert.DeserializeObject<Dictionary<string, string>>(resultMessage);
                    ViewBag.data = ReturnMessage;

                }

                return View();
                
            }
        }
    }
}