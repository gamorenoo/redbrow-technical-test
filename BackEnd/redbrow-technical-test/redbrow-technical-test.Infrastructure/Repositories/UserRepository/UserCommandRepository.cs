using Infrastructure.Repositories.GenericRepository.CommandRepository;
using redbrow_technical_test.Domain.Users;

namespace redbrow_technical_test.Infrastructure.Repositories.UserRepository
{
    public class UserCommandRepository: IUserCommandRepository
    {
        private readonly ICommandRepository<User> _userCommandRepository;

        public UserCommandRepository(ICommandRepository<User> userCommandRepository)
        {
            _userCommandRepository = userCommandRepository;
        }

        /// <inheritdoc/>
        public async Task<User> CreateAsync(User user)
        {
            return await _userCommandRepository.Add(user);
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(User user)
        {
            await _userCommandRepository.Delete(user);
        }

        /// <inheritdoc/>
        public async Task<User> UpdateAsync(User user)
        {
            return await _userCommandRepository.Update(user);
        }
    }
}
