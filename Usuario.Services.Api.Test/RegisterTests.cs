﻿using Bogus;
using FluentAssertions;
using Usuario.Services.Api.Entities;
using Usuario.Services.Api.Test.Helper;
using Usuario.Services.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Usuario.Services.Api.Enuns;

namespace Usuario.Services.Api.Test
{
    public class RegisterTests
    {
        private readonly string _endpoint;
        public RegisterTests()
        {
            _endpoint = "/api/cadastro";
        }

        [Fact]
        public async Task<Pessoa> Register_Post_Returns_OK()
        {
            var faker = new Faker("pt_BR");
            var model = new RegisterViewModel 
            {
                Nome = faker.Person.FullName,
                Email = faker.Person.Email,
                Senha = faker.Internet.Password(8),
                DataNascimento = faker.Date.Past(),
                Perfil = PerfilEnum.Aluno
            };
            var client = TestsHelper.CreateClient();
            var result = await client.PostAsync(_endpoint, TestsHelper.CreateContent(model));

            result.StatusCode.Should().Be(HttpStatusCode.OK);

            var usuario = TestsHelper.CreateResponse<Pessoa>(result);
            usuario.Should().NotBeNull();
            usuario.Id.Should().NotBeEmpty();
            usuario.Nome.Should().Be(model.Nome);
            usuario.Email.Should().Be(model.Email);
            usuario.DataNascimento.Should().NotBeNull();

            usuario.Senha = model.Senha;
            return usuario;
        }
        [Fact]
        public async Task Register_Post_Returns_BadRequest()
        {
            var usuario = await Register_Post_Returns_OK();

            var model = new RegisterViewModel
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha
            };

            var client = TestsHelper.CreateClient();
            var result = await client.PostAsync(_endpoint, TestsHelper.CreateContent(model));

            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
    