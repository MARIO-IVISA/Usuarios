using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Usuario.Services.Api.Enuns;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Usuario.Services.Api.Entities
{
    public class Pessoa
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public PerfilEnum? PerfilEnum { get; set; }
    }
}
