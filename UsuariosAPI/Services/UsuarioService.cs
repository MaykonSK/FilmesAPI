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
        private TokenService _tokenService;
        private EmailService _emailService;

        public UsuarioService(IMapper mapper, UserManager<IdentityUser<int>> userManager, SignInManager<IdentityUser<int>> signInManager, TokenService tokenService, EmailService emailService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _emailService = emailService;
        }

        public Result cadastrarUsuario(CreateUsuarioDto usuarioDto)
        {
            //passando os dados do DTO para o usuario
            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);

            //passando os dados do usuario para o identity
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);

            //obtem o resultado da criação    //criando o usuario no identity
            Task<IdentityResult> resultado = _userManager.CreateAsync(usuarioIdentity, usuarioDto.Password);

            if (resultado.Result.Succeeded)
            {
                var code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result; //recuperar codigo de autenticação de e-mail
                _emailService.EnviarEmail(new[] { usuarioIdentity.Email }, "link de ativação", usuarioIdentity.Id, code);
                return Result.Ok().WithSuccess(code);
            }
            return Result.Fail("Falha ao cadastrar usuário");
        }

        public Result logarUsuario(Login login)
        {
            //efetuar autenticação via senha
            var resultado = _signInManager.PasswordSignInAsync(login.Username, login.Password, false, false);
            
            if (resultado.Result.Succeeded)
            {
                
                //recuperar identity user
                var identityUser = _signInManager.UserManager.Users.FirstOrDefault(usuario => usuario.NormalizedUserName == login.Username.ToUpper());

                //gerar token e retornar para o osuaurio
                Token token = _tokenService.CreateToken(identityUser);

                //retorna o token para o controller
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login falhou");
        }

        public Result deslogarUsuario()
        {
            var resultado = _signInManager.SignOutAsync();
            if (resultado.IsCompletedSuccessfully)
            {
                return Result.Ok();
            }

            return Result.Fail("Logout falhou");
        }

        public Result ativaContaUsuario(AtivaConta request)
        {
            //recupera usuario identity
            var userIdentity = _userManager.Users.FirstOrDefault(user => user.Id == request.UsuarioId);

            //confirmar o e-mail
            var identityResult = _userManager.ConfirmEmailAsync(userIdentity, request.CodigoAtivacao).Result;

            if (identityResult.Succeeded)
            {
                return Result.Ok();
            }

            return Result.Fail("Falha ao ativar conta de usuário");
            
        }
    }
}
