using Microsoft.AspNetCore.Identity;
using RestauranteCodenation.Domain.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteCodenation.Data.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UsuarioRepositorio(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Incluir(string login, string email, string senha)
        {
            var user = new IdentityUser()
            {
                UserName = login,
                Email = email,
                EmailConfirmed = true
            };

            var retorno = await _userManager.CreateAsync(user, senha);

            //if (retorno.Succeeded)
            //{
            //    await _userManager.AddToRoleAsync(user, perfil);
            //}

            return retorno.Succeeded;
        }

        public async Task<IdentityUser> Login(string email, string senha)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user != null &&
                await _userManager.CheckPasswordAsync(user, senha))
            {
                return user;
            }

            return null;
        }
    }
}
