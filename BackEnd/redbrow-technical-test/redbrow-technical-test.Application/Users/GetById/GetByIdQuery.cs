using AutoMapper;
using MediatR;
using redbrow_technical_test.Application.Users.GetAll;
using redbrow_technical_test.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redbrow_technical_test.Application.Users.GetById
{
    public class GetByIdQuery : IRequest<UserDto>
    {
        public Guid Id { get; set; }
    }

    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, UserDto>
    {
        private IUserQueryRepository _userQueryRepository;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(IUserQueryRepository userQueryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userQueryRepository = userQueryRepository;
        }

        public async Task<UserDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userQueryRepository.GetByIdAsync(request.Id);

            return _mapper.Map<UserDto>(user);
        }
    }
}
