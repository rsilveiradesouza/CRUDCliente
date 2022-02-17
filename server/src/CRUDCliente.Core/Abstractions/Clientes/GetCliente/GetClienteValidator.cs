using FluentValidation;

namespace CRUDCliente.Core.Abstractions.Clientes.GetCliente
{
    public class GetClienteValidator : AbstractValidator<GetClienteRequest>
    {
        public GetClienteValidator()
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