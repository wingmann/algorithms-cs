using Wingmann.DataStructures.LinkedList.Internal;

namespace Wingmann.DataStructures.LinkedList;

/// <summary>
/// Similar to a Singly Linked List but each node contains a reference to the previous node in the list.
/// <see cref="System.Collections.Generic.LinkedList{T}" /> is a doubly linked list.
/// Compared to singly linked lists it can be traversed forwards and backwards.
/// Adding a node to a doubly linked list is simpler because ever node contains a reference to the previous node.
/// </summary>
/// <typeparam name="T">Generic type.</typeparam>
public class DoublyLinkedList<T>
{
    /// <summary>
    /// Gets the amount of nodes in the list.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Gets or sets the first node of the list.
    /// </summary>
    private DoublyNode<T>? _head;

    /// <summary>
    /// Gets or sets the last node of the list.
    /// </summary>
    private DoublyNode<T>? _tail;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="DoublyLinkedList{T}" /> class.
    /// </summary>
    /// <param name="data"> Data of the original head of the list.</param>
    public DoublyLinkedList(T data)
    {
        _head = new DoublyNode<T>(data);
        _tail = _head;
        Count = 1;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DoublyLinkedList{T}" /> class from an enumerable.
    /// </summary>
    /// <param name="data"> Enumerable of data to be stored in the list.</param>
    public DoublyLinkedList(IEnumerable<T> data)
    {
        foreach (var d in data)
        {
            Add(d);
        }
    }
    
    /// <summary>
    /// Replaces the Head of the list with the new value.
    /// </summary>
    /// <param name="data"> Value for the new Head of the list.</param>
    /// <returns>The new Head node.</returns>
    public DoublyNode<T> AddHead(T data)
    {
        var node = new DoublyNode<T>(data);

        if (_head is null)
        {
            _head = node;
            _tail = node;
            Count = 1;
            
            return node;
        }

        _head.Previous = node;
        node.Next = _head;
        _head = node;
        Count++;
        
        return node;
    }

    /// <summary>
    /// Adds a new value at the end of the list.
    /// </summary>
    /// <param name="data"> New value to be added to the list.</param>
    /// <returns>The new node created based on the new value.</returns>
    public DoublyNode<T> Add(T data)
    {
        if (_head is null)
        {
            return AddHead(data);
        }

        DoublyNode<T> node = new(data);
        _tail!.Next = node;
        node.Previous = _tail;
        _tail = node;
        Count++;
        
        return node;
    }

    /// <summary>
    /// Adds a new value after an existing node.
    /// </summary>
    /// <param name="data"> New value to be added to the list.</param>
    /// <param name="existingNode"> An existing node in the list.</param>
    /// <returns>The new node created based on the new value.</returns>
    public DoublyNode<T> AddAfter(T data, DoublyNode<T> existingNode)
    {
        if (existingNode == _tail)
        {
            return Add(data);
        }

        DoublyNode<T> node = new(data)
        {
            Next = existingNode.Next,
            Previous = existingNode,
        };
        
        existingNode.Next = node;

        if (existingNode.Next is not null)
        {
            existingNode.Next.Previous = node;
        }

        Count++;
        
        return node;
    }

    /// <summary>
    /// Gets an enumerable based on the data in the list.
    /// </summary>
    /// <returns>The data in the list in an IEnumerable. It can used to create a list or an array with LINQ.</returns>
    public IEnumerable<T> GetData()
    {
        var current = _head;
        
        while (current is not null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    /// <summary>
    /// Gets an enumerable based on the data in the list reversed.
    /// </summary>
    /// <returns>The data in the list in an IEnumerable. It can used to create a list or an array with LINQ.</returns>
    public IEnumerable<T> GetDataReversed()
    {
        var current = _tail;
        
        while (current is not null)
        {
            yield return current.Data;
            current = current.Previous;
        }
    }

    /// <summary>
    /// Reverses the list. Because of how doubly linked list are structured this is not a complex action.
    /// </summary>
    public void Reverse()
    {
        var current = _head;
        DoublyNode<T>? temp = null;

        while (current is not null)
        {
            temp = current.Previous;
            current.Previous = current.Next;
            current.Next = temp;
            current = current.Previous;
        }

        _tail = _head;

        // temp can be null on empty list
        if (temp is not null)
        {
            _head = temp.Previous;
        }
    }

    /// <summary>
    /// Looks for a node in the list that contains the value of the parameter.
    /// </summary>
    /// <param name="data"> Value to be looked for in a node.</param>
    /// <returns>The node in the list the has the parameter as a value or null if not found.</returns>
    public DoublyNode<T> Find(T data)
    {
        var current = _head;
        
        while (current is not null)
        {
            var condition = current.Data is null && data is null ||
                            current.Data is not null && current.Data.Equals(data);
            
            if (condition)
            {
                return current;
            }

            current = current.Next;
        }

        throw new ApplicationException("Item not found.");
    }

    /// <summary>
    /// Looks for a node in the list that contains the value of the parameter.
    /// </summary>
    /// <param name="position"> Position in the list.</param>
    /// <returns>The node in the list the has the parameter as a value or null if not found.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when position is negative or out range of the list.</exception>
    public DoublyNode<T> GetAt(int position)
    {
        if (position < 0 || position >= Count)
        {
            throw new ArgumentOutOfRangeException(null, $"Max count is {Count}");
        }

        var current = _head;
        
        for (var i = 0; i < position; i++)
        {
            current = current!.Next;
        }

        return current ?? throw new ArgumentOutOfRangeException(null, $"{position} must be an index in the list");
    }

    /// <summary>
    /// Removes the Head and replaces it with the second node in the list.
    /// </summary>
    public void RemoveHead()
    {
        if (_head is null)
        {
            throw new InvalidOperationException();
        }

        _head = _head.Next;
        
        if (_head is null)
        {
            _tail = null;
            Count = 0;
            return;
        }

        _head.Previous = null;
        Count--;
    }

    /// <summary>
    /// Removes the last node in the list.
    /// </summary>
    public void Remove()
    {
        if (_tail is null)
        {
            throw new InvalidOperationException("Cannot prune empty list");
        }

        _tail = _tail.Previous;
        
        if (_tail is null)
        {
            _head = null;
            Count = 0;
            return;
        }

        _tail.Next = null;
        Count--;
    }

    /// <summary>
    /// Removes specific node.
    /// </summary>
    /// <param name="node"> Node to be removed.</param>
    public void RemoveNode(DoublyNode<T> node)
    {
        if (node == _head)
        {
            RemoveHead();
            return;
        }

        if (node == _tail)
        {
            Remove();
            return;
        }

        if (node.Previous is null || node.Next is null)
        {
            throw new ArgumentException($"{nameof(node)} cannot have Previous or Next null if it's an internal node");
        }

        node.Previous.Next = node.Next;
        node.Next.Previous = node.Previous;
        
        Count--;
    }

    /// <summary>
    /// Removes a node that contains the data from the parameter.
    /// </summary>
    /// <param name="data"> Data to be removed form the list.</param>
    public void Remove(T data)
    {
        var node = Find(data);
        RemoveNode(node);
    }

    /// <summary>
    /// Looks for the index of the node with the parameter as data.
    /// </summary>
    /// <param name="data"> Data to look for.</param>
    /// <returns>Returns the index of the node if it is found or -1 if the node is not found.</returns>
    public int IndexOf(T data)
    {
        var current = _head;
        var index = 0;
        
        while (current is not null)
        {
            var condition = current.Data is null && data is null ||
                            current.Data is not null && current.Data.Equals(data);
            
            if (condition)
            {
                return index;
            }

            index++;
            current = current.Next;
        }

        return -1;
    }

    /// <summary>
    /// List contains a node that has the parameter as data.
    /// </summary>
    /// <param name="data"> Node to be removed.</param>
    /// <returns>True if the node is found. False if it isn't.</returns>
    public bool Contains(T data) => IndexOf(data) is not -1;
}
