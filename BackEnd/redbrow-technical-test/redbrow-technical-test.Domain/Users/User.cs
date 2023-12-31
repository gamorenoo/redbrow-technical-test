﻿using redbrow_technical_test.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace redbrow_technical_test.Domain.Users
{
    /// <summary>
    /// Usuario del sistema
    /// </summary>
    public class User: AuditableEntity
    {
        /// <summary>
        /// Identificador único del usuario.
        /// </summary>
        public Guid Id { get; set; }

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
