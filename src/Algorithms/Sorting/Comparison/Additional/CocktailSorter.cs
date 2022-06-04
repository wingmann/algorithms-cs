using Algorithms.Sorting.Comparison.Interfaces;

namespace Algorithms.Sorting.Comparison.Additional;

/// <summary>
/// Implements cocktail sorting algorithm.<br />
/// See on <see href="https://en.wikipedia.org/wiki/Cocktail_shaker_sort">Wikipedia</see>.
/// </summary>
public class CocktailSorter : IComparisonSorter
{
    /// <inheritdoc cref="IComparisonSorter.Sort{T}" />
    public void Sort<T>(T[] array, IComparer<T> comparer) where T : IComparable<T> =>
        CocktailSort(array, comparer);
    
    private static void CocktailSort<T>(IList<T> array, IComparer<T> comparer)
    {
        var swapped = true;

        var startIndex = 0;
        var endIndex = array.Count - 1;

        while (swapped)
        {
            for (var i = startIndex; i < endIndex; i++)
            {
                if (comparer.Compare(array[i], array[i + 1]) != 1)
                {
                    continue;
                }

                (array[i], array[i + 1]) = (array[i + 1], array[i]);
            }

            endIndex--;
            swapped = false;

            for (var i = endIndex; i > startIndex; i--)
            {
                if (comparer.Compare(array[i], array[i - 1]) != -1)
                {
                    continue;
                }

                (array[i], array[i - 1]) = (array[i - 1], array[i]);
                swapped = true;
            }

            startIndex++;
        }
    }
}
