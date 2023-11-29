using Application.Common.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using redbrow_technical_test.Application.Users.Update;
using redbrow_technical_test.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redbrow_technical_test.Application.Users.Delete
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private IUserCommandRepository _usercommandRepository;
        private IUserQueryRepository _userQueryRepository;

        public DeleteUserCommandHandler(IUserCommandRepository usercommandRepository,
            IUserQueryRepository userQueryRepository)
        {
            _usercommandRepository = usercommandRepository;
            _userQueryRepository = userQueryRepository;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userQueryRepository.GetByIdAsync(request.Id);

            if (user is null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            await _usercommandRepository.DeleteAsync(user);

            return true;
        }
    }
}
