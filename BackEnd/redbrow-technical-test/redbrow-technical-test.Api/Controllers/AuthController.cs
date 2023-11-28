﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using redbrow_technical_test.Application.Auth.Login;

namespace redbrow_technical_test.Api.Controllers
{

    public class AuthController : ApiControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="logger"></param>
        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Iniciar sesion
        /// </summary>
        /// <param name="user">Usuario con Coreo y clave validos</param>
        /// <remarks>
        ///    POST /login
        ///    {"email": "gustavoamoreno@outlook.com","password": "0123456789"}
        /// </remarks>
        /// <returns>Token de sesión</returns>
        /// <response code="200">Token de sesión</response>
        /// <response code="401">No autorizado</response>
        [HttpPost("login", Name = "login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<string>> Login([FromBody] UserDto user)
        {
            return await Mediator.Send(new LoginQuery { User = user });
        }

    }
}
