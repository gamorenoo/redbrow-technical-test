using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace redbrow_technical_test.Application.Common.Utilities
{
    public static class EmailUtilities
    {
        /// <summary>
        /// Valida si la cadena proporcionada es un correo electrónico válido.
        /// </summary>
        /// <param name="email">Cadena que representa una dirección de correo electrónico.</param>
        /// <returns>La cadena si es un correo electrónico válido.</returns>
        /// <exception cref="InvalidInformationException">Se lanza cuando la cadena no es un correo electrónico válido.</exception>
        public static string ValidateEmail(this string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ValidationException("La dirección de correo electrónico no puede estar vacía.");
            }

            try
            {
                // Utiliza la clase Regex para validar el formato del correo electrónico
                var emailRegex = new Regex(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$");

                if (emailRegex.IsMatch(email))
                {
                    return email;
                }
                else
                {
                    throw new ValidationException("La dirección de correo electrónico no es válida.");
                }
            }
            catch (RegexMatchTimeoutException)
            {
                throw new ValidationException("Error al validar la dirección de correo electrónico.");
            }
        }
    }
}
