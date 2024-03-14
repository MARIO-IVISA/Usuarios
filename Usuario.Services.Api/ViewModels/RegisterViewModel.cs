using Flunt.Notifications;
using Flunt.Validations;
using Usuario.Services.Api.Entities;
using Usuario.Services.Api.Enuns;
using Usuario.Services.Api.Helpers;

namespace Usuario.Services.Api.ViewModels
{
    public class RegisterViewModel : Notifiable<Notification>
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public DateTime? DataNascimento { get; set; }
        public PerfilEnum? Perfil { get; set; }

        public Pessoa MapTo()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(Nome, "Informe o nome do usuário.")
                .IsGreaterOrEqualsThan(Nome, 6, "Nome do usuário deve ter no mínimo 6 caracteres.")
                .IsNotNullOrEmpty(Email, "Informe o email do usuário")
                .IsEmail(Email,"Informe um endereço de email válido.")
                .IsNotNullOrEmpty(Senha, "Informe a senha do usuário.")
                .IsGreaterOrEqualsThan(Senha, 6, "Senha do usuário deve ter no mínimo 6 caracteres")
                );
            return new Pessoa
            {
                Id = Guid.NewGuid(),
                Nome = Nome,
                Email = Email,
                Senha = MD5Helper.Get(Senha),
                DataNascimento = DataNascimento,
                PerfilEnum = Perfil
            };
        }    
    }
}
