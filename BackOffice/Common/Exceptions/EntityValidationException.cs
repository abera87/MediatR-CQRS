using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace BackOffice.Common.Exceptions
{
    public class EntityValidationException : Exception
    {
        public Dictionary<string, string[]> Errors { get; }
        public EntityValidationException() : base("One or more validation failures have occored.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public EntityValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            var failureGroups = failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage);

            foreach (var failoureGroup in failureGroups)
            {
                var propertyName = failoureGroup.Key;
                var propertyFailours = failoureGroup.ToArray();

                Errors.Add(propertyName, propertyFailours);
            }
        }
    }
}