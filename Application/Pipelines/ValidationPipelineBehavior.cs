using Application.Common.Wrapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pipelines
{
    public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
         where TRequest : IRequest<TResponse>, IValidateMe
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly ILogger<ValidationPipelineBehavior<TRequest, TResponse>> _logger;

        public ValidationPipelineBehavior(
            IEnumerable<IValidator<TRequest>> validators,
            ILogger<ValidationPipelineBehavior<TRequest, TResponse>> logger)
        {
            _validators = validators;
            _logger = logger;
        }

        /// <summary>
        /// Executes validation before the request handler.
        /// </summary>
        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (!_validators.Any())
                return await next();

            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context, cancellationToken))
            );

            var failures = validationResults
                .SelectMany(r => r.Errors)
                .Where(f => f != null)
                .DistinctBy(f => f.PropertyName)
                .ToList();

            if (failures.Count != 0)
            {
                var errorMessages = failures.Select(f => f.ErrorMessage).ToList();

                _logger.LogWarning("Validation failed for {RequestName}: {@Errors}", typeof(TRequest).Name, errorMessages);

                var responseType = typeof(TResponse);

                if (responseType.IsGenericType && responseType.GetGenericTypeDefinition() == typeof(ResponseWrapper<>))
                {
                    var genericArgument = responseType.GetGenericArguments()[0];
                    var failureMethod = typeof(ResponseWrapper<>)
                        .MakeGenericType(genericArgument)
                        .GetMethod(
                            nameof(ResponseWrapper<object>.FailureAsync),
                            new[] { typeof(List<string>), typeof(string), typeof(int) }
                        );

                    // Invoke FailureAsync
                    var failureTask = (Task)failureMethod!.Invoke(
                        null,
                        new object[] { errorMessages, "Validation Failed", 400 }
                    )!;

                    // Await the returned Task<ResponseWrapper<T>>
                    await failureTask.ConfigureAwait(false);

                    // Extract result from Task
                    var resultProperty = failureTask.GetType().GetProperty("Result");
                    var failureResponse = (TResponse)resultProperty!.GetValue(failureTask)!;

                    return failureResponse;
                }

                throw new FluentValidation.ValidationException(string.Join(", ", errorMessages));
            }


            return await next();
        }
    }
}
