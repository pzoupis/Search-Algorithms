namespace BreadthFirstSearch
{
    public class Node<T> where T : new()
    {
        public Node<T> ParentNode { get; }
        public T State { get; set; }
        public string Action { get; set; }
        public int PathCost { get; set; }
        public int Depth { get; set; }
        
        public Node(Node<T> parentNode, T state, string action, int pathCost, int depth)
        {
            ParentNode = parentNode;
            State = state;
            Action = action;
            PathCost = pathCost;
            Depth = depth;
        }

        public Node(Node<T> node)
        {
            ParentNode = node;
            State = new T();
            Action = node.Action;
            PathCost = node.PathCost;
            Depth = node.Depth;
        }
    }
}