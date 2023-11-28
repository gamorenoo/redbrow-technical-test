﻿using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redbrow_technical_test.Application.Auth.Login
{
    public class LoginQuery : IRequest<string>
    {
        public UserDto User { get; set; }
    }

    public class LoginQueryHandler : IRequestHandler<LoginQuery, string>
    {
        private readonly IAuthService _authService;

        public LoginQueryHandler(IApplicationDbContext context, IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var userVaid = _authService.Login(request.User.Email, request.User.Password);

            if (!userVaid)
            {
                throw new UnauthorizedAccessException("User or Password Invalid");
            }

            var token = _authService.GetToken(request.User.Email);

            return token;
        }
    }
}
