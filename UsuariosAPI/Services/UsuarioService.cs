using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosAPI.Models;
using UsuariosAPI.Models.DTO;

namespace UsuariosAPI.Services
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager; //possui diversos metodos para o geneciamento de usuario //serve para cadastrar usuario
        private SignInManager<IdentityUser<int>> _signInManager; //serve para fazer login

        public UsuarioService(IMapper mapper, UserManager<IdentityUser<int>> userManager, SignInManager<IdentityUser<int>> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public bool cadastrarUsuario(CreateUsuarioDto usuarioDto)
        {
            //passando os dados do DTO para o usuario
            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);

            //passando os dados do usuario para o identity
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);

            //obtem o resultado da criação    //criando o usuario no identity
            Task<IdentityResult> resultado = _userManager.CreateAsync(usuarioIdentity, usuarioDto.Password);

            if (resultado.Result.Succeeded)
            {
                return true;
            }
            return false;
        }

        public Result logarUsuario(Login login)
        {
            var resultado = _signInManager.PasswordSignInAsync(login.Username, login.Password, false, false);
            if (resultado.Result.Succeeded)
            {
                return Result.Ok();
            }
            return Result.Fail("Login falhou");
        }
    }
}
