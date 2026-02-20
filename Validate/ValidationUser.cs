using Evolve_Game.Context;
using Evolve_Game.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Evolve_Game.Validate
{
    public class ValidationUser
    {
        public string ValidateRegister(string email, string senha, string nickname, ApiDbContext _context)
        {
            // Validações
            if (ValidarEmail(email, _context))
            {
                return "Email já foi cadastrado";
            }

            if (!ValidarSenha(senha))
            {
                return "Senha Invalida, use caracteres minúsculos, maiúsculos, número e caracter especial com no mínimo 8 dígitos.";
            }

            if (_context.Users.Any(p => p.Name == nickname))
            {
                return "Nickname do player já é cadastrado";
            }

            return "";
        }
        public string ValidateLogin(string Name, string Password, ApiDbContext _context)
        {
            User user = _context.Users.FirstOrDefault(u => u.Name == Name);
            if (user == null)
                return "Usuário não encontrado";
            if(!BCrypt.Net.BCrypt.Verify(Password, user.Password))
                return "Usuário Senha incorreta";

            return "";

        }
        private bool ValidarEmail(string email, ApiDbContext context)
        {
            try
            {
                MailAddress m = new MailAddress(email);

                if (context.Users.Any(usuario => usuario.Email == email))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return true;
            }
        }



        private bool ValidarSenha(string senha)
        {
            try
            {
                var pattern = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[$*&@#])[A-Za-z\\d$*&@#]{8,}$";
                if (Regex.IsMatch(senha, pattern))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return true;
            }
        }
    }
}
