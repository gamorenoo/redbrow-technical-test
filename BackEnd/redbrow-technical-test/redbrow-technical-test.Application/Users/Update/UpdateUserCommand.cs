using MediatR;
using AutoMapper;
using Application.Common.Exceptions;
using redbrow_technical_test.Domain.Users;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using redbrow_technical_test.Application.Common.Utilities;

namespace redbrow_technical_test.Application.Users.Update
{
    public class UpdateUserCommand : IRequest<UserDto>
    {
        public UserDto User { get; set; }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDto>
    {
        private IUserCommandRepository _usercommandRepository;
        private IUserQueryRepository _userQueryRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserCommandRepository usercommandRepository, 
            IUserQueryRepository userQueryRepository, 
            IMapper mapper)
        {
            _mapper = mapper;
            _usercommandRepository = usercommandRepository;
            _userQueryRepository = userQueryRepository;
        }

        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userQueryRepository.GetByIdAsync(request.User.Id.Value);

            if (user is null) {
                throw new NotFoundException(nameof(User), request.User.Id);
            }

            request.User.Email.ValidateEmail();

            user.Name = request.User.Name;
            user.Age = request.User.Age;
            user.Email = request.User.Email;
            user.Nationality = request.User.Nationality;

            user = await _usercommandRepository.UpdateAsync(user);

            return _mapper.Map<UserDto>(user);

        }
    }
}
