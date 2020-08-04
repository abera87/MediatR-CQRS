using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BackOffice.Common.Exceptions;
using FluentValidation;
using MediatR;
namespace BackOffice.Common.Behaviours
{
    public class ValidationBehavior<TRequest, Tresponse> : IPipelineBehavior<TRequest, Tresponse>
                where TRequest : IRequest<Tresponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validator;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validator)
        {
            this.validator = validator;
        }

        public async Task<Tresponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<Tresponse> next)
        {
            // pre task
            if (validator.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(validator.Select(v => v.ValidateAsync(context, cancellationToken)));
                var falioures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (falioures.Count != 0)
                {
                    throw new EntityValidationException(falioures);

                    // manually send valaidation error exception
                    /*
                    var rf = falioures.GroupBy(p => p.PropertyName, v => v.ErrorMessage);
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    foreach (var s in rf)
                    {
                        sb.Append(string.Join(",", s.ToArray()));
                    }
                    throw new System.Exception(sb.ToString());

                    */
                }
            }

            return await next();

            //post task
        }
    }
}