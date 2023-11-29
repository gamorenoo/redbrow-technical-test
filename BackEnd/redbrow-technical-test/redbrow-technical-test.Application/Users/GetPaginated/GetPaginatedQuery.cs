using AutoMapper;
using MediatR;
using redbrow_technical_test.Application.Users.GetAll;
using redbrow_technical_test.Domain.Common;
using redbrow_technical_test.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redbrow_technical_test.Application.Users.GetPaginated
{
    public class GetPaginatedQuery : IRequest<PaginatedResult<UserDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

    public class GetPaginatedQueryHandler : IRequestHandler<GetPaginatedQuery, PaginatedResult<UserDto>>
    {
        private IUserQueryRepository _userQueryRepository;
        private readonly IMapper _mapper;

        public GetPaginatedQueryHandler(IUserQueryRepository userQueryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userQueryRepository = userQueryRepository;
        }

        public async Task<PaginatedResult<UserDto>> Handle(GetPaginatedQuery request, CancellationToken cancellationToken)
        {
            var listUser = await _userQueryRepository.GetPaginated(request.Page,request.PageSize);

            var listUserDto = _mapper.Map<IEnumerable<UserDto>>(listUser);

            return new PaginatedResult<UserDto>
            {
                Data = listUserDto,
                Page = request.Page,
                PageSize = request.PageSize,
                Count = listUserDto.Count()
            };
        }
    }

}
