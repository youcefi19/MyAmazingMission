namespace MyAmazingMission.Arbres
{
    public class Node
    {
        public int Value { get; set; }

        public Node? LeftChild { get; set; }

        public Node? RightChild { get; set; }

        public Node(int value)
        {
            Value = value;
        }

        public Node(int value, Node? leftChild = null, Node? rightChild = null) : this(value)
        {
            LeftChild = leftChild;
            RightChild = rightChild;
        }
    }
}
