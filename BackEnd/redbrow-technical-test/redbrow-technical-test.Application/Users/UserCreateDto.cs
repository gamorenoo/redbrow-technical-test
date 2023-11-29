using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redbrow_technical_test.Application.Users
{
    public class UserCreateDto
    {
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
        [Required]
        public string Nationality { get; set; } = string.Empty;
    }
}
