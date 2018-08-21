using System;
using System.Collections.Generic;
using System.Linq;

namespace BreadthFirstSearch
{
    public class BreadthFirstSearch<T> where T : new()
    {
        private List<Node<T>> Frontier { get; set; }
        private List<Node<T>> VisitedNodes { get; set; }

        private readonly ISearchProblem<T> _searchProblem;

        public BreadthFirstSearch(ISearchProblem<T> searchProblem)
        {
            _searchProblem = searchProblem;
            MakeQueue(searchProblem.GetInitialNode());
        }

        public List<Node<T>> Search()
        {
            var solutionNodes = new List<Node<T>>();
            VisitedNodes = new List<Node<T>>();
            Node<T> tempNode = null;

            while (!IsEmpty())
            {
                tempNode = RemoveFront();
                if (_searchProblem.IsGoalNode(tempNode))
                {
                    Console.WriteLine("The goal node is found");
                    break;
                }

                if (IsNodeVisited(tempNode)) continue;
                AddNodes(_searchProblem.ExpandNode(tempNode));
                VisitedNodes.Add(tempNode);
            }

            if (tempNode != null)
            {
                solutionNodes = GetPath(tempNode);
            }

            return solutionNodes;
        }

        private void MakeQueue(Node<T> node)
        {
            Frontier = new List<Node<T>> {node};
        }

        private bool IsNodeVisited(Node<T> node)
        {
            return VisitedNodes.Any(visitedNode => visitedNode.State.Equals(node.State));
        }

        private bool IsEmpty()
        {
            return Frontier.Count == 0;
        }

        private Node<T> RemoveFront()
        {
            var node = Frontier[0];
            Frontier.Remove(node);
            return node;
        }

        private void AddNodes(IEnumerable<Node<T>> nodes)
        {
            Frontier.AddRange(nodes);
        }

        private static List<Node<T>> GetPath(Node<T> node)
        {
            var nodes = new List<Node<T>>();
            do
            {
                nodes.Insert(0, node);
                node = node.ParentNode;
            } while (node.ParentNode != null);
            nodes.Insert(0, node);
            return nodes;
        }
    }
}