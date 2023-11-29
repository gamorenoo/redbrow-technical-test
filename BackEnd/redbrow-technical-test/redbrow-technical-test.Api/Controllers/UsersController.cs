﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using redbrow_technical_test.Application.Users;
using redbrow_technical_test.Application.Users.Create;
using redbrow_technical_test.Application.Users.Delete;
using redbrow_technical_test.Application.Users.GetAll;
using redbrow_technical_test.Application.Users.GetById;
using redbrow_technical_test.Application.Users.GetPaginated;
using redbrow_technical_test.Application.Users.Update;
using redbrow_technical_test.Domain.Common;
using redbrow_technical_test.Domain.Users;

namespace redbrow_technical_test.Api.Controllers
{
    /// <summary>
    /// Controlador de usuairos
    /// </summary>
    [Authorize]
    [Route("api/")]
    public class UsersController : ApiControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="logger"></param>
        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Create([FromForm] CreateUserCommand createUserCommand)
        {
            return await Mediator.Send(createUserCommand);
        }

        [HttpPut]
        public async Task<ActionResult<UserDto>> Put([FromForm] UpdateUserCommand updateUserCommand)
        {
            return await Mediator.Send(updateUserCommand);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            return await Mediator.Send(new DeleteUserCommand() { Id = id });
        }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> Get()
        {
            return await Mediator.Send(new GetAllQuery());
        }

        [HttpGet("{id}")]
        public async Task<UserDto> Get(Guid id)
        {
            return await Mediator.Send(new GetByIdQuery() { Id = id });
        }

        [HttpGet("get-paginated")]
        public async Task<PaginatedResult<UserDto>> GetPaginated([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            return await Mediator.Send(new GetPaginatedQuery() { Page = page, PageSize = pageSize });
        }


    }
}
