using redbrow_technical_test.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redbrow_technical_test.Domain.Users
{
    public interface IUserQueryRepository
    {
        /// <summary>
        /// Obtener la lista de usuarios
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<User>> GetAllAsync();

        /// <summary>
        /// Obtener un suaurio por su Identificador único
        /// </summary>
        /// <returns></returns>
        Task<User?> GetByIdAsync(Guid id);

        /// <summary>
        /// Obtener la lista de usuarios paginados
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<User>> GetPaginated(int page, int pageSize);
    }
}
