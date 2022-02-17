using FluentValidation;

namespace CRUDCliente.Core.Abstractions.Clientes.DeleteCliente
{
    public class DeleteClienteValidator : AbstractValidator<DeleteClienteRequest>
    {
        public DeleteClienteValidator()
        {
            AddIdRule();
        }

        #region Validation rules
        private void AddIdRule()
        {
            RuleFor(u => u.Id)
                .NotEmpty()
                    .WithMessage("Id é obrigatório.");
        }
        #endregion
    }
}