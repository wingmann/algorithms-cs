namespace Wingmann.DataStructures.Stack;

/// <summary>
/// Implements list-based stack.
/// </summary>
/// <typeparam name="T">Generic type.</typeparam>
public class ListBasedStack<T>
{
    /// <summary>
    /// <see cref="List{T}" /> based stack.
    /// </summary>
    private readonly LinkedList<T> _stack;
    
    /// <summary>
    ///     Gets the number of elements on the <see cref="ListBasedStack{T}" />.
    /// </summary>
    public int Count => _stack.Count;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="ListBasedStack{T}" /> class.
    /// </summary>
    public ListBasedStack() => _stack = new LinkedList<T>();

    /// <summary>
    /// Initializes a new instance of the <see cref="ListBasedStack{T}" /> class.
    /// </summary>
    /// <param name="item">Item to push onto the <see cref="ListBasedStack{T}" />.</param>
    public ListBasedStack(T item) : this() => Push(item);

    /// <summary>
    /// Initializes a new instance of the <see cref="ListBasedStack{T}" /> class.
    /// </summary>
    /// <param name="items">Items to push onto the <see cref="ListBasedStack{T}" />.</param>
    public ListBasedStack(IEnumerable<T> items) : this()
    {
        foreach (var item in items)
        {
            Push(item);
        }
    }
    
    /// <summary>
    ///     Inserts an item at the top of the <see cref="ListBasedStack{T}" />.
    /// </summary>
    /// <param name="item">The item to push onto the <see cref="ListBasedStack{T}" />.</param>
    public void Push(T item) => _stack.AddFirst(item);
    
    /// <summary>
    ///     Removes and returns the item at the top of the <see cref="ListBasedStack{T}" />.
    /// </summary>
    /// <returns>The item removed from the top of the <see cref="ListBasedStack{T}" />.</returns>
    public T Pop()
    {
        if (_stack.First is null)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        var item = _stack.First.Value;
        _stack.RemoveFirst();
        return item;
    }
    
    /// <summary>
    /// Returns the item at the top of the <see cref="ListBasedStack{T}" /> without removing it.
    /// </summary>
    /// <returns>The item at the top of the <see cref="ListBasedStack{T}" />.</returns>
    public T Peek()
    {
        if (_stack.First is null)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        return _stack.First.Value;
    }
    
    /// <summary>
    /// Determines whether an element is in the <see cref="ListBasedStack{T}" />.
    /// </summary>
    /// <param name="item">The item to locate in the <see cref="ListBasedStack{T}" />.</param>
    /// <returns>True, if the item is in the stack.</returns>
    public bool Contains(T item) => _stack.Contains(item);
    
    /// <summary>
    /// Removes all items from the <see cref="ListBasedStack{T}" />.
    /// </summary>
    public void Clear() => _stack.Clear();
}
