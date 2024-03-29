﻿using Flunt.Notifications;
using Flunt.Validations;
using Usuario.Services.Api.Helpers;

namespace Usuario.Services.Api.ViewModels
{
    public class LoginViewModel : Notifiable<Notification>
    {
        public string? Email { get; set; }
        public string? Senha { get; set; }

        public LoginViewModel MapTo()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(Email,"Informe o email de acesso.")
                .IsEmail(Email,"Informe um endereço de email válido.")
                .IsNotNullOrEmpty(Senha,"Informe a senha de acesso.")
                .IsGreaterOrEqualsThan(Senha, 6,"Senha do usuário deve ter no mínimo 6 caracteres.")
                );
            return new LoginViewModel
            {
                Email = Email,
                Senha = MD5Helper.Get(Senha)
            };
        }    
    }
}
