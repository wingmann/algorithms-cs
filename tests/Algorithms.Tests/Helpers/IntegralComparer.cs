namespace Wingmann.Algorithms.Tests.Helpers;

public class IntegralComparer : IComparer<int>
{
    public int Compare(int x, int y) => x.CompareTo(y);
}
