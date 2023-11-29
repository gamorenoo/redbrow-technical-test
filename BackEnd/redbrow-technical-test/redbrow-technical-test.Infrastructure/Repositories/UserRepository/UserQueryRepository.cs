using Infrastructure.Repositories.GenericRepository.QueryRepository;
using Microsoft.EntityFrameworkCore;
using redbrow_technical_test.Domain.Common;
using redbrow_technical_test.Domain.Users;

namespace redbrow_technical_test.Infrastructure.Repositories.UserRepository
{
    public class UserQueryRepository : IUserQueryRepository
    {
        private readonly IQueryRepository<User> _userQueryyRepository;

        public UserQueryRepository(IQueryRepository<User> userQueryyRepository)
        {
            _userQueryyRepository = userQueryyRepository;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userQueryyRepository.GetList();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            var prperties = await _userQueryyRepository.GetList(x => x.Id == id);

            return prperties.FirstOrDefault();
        }

        public async Task<IEnumerable<User>> GetPaginated(int page, int pageSize)
        {
            return await _userQueryyRepository.GetAll()
                .Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }
    }
}
