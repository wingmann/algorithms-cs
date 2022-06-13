namespace Wingmann.Algorithms.Numeric;

/// <summary>
/// Implements factorial algorithm.
/// See on <see href="https://en.wikipedia.org/wiki/Factorial">Wikipedia</see>
/// </summary>
public static class Factorial
{
    /// <summary>
    /// Calculates factorial of a number.
    /// </summary>
    /// <param name="number">Input number.</param>
    /// <returns>Factorial of input number.</returns>
    public static long Calculate(int number)
    {
        if (number < 0)
        {
            throw new ArgumentException("Only for numbers equal to or greater than 0");
        }
        
        return number == 0 ? 1 : number * Calculate(number - 1);
    }
}
