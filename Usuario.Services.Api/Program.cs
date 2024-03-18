using Bogus;
using Microsoft.EntityFrameworkCore;
using Usuario.Services.Api.Contexts;
using Usuario.Services.Api.Entities;
using Usuario.Services.Api.Enuns;
using Usuario.Services.Api.Helpers;
using Usuario.Services.Api.Migrations;
using Usuario.Services.Api.Security;
using Usuario.Services.Api.Setup;
using Usuario.Services.Api.ViewModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

SwaggerSetup.AddSwaggerSetup(builder);
CorsSetup.AddCorsSetup(builder);

var connectionString = builder.Configuration.GetConnectionString("BDUsuario");
builder.Services.AddDbContext<SqlServerContext>
    (options => options.UseSqlServer(connectionString));

JwtConfiguration.AddJwtBearerConfiguration(builder);

var app = builder.Build();

SwaggerSetup.UseSwaggerSetup(app);
CorsSetup.UseCorsSetup(app);

app.UseAuthentication();

#region Minimal API
app.MapPost("/api/login", (SqlServerContext context, JwtTokenService service, LoginViewModel model) =>
{
    var login = model.MapTo();
    if (!model.IsValid)
        return Results.BadRequest(model.Notifications);

    var usuario = context.Usuarios.FirstOrDefault(u => u.Email.Equals(login.Email)
                                                  && u.Senha.Equals(login.Senha));

    if (usuario == null)
        return Results.BadRequest(new { message = "Acesso negado. Usu�rio inv�lido." });

    return Results.Ok(
        new
        {
            usuario.Id,
            usuario.Nome,
            usuario.Email,
            usuario.PerfilEnum,
            accessToken = service.Get(usuario.Email)
        }
        );
});

app.MapPost("/api/cadastro", (SqlServerContext context, RegisterViewModel model) =>
{
    var usuario = model.MapTo();
    if (!model.IsValid)
        return Results.BadRequest(model.Notifications);

    if (context.Usuarios.FirstOrDefault(u => u.Email.Equals(model.Email)) != null)
        return Results.BadRequest(new { message = "O email informado ja esta cadastrado, tente outro." });


    context.Usuarios.Add(usuario);
    context.SaveChanges();

    return Results.Ok(new { usuario.Id, usuario.Nome, usuario.Email, usuario.DataNascimento });
});

app.MapGet("/api/usuarios", (SqlServerContext context) =>
{
    var usuario = context.Usuarios.ToList();

    return Results.Ok(new { usuario });
});

app.MapGet("/api/usuariosPorId/{id}", (SqlServerContext context, Guid id) =>
{
    var usuarioExistente = context.Usuarios.FirstOrDefault(u => u.Id.Equals(id));

    if (usuarioExistente == null)
        return Results.BadRequest(new { message = "Usu�rio n�o cadastrado." });

    UsuarioRetornoViewModel usuario = new()
    {
        Nome = usuarioExistente.Nome,
        Email = usuarioExistente.Email
    };

    return Results.Ok(new { usuario });
});


#endregion

app.Run();

public partial class Program{}