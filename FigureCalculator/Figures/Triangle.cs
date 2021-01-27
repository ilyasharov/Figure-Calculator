using System;
using System.Collections.Generic;
using Solution.Parameters;

namespace Solution.Figures
{
    public class Triangle : Figure
    {
        private readonly IDictionary<string, object> _parameters;

        public Triangle(IDictionary<string, object> parameters) : base(parameters)
        {
            _parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
        }

        protected override double Calculate(IDictionary<string, object> parameters)
        {
            ValidateRequiredParameters(ParameterKeys.Triangle);
            
            var parameter = GetTriangleParameter(parameters[ParameterKeys.Triangle]);
            var p = 0.5 * (parameter.A + parameter.B + parameter.C);
            return Math.Sqrt(p * (p - parameter.A) * (p - parameter.B) * (p - parameter.C));
        }

        public bool IsRight
        {
            get
            {
                ValidateRequiredParameters(ParameterKeys.Triangle);

                var parameter = GetTriangleParameter(_parameters[ParameterKeys.Triangle]);
                var a = parameter.A;
                var b = parameter.B;
                var c = parameter.C;
                return IsPythagorasTriangle(a, b, c) || IsPythagorasTriangle(a, c, b) || IsPythagorasTriangle(c, b, a);

                bool IsPythagorasTriangle(double leg1, double leg2, double hypotenuse)
                {
                    return Math.Pow(leg1, 2) + Math.Pow(leg2, 2) == Math.Pow(hypotenuse, 2);
                }
            }
        }

        private TriangleParameter GetTriangleParameter(object parameter)
        {
            if (parameter is TriangleParameter param)
                return param;

            throw new InvalidOperationException($"parameters {nameof(TriangleParameter)} is wrong");
        }
    }
}