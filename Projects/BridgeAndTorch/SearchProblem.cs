using System;
using System.Collections.Generic;
using System.Linq;
using BreadthFirstSearch;

namespace BridgeAndTorch
{
    public class SearchProblem : ISearchProblem<State>
    {
        public Node<State> InitialNode { get; set; }
        public Node<State> GoalNode { get; set; }
        
        public SearchProblem()
        {
            var person1 = new Person("A", 1);
            var person2 = new Person("B", 2);
            var person3 = new Person("C", 5);
            var person4 = new Person("D", 10);
            
            var initialState = new State
            {
                StartingSide = new List<Person>
                {
                    person1, person2, person3, person4
                },
                EndingSide = new List<Person>{},
                TorchLocation = TorchLocation.StartingSide
            };
            
            var endingState = new State
            {
                StartingSide = new List<Person>{},
                EndingSide = new List<Person>
                {
                    person1, person2, person3, person4
                },
                
                TorchLocation = TorchLocation.EndingSide
            };
            
            InitialNode = new Node<State>(null, initialState, "Initial Node", 0, 0);
            GoalNode = new Node<State>(null, endingState, "Goal Node", 17, 0);
        }
        
        public bool IsGoalNode(Node<State> node)
        {
            return GoalNode.State.Equals(node.State) && GoalNode.PathCost.Equals(node.PathCost);
        }

        public Node<State> GetInitialNode()
        {
            return InitialNode;
        }

        public IList<Node<State>> ExpandNode(Node<State> node)
        {
            var expandedNodes = new List<Node<State>>();

            if (node.State.TorchLocation == TorchLocation.StartingSide)
            {
                var combinations = GetPersonCombinations(node.State.StartingSide);
                foreach (var combination in combinations)
                {
                    var tempNode = MoveTwoPeople(node, combination);
                    expandedNodes.Add(tempNode);
                }
            }
            else
            {
                for (var i = 0; i < node.State.EndingSide.Count; i++)
                {
                    var tempNode = MoveOnePerson(node, i);
                    expandedNodes.Add(tempNode);
                }
            }

            return expandedNodes;
        }

        private Node<State> MoveTwoPeople(Node<State> node, IEnumerable<int> peopleToMove)
        {
            var newNode = new Node<State>(node);
            var startingSide = new List<Person>(node.State.StartingSide);
            var endingSide = new List<Person>(node.State.EndingSide);
            var tempList = new List<Person>();
            foreach (var i in peopleToMove)
            {
                endingSide.Add(startingSide[i]);
                tempList.Add(startingSide[i]);
            }

            foreach (var person in tempList)
            {
                startingSide.Remove(person);
            }

            endingSide = endingSide.OrderBy(c => c.Name).ToList();
            startingSide = startingSide.OrderBy(c => c.Name).ToList();

            newNode.State.StartingSide = startingSide;
            newNode.State.EndingSide = endingSide;
            newNode.State.TorchLocation = TorchLocation.EndingSide;
            newNode.Depth += 1;
            newNode.Action = $"Move {tempList[0]?.Name} and {tempList[1]?.Name} to the ending side";
            newNode.PathCost += Math.Max(tempList[0].Speed, tempList[1].Speed);
            return newNode;
        }

        private Node<State> MoveOnePerson(Node<State> node, int person)
        {
            var newNode = new Node<State>(node);
            var startingSide = new List<Person>(node.State.StartingSide);
            var endingSide = new List<Person>(node.State.EndingSide);

            startingSide.Add(endingSide[person]);
            newNode.Action = $"Move {endingSide[person].Name} to the starting side";
            newNode.PathCost += endingSide[person].Speed;
            endingSide.Remove(endingSide[person]);

            endingSide = endingSide.OrderBy(c => c.Name).ToList();
            startingSide = startingSide.OrderBy(c => c.Name).ToList();

            newNode.State.StartingSide = startingSide;
            newNode.State.EndingSide = endingSide;
            newNode.State.TorchLocation = TorchLocation.StartingSide;
            newNode.Depth += 1;
            return newNode;
        }

        private static IEnumerable<int[]> GetPersonCombinations(IReadOnlyCollection<Person> people)
        {
            var combinations = new List<int[]>();
            
            for (var i = 0; i < people.Count - 1; i++)
            {
                for (var j = i + 1; j < people.Count; j++)
                {
                    combinations.Add(new int[] {i, j});
                }
            }

            return combinations;
        }
    }
}