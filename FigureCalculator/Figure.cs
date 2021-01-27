using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Solution
{
    public abstract class Figure
    {
        private readonly IDictionary<string, object> _parameters;

        protected Figure(IDictionary<string, object> parameters)
        {
            _parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
        }

        public double OnCalculate()
        {
            Validate();
            return Calculate(_parameters);
        }

        private void Validate()
        {
            if (!_parameters.Any())
                throw new ValidationException("parameters is empty");

            // any validations....
        }

        protected void ValidateRequiredParameters(params string[] parameterNames)
        {
            foreach (var name in parameterNames)
            {
                if (!_parameters.TryGetValue(name, out var value))
                    throw new InvalidOperationException($"Not found required parameter #{name}");

                if (value == null)
                   throw new ArgumentNullException($"argument #{name} can not be null");
            }
        }

        protected abstract double Calculate(IDictionary<string, object> param);
    }
}