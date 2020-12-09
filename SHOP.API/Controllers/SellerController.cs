using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SHOP.Repo;
using SHOP.DL;
namespace SHOP.API.Controllers
{
    [RoutePrefix("Seller")]
    public class SellerController : ApiController
    {
        IUnitOfWork _unitOfworks = new UnitOfWork(new ShopEntity());
        [HttpGet]
        [Route("sellerList")]
        public HttpResponseMessage GetAllSellerList()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("status", "success");
            dic.Add("data", _unitOfworks.SellerRegistration.getAll());
          return  Request.CreateResponse(HttpStatusCode.OK, dic);
          
        }
        [Route("getDataById")]
        [HttpGet]
        public HttpResponseMessage GetDataById(int id)
        {
        
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("status", "success");
            dic.Add("data", _unitOfworks.SellerRegistration.getDataById(id));
            return Request.CreateResponse(HttpStatusCode.OK, dic);

        }
        [Route("AddSeller")]
        [HttpPost]
        public HttpResponseMessage AddSeller(SellerRegistration obj)
        {
            try
            {
                _unitOfworks.SellerRegistration.addEntity(obj);
                _unitOfworks.complete();
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("status", "success");
                return Request.CreateResponse(dic);
            }
            catch(Exception ex)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("status", ex.Message);
                return Request.CreateResponse(dic);
            }

        }
    }
}
