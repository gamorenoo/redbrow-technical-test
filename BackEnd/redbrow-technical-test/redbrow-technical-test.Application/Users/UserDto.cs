using Application.Common.Mappings;
using redbrow_technical_test.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redbrow_technical_test.Application.Users
{
    public class UserDto : IMapFrom<User>
    {
        /// <summary>
        /// Identificador único del usuario.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        [Required]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Correo electrónico del usuario.
        /// </summary>
        [Required]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Edad del usuario.
        /// </summary>
        [Required]
        public int Age { get; set; }

        /// <summary>
        /// Nacionalidad del usuario.
        /// </summary>
        public string Nationality { get; set; } = string.Empty;
    }
}
