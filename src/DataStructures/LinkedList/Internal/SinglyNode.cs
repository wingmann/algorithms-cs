namespace DataStructures.LinkedList.Internal;

public class SinglyNode<T>
{
    public T Data { get; }
    
    public SinglyNode<T>? Next { get; set; }

    public SinglyNode(T data)
    {
        Data = data;
        Next = null;
    }
}
