// 代码生成时间: 2025-09-04 19:45:32
using System;
// MathematicsService.cs

/// <summary>
/// This class provides a set of mathematical operations.
/// </summary>
public class MathematicsService
{
    // Addition operation
    /// <summary>
    /// Adds two numbers and returns the result.
    /// </summary>
    /// <param name="a">First number.</param>
    /// <param name="b">Second number.</param>
    /// <returns>The sum of the two numbers.</returns>
    public double Add(double a, double b)
    {
        return a + b;
    }

    // Subtraction operation
    /// <summary>
    /// Subtracts the second number from the first number and returns the result.
    /// </summary>
    /// <param name="a">First number.</param>
    /// <param name="b">Second number.</param>
    /// <returns>The difference between the two numbers.</returns>
    public double Subtract(double a, double b)
    {
        return a - b;
    }

    // Multiplication operation
    /// <summary>
    /// Multiplies two numbers and returns the result.
    /// </summary>
    /// <param name="a">First number.</param>
    /// <param name="b">Second number.</param>
    /// <returns>The product of the two numbers.</returns>
    public double Multiply(double a, double b)
    {
        return a * b;
    }

    // Division operation
    /// <summary>
    /// Divides the first number by the second number and returns the result.
    /// </summary>
    /// <param name="a">First number (numerator).</param>
    /// <param name="b">Second number (denominator).</param>
    /// <returns>The quotient of the division.</returns>
    /// <exception cref="DivideByZeroException">Thrown when the second number is zero.</exception>
    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }

        return a / b;
    }

    // Power operation
    /// <summary>
    /// Raises the first number to the power of the second number and returns the result.
    /// </summary>
    /// <param name="base">The base number.</param>
    /// <param name="exponent">The exponent.</param>
    /// <returns>The result of the power operation.</returns>
    public double Power(double @base, double exponent)
    {
        return Math.Pow(@base, exponent);
    }

    // Square root operation
    /// <summary>
    /// Calculates the square root of a number and returns the result.
    /// </summary>
    /// <param name="number">The number to calculate the square root of.</param>
    /// <returns>The square root of the number.</returns>
    /// <exception cref="ArgumentException">Thrown when the number is negative.</exception>
    public double SquareRoot(double number)
    {
        if (number < 0)
        {
            throw new ArgumentException("Cannot calculate the square root of a negative number.");
        }

        return Math.Sqrt(number);
    }
}
