using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redbrow_technical_test.Application.Auth.Login
{
    /// <summary>
    /// Dto para el login en la Aplicación
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Correo electrónico
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Constraseña
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
