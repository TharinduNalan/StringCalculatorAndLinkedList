using CustomLinkList.Contract;

namespace CustomLinkList.Core
{
    public class GenericLinkedList<T>
    {
        public Node<T>? Root => _root;

        private Node<T>? _root;
        private readonly IOutputPrinter _printer;

        public GenericLinkedList(IOutputPrinter printer)
        {
            _printer = printer;
        }

        // Assumption: When inserting a new node it will try to insert to the given position. 
        // but if the given position is not available (eg: position is too larger than current length)
        // then this will insert the item to the last and return it's position
        public int Insert(int position, T data)
        {
            // if root is null then adding to the root
            if (_root == null)
            {
                _root = new Node<T>(data);
                return 1;
            }

            // since the indexing start from 1 2nd position is the root next.
            // so the correct place to add the new node is (position - 1).Next which same as currentNode.Next
            int currentPosition = 2;
            Node<T> currentNode = _root;
            while (currentNode.Next != null && currentPosition < position)
            {
                currentPosition++;
                currentNode = currentNode.Next;
            }

            // create the new node and set it's previous link to current node
            var node = new Node<T>(data);
            node.Previous = currentNode;

            // keep the next links with moving immediate next node into the new node's next
            node.Next = currentNode.Next;
            currentNode.Next = node;

            // if there are nodes further then set previous links of the immediate next node
            if (node.Next != null)
            {
                node.Next.Previous = node;
            }

            return currentPosition;
        }

        public T? Delete(int position)
        {
            // if no items then return null
            if (_root == null)
            {
                return default;
            }

            // if deleting root
            if (position == 1)
            {
                T rootData = _root.Data;
                _root = _root.Next;
                if (_root != null)
                {
                    _root.Previous = null;
                }
                return rootData;
            }

            // finding the correct position to delete
            int currentPosition = 2;
            Node<T> currentNode = _root;
            while (currentNode.Next != null && currentPosition < position)
            {
                currentPosition++;
                currentNode = currentNode.Next;
            }

            // if cannot find the requested position to delete
            if (currentNode.Next == null)
            {
                return default;
            }

            // set next and previous links and remove all the links to the node in position so GC will clean it
            T data = currentNode.Next.Data;
            currentNode.Next = currentNode.Next.Next;
            if (currentNode.Next != null)
            {
                currentNode.Next.Previous = currentNode;
            }

            return data;
        }

        public void PrintList()
        {
            if (_root == null)
            {
                return;
            }

            Node<T>? currentNode = _root;
            do
            {
                _printer.Print(currentNode.Data!.ToString());
                currentNode = currentNode.Next;
            }
            while (currentNode != null);
        }
    }
}
