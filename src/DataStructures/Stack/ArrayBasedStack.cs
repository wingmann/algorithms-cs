namespace DataStructures.Stack;

/// <summary>
/// Implements array-based stack with LIFO style.
/// </summary>
public class ArrayBasedStack<T>
{
    private const int DefaultCapacity = 10;

    /// <summary>
    /// <see cref="Array" /> based stack.
    /// </summary>
    private T[] _stack;

    /// <summary>
    /// Gets the number of elements on the <see cref="ArrayBasedStack{T}" />.
    /// </summary>
    public int Top { get; private set; }

    /// <summary>
    /// Gets or sets the Capacity of the <see cref="ArrayBasedStack{T}" />.
    /// </summary>
    public int Capacity
    {
        get => _stack.Length;
        set => Array.Resize(ref _stack, value);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArrayBasedStack{T}" /> class.
    /// </summary>
    public ArrayBasedStack()
    {
        _stack = new T[DefaultCapacity];
        Top = -1;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArrayBasedStack{T}" /> class.
    /// </summary>
    /// <param name="item">Item to push onto the <see cref="ArrayBasedStack{T}" />.</param>
    public ArrayBasedStack(T item) : this() => Push(item);
    
    /// <summary>
    /// Initializes a new instance of the <see cref="ArrayBasedStack{T}" /> class.
    /// </summary>
    /// <param name="items">Items to push onto the <see cref="ArrayBasedStack{T}" />.</param>
    public ArrayBasedStack(IEnumerable<T> items) : this()
    {
        foreach (var item in items)
        {
            Push(item);
        }
    }

    /// <summary>
    /// Inserts an item at the top of the <see cref="ArrayBasedStack{T}" />.
    /// </summary>
    /// <param name="item">The item to push onto the <see cref="ArrayBasedStack{T}" />.</param>
    public void Push(T item)
    {
        if (Top == Capacity - 1)
        {
            Capacity *= 2;
        }

        _stack[++Top] = item;
    }
    
    /// <summary>
    /// Removes and returns the item at the top of the <see cref="ArrayBasedStack{T}" />.
    /// </summary>
    /// <returns>The item removed from the top of the <see cref="ArrayBasedStack{T}" />.</returns>
    public T Pop()
    {
        if (Top == -1)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        return _stack[Top--];
    }
    
    /// <summary>
    /// Returns the item at the top of the <see cref="ArrayBasedStack{T}" /> without removing it.
    /// </summary>
    /// <returns>The item at the top of the <see cref="ArrayBasedStack{T}" />.</returns>
    public T Peek()
    {
        if (Top == -1)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        return _stack[Top];
    }
    
    /// <summary>
    /// Determines whether an element is in the <see cref="ArrayBasedStack{T}" />.
    /// </summary>
    /// <param name="item">The item to locate in the <see cref="ArrayBasedStack{T}" />.</param>
    /// <returns>True, if the item is in the stack.</returns>
    public bool Contains(T item) => Array.IndexOf(_stack, item, 0, Top + 1) > -1;
    
    /// <summary>
    /// Removes all items from the <see cref="ArrayBasedStack{T}" />.
    /// </summary>
    public void Clear()
    {
        Top = -1;
        Capacity = DefaultCapacity;
    }
}
