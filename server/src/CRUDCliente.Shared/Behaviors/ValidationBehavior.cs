using CRUDCliente.Shared.Enums;
using CRUDCliente.Shared.Responses;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace CRUDCliente.Shared.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : Response
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators.Select(v => v.Validate(new ValidationContext<TRequest>(request)))
                                      .SelectMany(result => result.Errors)
                                      .Where(f => f != null)
                                      .ToList();

            return failures.Any() ? Errors(failures) : next();
        }

        private static Task<TResponse> Errors(List<ValidationFailure> failures)
        {
            var response = new ErrorResponse(ResponseType.UnprocessableEntity);
            failures.ForEach(err => response.AddErrors(err.PropertyName, err.ErrorMessage));
            return Task.FromResult(response as TResponse);
        }
    }
}