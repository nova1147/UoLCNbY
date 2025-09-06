// 代码生成时间: 2025-09-07 06:01:45
using System;

namespace MathTools
{
    /// <summary>
    /// A collection of mathematical operations.
    /// </summary>
    public class MathCalculator
    {
        /// <summary>
        /// Calculates the sum of two numbers.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>The sum of the two numbers.</returns>
        public double Add(double a, double b)
        {
            return a + b;
        }

        /// <summary>
        /// Calculates the difference between two numbers.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>The difference between the two numbers.</returns>
        public double Subtract(double a, double b)
        {
            return a - b;
        }

        /// <summary>
        /// Calculates the product of two numbers.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>The product of the two numbers.</returns>
        public double Multiply(double a, double b)
        {
            return a * b;
        }

        /// <summary>
        /// Calculates the division of two numbers.
        /// </summary>
        /// <param name="a">First number (numerator).</param>
        /// <param name="b">Second number (denominator).</param>
        /// <returns>The division result.</returns>
        /// <exception cref="DivideByZeroException">Thrown when the denominator is zero.</exception>
        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return a / b;
        }

        /// <summary>
        /// Calculates the power of a number.
        /// </summary>
        /// <param name="base">The base number.</param>
        /// <param name="exponent">The exponent.</param>
        /// <returns>The result of the power operation.</returns>
        public double Power(double @base, double exponent)
        {
            return Math.Pow(@base, exponent);
        }

        /// <summary>
        /// Calculates the square root of a number.
        /// </summary>
        /// <param name="value">The number to calculate the square root of.</param>
        /// <returns>The square root of the number.</returns>
        /// <exception cref="ArgumentException">Thrown when the number is negative.</exception>
        public double SquareRoot(double value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Cannot calculate the square root of a negative number.");
            }
            return Math.Sqrt(value);
        }
    }
}