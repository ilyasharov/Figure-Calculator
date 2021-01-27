using System;
using System.Collections.Generic;
using Solution.Parameters;

namespace Solution.Figures
{
    public class Rectangle : Figure
    {
        public Rectangle(IDictionary<string, object> parameters) : base(parameters)
        {
        }

        protected override double Calculate(IDictionary<string, object> parameters)
        {
            ValidateRequiredParameters(ParameterKeys.Length, ParameterKeys.Width);

            if (parameters[ParameterKeys.Length] is double length && parameters[ParameterKeys.Width] is double width)
            {
                return length * width;
            }

            throw new InvalidOperationException($"some type is not valid");
        }
    }
}