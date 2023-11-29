using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redbrow_technical_test.Domain.Users
{
    public interface IUserCommandRepository
    {

        /// <summary>
        ///  Crear Usuario
        /// </summary>
        /// <returns></returns>
        Task<User> CreateAsync(User user);

        /// <summary>
        ///  Actualizar Usuario
        /// </summary>
        /// <returns></returns>
        Task<User> UpdateAsync(User user);

        /// <summary>
        /// Eliminar Usuario
        /// </summary>
        /// <returns></returns>
        Task DeleteAsync(User user);
    }
}
