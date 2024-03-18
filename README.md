# Sistema de Cadastro de Usuário

## Tags
`c#` `.net-8` `asp.net-core` `jwt` `api` `login` `cadastro` `usuarios` `testes-de-unidade`

Este é um sistema de cadastro de usuário desenvolvido como uma API minimalista em C# .NET 8. O sistema permite o registro de usuários e gera tokens JWT para autenticação. Os principais endpoints disponíveis são:

- **`/api/login`**: Realiza o login com e-mail e senha e retorna um token JWT.
- **`/api/cadastro`**: Realiza o cadastro de um novo usuário.
- **`/api/usuarios`**: Lista todos os usuários cadastrados.
- **`/api/usuariosPorId`**: Retorna um usuário específico pelo seu ID.

O sistema também inclui testes de unidade para garantir o correto funcionamento das funcionalidades:

- `Login_Post_Returns_BadRequest`: Testa se o endpoint de login retorna um erro BadRequest em caso de falha de autenticação.
- `Login_Post_Returns_OK`: Testa se o endpoint de login retorna um status OK (200) em caso de sucesso de autenticação.
- `Register_Post_Returns_BadRequest`: Testa se o endpoint de cadastro retorna um erro BadRequest em caso de falha no cadastro de um usuário.
- `Register_Post_Returns_OK`: Testa se o endpoint de cadastro retorna um status OK (200) em caso de sucesso no cadastro de um usuário.

## Tecnologias Utilizadas

- C# .NET 8
- ASP.NET Core
- JWT (JSON Web Tokens)
