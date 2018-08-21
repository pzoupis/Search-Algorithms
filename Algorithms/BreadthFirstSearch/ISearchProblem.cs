using System.Collections.Generic;

namespace BreadthFirstSearch
{
    public interface ISearchProblem<T> where T : new()
    {
        bool IsGoalNode(Node<T> node);
        Node<T> GetInitialNode();
        IList<Node<T>> ExpandNode(Node<T> node);
    }
}