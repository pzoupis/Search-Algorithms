using System;
using System.Collections.Generic;
using BreadthFirstSearch;

namespace BreadthFirstImplementation
{
    public class SearchProblem : ISearchProblem<State>
    {        
        public bool IsGoalNode(Node<State> node)
        {
            var state = new State(5);
            return state.Equals(node.State);
        }

        public Node<State> GetInitialNode()
        {
            var node = new Node<State>(null, new State(1), "Initial node", 0, 0);
            return node;
        }

        public IList<Node<State>> ExpandNode(Node<State> node)
        {
            var newNodes = new List<Node<State>> {Action(node, 1), Action(node, 2), Action(node, 3)};
            return newNodes;
        }

        private Node<State> Action(Node<State> node, int number)
        {
            var newNode = new Node<State>(node);
            var state = new State(node.State.Number + number);
            newNode.State = state;
            newNode.Action = $"On node {node.State.Number} add {number}";
            Console.WriteLine(newNode.Action);
            return newNode;
        }
    }
}