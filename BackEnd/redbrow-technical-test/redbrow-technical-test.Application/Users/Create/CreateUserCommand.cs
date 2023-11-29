using AutoMapper;
using MediatR;
using redbrow_technical_test.Application.Common.Utilities;
using redbrow_technical_test.Domain.Users;
namespace redbrow_technical_test.Application.Users.Create
{
    public class CreateUserCommand: IRequest<UserDto>
    {
        public UserCreateDto User { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private IUserCommandRepository _userCommandRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserCommandRepository userCommandRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userCommandRepository = userCommandRepository;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            request.User.Email.ValidateEmail();

            User user = new User() { 
                Id = Guid.NewGuid(),
                Name = request.User.Name,
                Email = request.User.Email,
                Age = request.User.Age,
                Nationality = request.User.Nationality
            };

            user = await _userCommandRepository.CreateAsync(user);

            return _mapper.Map<UserDto>(user);

        }
    }
}
