using Microsoft.AspNetCore.Authorization;
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
    [Route("api/user/")]
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

        /// <summary>
        /// Crear usuario
        /// </summary>
        /// <param name="createUserCommand"></param>
        /// <returns>Usuario creado</returns>
        /// <response code="200">Usuario Creado</response>
        /// <response code="401">No autorizado</response>
        /// <response code="500">Error interno del servidor</response>
        /// <response code="400">Request invalido</response>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<UserDto>> Create([FromForm] CreateUserCommand createUserCommand)
        {
            return await Mediator.Send(createUserCommand);
        }

        /// <summary>
        /// Actualizar usuario
        /// </summary>
        /// <param name="updateUserCommand"></param>
        /// <returns>Usuario creado</returns>
        /// <response code="200">Usuario Actualizado</response>
        /// <response code="401">No autorizado</response>
        /// <response code="500">Error interno del servidor</response>
        /// <response code="400">Request invalido</response>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<ActionResult<UserDto>> Put([FromForm] UpdateUserCommand updateUserCommand)
        {
            return await Mediator.Send(updateUserCommand);
        }

        /// <summary>
        /// Eliminar usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Bandera que indica si se elimina el usuario o no</returns>
        /// <response code="200">Usuario Actualizado</response>
        /// <response code="401">No autorizado</response>
        /// <response code="500">Error interno del servidor</response>
        /// <response code="400">Request invalido</response>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            return await Mediator.Send(new DeleteUserCommand() { Id = id });
        }

        /// <summary>
        /// Obtener usuarios
        /// </summary>
        /// <returns>lista de usuarios registrados</returns>
        /// <response code="200">Lista de Usuarios</response>
        /// <response code="401">No autorizado</response>
        /// <response code="500">Error interno del servidor</response>
        /// <response code="400">Request invalido</response>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IEnumerable<UserDto>> Get()
        {
            return await Mediator.Send(new GetAllQuery());
        }

        /// <summary>
        /// Obtener usuario por Id
        /// </summary>
        /// <returns>Usuarios que coincide</returns>
        /// <response code="200">Usuario</response>
        /// <response code="401">No autorizado</response>
        /// <response code="500">Error interno del servidor</response>
        /// <response code="400">Request invalido</response>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<UserDto> Get(Guid id)
        {
            return await Mediator.Send(new GetByIdQuery() { Id = id });
        }

        /// <summary>
        /// Obtener usuarios paginados
        /// </summary>
        /// <returns>lista de usuarios registrados en la pagina indicada</returns>
        /// <response code="200">Usuarios paginados</response>
        /// <response code="401">No autorizado</response>
        /// <response code="500">Error interno del servidor</response>
        /// <response code="400">Request invalido</response>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("get-paginated")]
        public async Task<PaginatedResult<UserDto>> GetPaginated([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            return await Mediator.Send(new GetPaginatedQuery() { Page = page, PageSize = pageSize });
        }


    }
}
