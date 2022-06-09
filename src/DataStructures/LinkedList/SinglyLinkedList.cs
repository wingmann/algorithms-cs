using Wingmann.DataStructures.LinkedList.Internal;

namespace Wingmann.DataStructures.LinkedList;

public class SinglyLinkedList<T>
{
    // Points to the start of the list.
    private SinglyNode<T>? Head { get; set; }

    /// <summary>
    /// Adds new node to the start of the list.
    /// Time complexity: O(1), space complexity: O(1).
    /// </summary>
    /// <param name="data">Contents of newly added node.</param>
    /// <returns>Added list node.</returns>
    public SinglyNode<T> AddFirst(T data)
    {
        var newListElement = new SinglyNode<T>(data)
        {
            Next = Head,
        };

        Head = newListElement;
        return newListElement;
    }

    /// <summary>
    /// Adds new node to the end of the list.
    /// Time complexity: O(n), space complexity: O(1), where n - number of nodes in the list.
    /// </summary>
    /// <param name="data">Contents of newly added node.</param>
    /// <returns>Added list node.</returns>
    public SinglyNode<T> AddLast(T data)
    {
        SinglyNode<T> newElement = new(data);

        // Added element is the first, hence it is the head.
        if (Head is null)
        {
            Head = newElement;
            return newElement;
        }

        // Temp ListElement to avoid overwriting the original.
        var temp = Head;

        // iterates through all elements
        while (temp.Next is not null)
        {
            temp = temp.Next;
        }

        // Adds the new element to the last one.
        temp.Next = newElement;
        return newElement;
    }

    /// <summary>
    /// Returns element at index <paramref name="index" /> in the list.
    /// </summary>
    /// <param name="index">Index of an element to be returned.</param>
    /// <returns>Element at index <paramref name="index" />.</returns>
    public T GetElementByIndex(int index)
    {
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        var temp = Head;

        for (var i = 0; temp is not null && i < index; i++)
        {
            temp = temp.Next;
        }

        if (temp is null)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        return temp.Data;
    }

    public int Length()
    {
        // Checks if there is a head.
        if (Head is null)
        {
            return 0;
        }

        var temp = Head;
        var length = 1;

        while (temp.Next is not null)
        {
            temp = temp.Next;
            length++;
        }

        return length;
    }

    public IEnumerable<T> GetListData()
    {
        // Temporary list element to avoid overwriting the original.
        var temp = Head;

        // All elements where a next attribute exists.
        while (temp is not null)
        {
            yield return temp.Data;
            temp = temp.Next;
        }
    }

    public bool DeleteElement(T element)
    {
        var currentElement = Head;
        SinglyNode<T>? previousElement = null;

        // Iterates through all elements.
        while (currentElement is not null)
        {
            // Checks if the element, which should get deleted is in this list element.
            var noValue = currentElement.Data is null && element is null;
            var equals = currentElement.Data is not null && currentElement.Data.Equals(element);
            
            if (noValue || equals)
            {
                // Take the next one as head.
                if (currentElement.Equals(Head))
                {
                    Head = Head.Next;
                    return true;
                }

                // Else take the prev one and overwrite the next with the one behind the deleted.
                if (previousElement is not null)
                {
                    previousElement.Next = currentElement.Next;
                    return true;
                }
            }

            // Iterating.
            previousElement = currentElement;
            currentElement = currentElement.Next;
        }

        return false;
    }
}
