using AutoMapper;
using MediatR;
using redbrow_technical_test.Domain.Users;

namespace redbrow_technical_test.Application.Users.GetAll
{
    public class GetAllQuery : IRequest<IEnumerable<UserDto>>
    {

    }

    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<UserDto>>
    {
        private IUserQueryRepository _userQueryRepository;
        private readonly IMapper _mapper;

        public GetAllQueryHandler(IUserQueryRepository userQueryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userQueryRepository = userQueryRepository;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var listUser = await _userQueryRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<UserDto>>(listUser);
        }
    }
}
