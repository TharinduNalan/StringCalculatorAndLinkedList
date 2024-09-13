namespace CustomLinkList.Core
{
    public class Node<T>
    {
        public T Data { get; set; }

        public Node<T>? Next { get; set; }

        // Supporting for a double linked list
        public Node<T>? Previous { get; set; }

        public Node(T data)
        {
            Data = data;
        }
    }
}
