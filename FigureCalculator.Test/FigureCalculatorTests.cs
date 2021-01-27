using System;
using System.Collections.Generic;
using Solution.Figures;
using Solution.Parameters;
using Xunit;

namespace FigureCalculator
{
    public class FigureCalculatorTests
    {
        [Fact]
        public void ItShouldBeCalculateCircleSquare()
        {
            const double expectedValue = 19.634954084936208;

            var parameters = new Dictionary<string, object>
            {
                {ParameterKeys.Radius, 2.5}
            };

            var sut = new Circle(parameters);
            var result = sut.OnCalculate();

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void ItShouldBeCalculateRectangleSquare()
        {
            const double expectedValue = 25;

            var parameters = new Dictionary<string, object>
            {
                { ParameterKeys.Length, 5D },
                { ParameterKeys.Width, 5D }
            };

            var sut = new Rectangle(parameters);
            var result = sut.OnCalculate();

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void ItShouldBeCalculateTriangleSquare()
        {
            const double expectedValue = 9.9215674164922145;

            var parameters = new Dictionary<string, object>
            {
                {ParameterKeys.Triangle, new TriangleParameter(4, 5, 6)}
            };

            var sut = new Triangle(parameters);
            var result = sut.OnCalculate();

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void ItShouldBeRightTriangle()
        {
            const double expectedValue = 6;

            var parameters = new Dictionary<string, object>
            {
                {ParameterKeys.Triangle, new TriangleParameter(4, 5, 3)}
            };

            var sut = new Triangle(parameters);
            var result = sut.OnCalculate();
            var isRight = sut.IsRight;

            Assert.Equal(expectedValue, result);
            Assert.True(isRight);
        }

        [Fact]
        public void ItShouldBeThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var parameters = new Dictionary<string, object>
                {
                    {ParameterKeys.Radius, 2.5}
                };

                var sut = new Triangle(parameters);
                sut.OnCalculate();
            });
        }

        [Fact]
        public void ItShouldBeCalculateByUnknownFigure()
        {
            const double expectedValue = 19.634954084936208;

            Func<IDictionary<string, object>, double> func = parameters =>
            {
                if (!parameters.TryGetValue(ParameterKeys.Radius, out var value))
                    throw new KeyNotFoundException($"Key #{ParameterKeys.Radius} not found");

                if (value is double radius)
                {
                    return Math.PI * Math.Pow(radius, 2);
                }

                throw new InvalidOperationException($"parameters {ParameterKeys.Radius} is wrong");
            };

            var unknownFigureParameters = new Dictionary<string, object>
            {
                {ParameterKeys.Radius, 2.5},
                {ParameterKeys.Func, func}
            };

            var sut = new UnknownFigure(unknownFigureParameters);
            var result = sut.OnCalculate();

            Assert.Equal(expectedValue, result);
        }
    }
}