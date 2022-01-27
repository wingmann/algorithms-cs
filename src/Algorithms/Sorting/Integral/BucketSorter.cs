using Algorithms.Sorting.Integral.Interfaces;

namespace Algorithms.Sorting.Integral;

/// <summary>
/// Implements bucket sort algorithm.
/// </summary>
public class BucketSorter : IIntegralSorter
{
    private const int NumOfDigitsInBase10 = 10;

    /// <summary>
    /// Sorts array elements using bucket sort algorithm.
    /// </summary>
    /// <param name="array">Array to sort.</param>
    public void Sort(int[] array)
    {
        if (array.Length <= 1)
        {
            return;
        }

        // Store maximum number of digits in numbers to sort.
        var totalDigits = NumberOfDigits(array);

        // Bucket array where numbers will be placed
        var buckets = new int[NumOfDigitsInBase10, array.Length + 1];

        // Go through all digit places and sort each number according to digit place value.
        for (var pass = 1; pass <= totalDigits; pass++)
        {
            // Distribution pass.
            DistributeElements(array, buckets, pass);
            
            // Gathering pass.
            CollectElements(array, buckets);

            if (pass != totalDigits)
            {
                // Set size of buckets to 0.
                EmptyBucket(buckets);
            }
        }
    }

    /// <summary>
    /// Determines the number of digits in the largest number.
    /// </summary>
    /// <param name="array">Input array.</param>
    /// <returns>Number of digits.</returns>
    private static int NumberOfDigits(IEnumerable<int> array) => (int)Math.Floor(Math.Log10(array.Max()) + 1);

    /// <summary>
    /// To distribute elements into buckets based on specified digit.
    /// </summary>
    /// <param name="data">Input array.</param>
    /// <param name="buckets">Array of buckets.</param>
    /// <param name="digit">Digit.</param>
    private static void DistributeElements(IEnumerable<int> data, int[,] buckets, int digit)
    {
        // Determine the divisor used to get specific digit.
        var divisor = (int)Math.Pow(10, digit);

        foreach (var element in data)
        {
            // BucketNumber example for hundreds digit: (1234 % 1000) / 100 --> 2
            var bucketNumber = NumOfDigitsInBase10 * (element % divisor) / divisor;

            // Retrieve value in pail[ bucketNumber , 0 ] to determine the location in row to store element.
            // Location in bucket to place element.
            var elementNumber = ++buckets[bucketNumber, 0];
            buckets[bucketNumber, elementNumber] = element;
        }
    }

    /// <summary>
    /// Return elements to original array.
    /// </summary>
    /// <param name="data">Input array.</param>
    /// <param name="buckets">Array of buckets.</param>
    private static void CollectElements(IList<int> data, int[,] buckets)
    {
        // Initialize location in data.
        var subscript = 0;

        // Loop over buckets.
        for (var i = 0; i < NumOfDigitsInBase10; i++)
        {
            // Loop over elements in each bucket.
            for (var j = 1; j <= buckets[i, 0]; j++)
            {
                // Add element to array.
                data[subscript++] = buckets[i, j];
            }
        }
    }

    /// <summary>
    /// Sets size of all buckets to zero.
    /// </summary>
    /// <param name="buckets">Array of buckets.</param>
    private static void EmptyBucket(int[,] buckets)
    {
        for (var i = 0; i < NumOfDigitsInBase10; i++)
        {
            // Set size of bucket to 0.
            buckets[i, 0] = 0;
        }
    }
}
