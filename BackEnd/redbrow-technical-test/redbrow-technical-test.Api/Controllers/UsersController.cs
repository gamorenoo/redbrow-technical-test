using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using redbrow_technical_test.Application.Users;
using redbrow_technical_test.Application.Users.GetAll;
using redbrow_technical_test.Application.Users.GetById;
using redbrow_technical_test.Application.Users.GetPaginated;
using redbrow_technical_test.Domain.Common;
using redbrow_technical_test.Domain.Users;

namespace redbrow_technical_test.Api.Controllers
{
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
