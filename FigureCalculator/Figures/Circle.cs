using System;
using System.Collections.Generic;
using Solution.Parameters;

namespace Solution.Figures
{
    public class Circle : Figure
    {
        private const double Pi = Math.PI;

        public Circle(IDictionary<string, object> parameters) : base(parameters)
        {
        }

        protected override double Calculate(IDictionary<string, object> parameters)
        {
            ValidateRequiredParameters(ParameterKeys.Radius);

            if (parameters[ParameterKeys.Radius] is double radius)
            {
                return Pi * Math.Pow(radius, 2);
            }

            throw new InvalidOperationException($"parameters {ParameterKeys.Radius} is wrong");
        }
    }
}