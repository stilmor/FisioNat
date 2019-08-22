using System;  
using System.Net;  
using System.Threading;  
//using System.Web.Http;
using Raist.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Raist.Controllers  
{
    /* 
    /// <summary>
    /// login controller class for authenticate users
    /// </summary>
    [AllowAnonymous]
    [System.Web.Http.Route("/loginController")]
    public class LoginController : ControllerBase
    {
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LoginRequest login)
        {
            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //TODO: Validate credentials Correctly, this code is only for demo !!
            bool isCredentialValid = (login.Password == "123456");
            if (isCredentialValid)
            {
                var token = TokenGenerator.GenerateTokenJwt(login.Username);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }
    }*/
}