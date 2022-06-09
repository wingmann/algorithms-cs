using FluentAssertions;
using NUnit.Framework;
using Wingmann.Algorithms.Extentions;
using Wingmann.Algorithms.LinearAlgebra.Eigenvalue;

namespace Wingmann.Algorithms.Tests.LinearAlgebra.Eigenvalue;

public static class PowerIterationTests
{
    private static readonly object[] DominantVectorTestCases =
    {
        new object[]
        {
            3.0,
            new[]
            {
                0.7071039,
                0.70710966,
            },
            new[,]
            {
                { 2.0, 1.0 },
                { 1.0, 2.0 },
            },
        },
        new object[]
        {
            4.235889,
            new[]
            {
                0.91287093,
                0.40824829,
            },
            new[,]
            {
                { 2.0, 5.0 },
                { 1.0, 2.0 },
            },
        },
    };

    private static readonly double Epsilon = Math.Pow(10, -5);

    [Test]
    public static void Dominant_ShouldThrowArgumentException_WhenSourceMatrixIsNotSquareShaped()
    {
        // Arrange.
        var source = new double[,]
        {
            { 1, 0, 0 },
            { 0, 1, 0 },
            { 0, 0, 1 },
            { 0, 0, 0 },
        };

        // Act.
        Action action = () => PowerIteration.Dominant(source, StartVector(source.GetLength(0)), Epsilon);

        // Assert.
        action
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("The source matrix is not square-shaped.");
    }

    [Test]
    public static void Dominant_ShouldThrowArgumentException_WhenStartVectorIsNotSameSizeAsMatrix()
    {
        // Arrange.
        var source = new double[,]
        {
            { 1, 0, 0 },
            { 0, 1, 0 },
            { 0, 0, 1 },
        };
        
        var startVector = new double[] { 1, 0, 0, 0 };

        // Act.
        Action action = () => PowerIteration.Dominant(source, startVector, Epsilon);

        // Assert.
        action
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("The length of the start vector doesn't equal the size of the source matrix.");
    }

    [TestCaseSource(nameof(DominantVectorTestCases))]
    public static void Dominant_ShouldCalculateDominantEigenvalueAndEigenvector(
        double eigenvalue,
        double[] eigenvector,
        double[,] source)
    {
        // Act.
        var (actualEigVal, actualEigVec) =
            PowerIteration.Dominant(source, StartVector(source.GetLength(0)), Epsilon);

        // Assert.
        actualEigVal
            .Should()
            .BeApproximately(eigenvalue, Epsilon);
        
        actualEigVec
            .Magnitude()
            .Should()
            .BeApproximately(eigenvector.Magnitude(), Epsilon);
    }

    private static double[] StartVector(int length) => new Random(111111).NextVector(length);
}
