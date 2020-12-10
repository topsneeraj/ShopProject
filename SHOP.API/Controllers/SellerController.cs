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
     /// <summary>
     /// validate User Login
     /// </summary>
     /// <param name="username">Mand</param>
     /// <param name="password">Mand</param>
     /// <returns></returns>
        [HttpGet]
        [Route("validLogin")]
        public HttpResponseMessage validLogin(string username,string password)
        {
            if(username == "admin"&& password == "admin")
            {

                return Request.CreateResponse(HttpStatusCode.OK, TokenManager.GenerateToken(username));

            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, "invalid User name and password");

            }

        }
        /// <summary>
        /// Show All seller List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("sellerList")]
        [CustomAuthicationFilter]
        public HttpResponseMessage GetAllSellerList()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("status", "success");
            dic.Add("data", _unitOfworks.SellerRegistration.getAll());
          return  Request.CreateResponse(HttpStatusCode.OK, dic);
          
        }/// <summary>
        /// Show Seller Info By ID
        /// </summary>
        /// <param name="id">Mandory</param>
        /// <returns></returns>
        [Route("getDataById/{id}")]
        [HttpGet]
        public HttpResponseMessage GetDataById(int id)
        {
        
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("status", "success");
            dic.Add("data", _unitOfworks.SellerRegistration.getDataById(id));
            return Request.CreateResponse(HttpStatusCode.OK, dic);

        }
        /// <summary>
        /// Add seller Info
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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
