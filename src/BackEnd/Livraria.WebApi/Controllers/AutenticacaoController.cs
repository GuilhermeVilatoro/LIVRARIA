using Microsoft.AspNetCore.Mvc;
using Livraria.Application.ViewModels;
using Livraria.Application.Services.Interfaces;
using Livraria.WebApi.Configurations;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.IdentityModel.Tokens.Jwt;
using System;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

namespace Livraria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class AutenticacaoController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public AutenticacaoController(IUsuarioService usuarioService) : base()
        {
            _usuarioService = usuarioService;
        }

        // POST: api/Autenticacao
        [HttpPost]
        [AllowAnonymous]
        public object PostAutenticacaoViewModel([FromBody] UsuarioViewModel usuarioViewModel,            
            [FromServices]SigningConfigurations signingConfigurations,
            [FromServices]TokenConfigurations tokenConfigurations)
        {
            bool credenciaisValidas = false;
            if (usuarioViewModel != null && !string.IsNullOrWhiteSpace(usuarioViewModel.Nome))
            {
                var usuarioBase = 
                    _usuarioService.GetAll().Where(u => u.Nome == usuarioViewModel.Nome).FirstOrDefault();
                credenciaisValidas = (usuarioBase != null &&
                    usuarioViewModel.Nome == usuarioBase.Nome &&
                    usuarioViewModel.Senha == usuarioBase.Senha);
            }

            if (credenciaisValidas)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(usuarioViewModel.Nome, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuarioViewModel.Nome)
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });

                var token = handler.WriteToken(securityToken);

                return new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                };
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }        
    }
}