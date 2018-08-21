using System;
using BreadthFirstSearch;

namespace BreadthFirstImplementation
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("Hello World!");
            var searchProblem = new SearchProblem();
            var breadthFirstSearch = new BreadthFirstSearch<State>(searchProblem);
            var solution = breadthFirstSearch.Search();
            foreach (var node in solution)
            {
                Console.WriteLine(node.Action);
            }
        }
    }
}