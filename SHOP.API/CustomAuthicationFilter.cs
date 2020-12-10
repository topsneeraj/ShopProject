using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace SHOP.API
{
    public class CustomAuthicationFilter : AuthorizeAttribute, IAuthenticationFilter
    {
        public bool allowMutiple
        {
            get { return false; }
        }

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            string[] TokenUser = null;
            string authParmiter = string.Empty;
            HttpRequestMessage request = context.Request;
            AuthenticationHeaderValue authtication = request.Headers.Authorization;
           
            if(authtication == null)
            {
                context.ErrorResult = new AutheticationFailureResult("Misssing Authorization Header", request);
                return;
            }
            if(authtication.Scheme != "Bearer")
            {
                context.ErrorResult  =  new AutheticationFailureResult("Invalid Authorization Schema", request);
                return;
            }
            TokenUser = authtication.Parameter.Split(':');
            var Token = TokenUser[0];
            var User = TokenUser[1];
            var validateUser = TokenManager.ValidateToken(Token);
            if(String.IsNullOrEmpty(Token))
            {
                context.ErrorResult = new AutheticationFailureResult("Missing Token", request);

                return;
            }
            if(validateUser!=User)
            {
                context.ErrorResult = new AutheticationFailureResult("Invalid User Name", request);

                return;
            }

            context.Principal = TokenManager.GetPrincipal(authtication.Parameter);

        }

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            var result = await context.Result.ExecuteAsync(cancellationToken);
            if(result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                result.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(scheme: "Basic", parameter: "realm=localhost"));

            }
            context.Result = new ResponseMessageResult(result);
        }
    }

    public class AutheticationFailureResult : IHttpActionResult
    {
        public string ResionPhrese;
        public HttpRequestMessage request { get; set; }

        public AutheticationFailureResult(string _ResionPhrese,HttpRequestMessage _request)
        {
            ResionPhrese = _ResionPhrese;
            request = _request;

        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());

        }
        public HttpResponseMessage Execute()
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            responseMessage.RequestMessage = request;
            responseMessage.ReasonPhrase = ResionPhrese;
            return responseMessage;
        }
    }
}