using AutoMapper;
using MediatR;
using redbrow_technical_test.Application.Users.GetPaginated;
using redbrow_technical_test.Domain.Common;
using redbrow_technical_test.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redbrow_technical_test.Application.Users.Create
{
    public class CreateUserCommand: IRequest<UserDto>
    {
        public UserDto User { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private IUserCommandRepository _usercommandRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserCommandRepository usercommandRepository, IMapper mapper)
        {
            _mapper = mapper;
            _usercommandRepository = usercommandRepository;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = new User() { 
                Id = Guid.NewGuid(),
                Name = request.User.Name,
                Email = request.User.Email,
                Age = request.User.Age,
                Nationality = request.User.Nationality
            };

            user = await _usercommandRepository.CreateAsync(user);

            return _mapper.Map<UserDto>(user);

        }
    }
}
