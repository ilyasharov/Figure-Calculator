using System;
using System.Collections.Generic;
using Solution.Parameters;

namespace Solution.Figures
{
    public class UnknownFigure : Figure
    {
        public UnknownFigure(IDictionary<string, object> parameters) : base(parameters)
        {
        }

        protected override double Calculate(IDictionary<string, object> parameters)
        {
            ValidateRequiredParameters(ParameterKeys.Func);

            if (parameters[ParameterKeys.Func] is Func<IDictionary<string, object>, double> func)
            {
                return func(parameters);
            }

            throw new InvalidOperationException($"parameters {ParameterKeys.Radius} is wrong");
        }
    }
}