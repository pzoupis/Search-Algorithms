using System;
using System.Linq;
using BreadthFirstSearch;

namespace BridgeAndTorch
{
    internal class Program
    {
        private static void Main()
        {
            var searchProblem = new SearchProblem();
            var breadthFirstSearch = new BreadthFirstSearch<State>(searchProblem, false);
            var solution = breadthFirstSearch.Search();
            foreach (var node in solution)
            {
                Console.WriteLine(node.Action);
            }

            Console.WriteLine($"The solution was found in depth: {solution.Last()?.Depth} and the path cost was: {solution.Last()?.PathCost}");
        }
    }
}