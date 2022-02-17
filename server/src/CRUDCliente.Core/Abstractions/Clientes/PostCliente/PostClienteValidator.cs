using CRUDCliente.Shared.Extensions;
using FluentValidation;

namespace CRUDCliente.Core.Abstractions.Clientes.PostCliente
{
    public class PostClienteValidator : AbstractValidator<PostClienteRequest>
    {
        public PostClienteValidator()
        {
            AddNomeRule();
            AddCpfRule();
            AddCpfValidoRule();
        }

        #region Validation rules
        private void AddNomeRule()
        {
            RuleFor(u => u.Nome)
                .NotEmpty()
                    .WithMessage("Nome é obrigatório.");
        }
        private void AddCpfRule()
        {
            RuleFor(u => u.Cpf)
                .NotEmpty()
                    .WithMessage("Cpf é obrigatório.");
        }

        private void AddCpfValidoRule()
        {
            RuleFor(u => u.Cpf)
                .Must(c => c.IsValidCpf())
                    .WithMessage("Cpf é inválido.");
        }
        #endregion
    }
}