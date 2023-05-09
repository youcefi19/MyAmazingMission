namespace MyAmazingMission.ListeChainee
{
    internal class LinkedList
    {
        public Node? Root { get; set; }

        public void ViewList()
        {
            Node? current = Root;
            while (current != null)
            {
                Console.Write($"{current.Value} -- ");
                current = current.Next;
            }
            Console.WriteLine(Environment.NewLine);
        }

        public int CountNodes()
        {
            int count = 0;
            Node? current = Root;

            while (current != null)
            {
                count++;
                current = current.Next;
            }

            return count;
        }

        public Node? FindMiddle()
        {
            int count = CountNodes();
            if (count == 0) return null;
            else if (count == 1) return Root;
            else
            {
                int middle = count / 2;
                Node? target = Root;
                for (int i = 0; i < middle; i++)
                {
                    target = target.Next;
                }
                return target;
            }
        }

        public Node? Previous(Node node)
        {
            Node? current = Root;
            while (current != null && current.Next != node)
            {
                current = current.Next;
            }

            return current;
        }

        public void Remove(Node node)
        {
            Node? previous = Previous(node);
            if (previous == null)
            {
                Root = node.Next;
            }
            else
            {
                previous.Next = node.Next;
            }
        }

        public void Invert()
        {
            Node? previous = null;
            Node? current = Root;

            while (current != null)
            {
                Node? next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            Root = previous;
        }

        public void InsertRoot(Node node)
        {
            if (Root == null) Root = node;
            else
            {
                node.Next = Root;
                Root = node;
            }
        }

        public void InsertAfter(Node target, Node newNode)
        {
            if (Root == null)
            {
                Root = newNode;
                Root.Next = null;
            }
            else
            {
                newNode.Next = target.Next;
                target.Next = newNode;
            }
        }

        public void InsertBefore(Node target, Node newNode)
        {
            if (Root == null)
            {
                Root = newNode;
                Root.Next = null;
            }
            else
            {
                Node? previous = Previous(target);
                if (previous == null)
                {
                    Root = newNode;
                    Root.Next = target;
                }
                else
                {
                    previous.Next = newNode;
                    newNode.Next = target;
                }
            }
        }
    }
}
