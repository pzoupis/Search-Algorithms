using System.Collections.Generic;
using BreadthFirstSearch;

namespace BridgeAndTorch
{
    public class SearchProblem : ISearchProblem<State>
    {
        public Node<State> InitialNode { get; set; }
        public Node<State> GoalNode { get; set; }
        
        public SearchProblem()
        {
            Person person1 = new Person("A", 1);
            Person person2 = new Person("B", 2);
            Person person3 = new Person("C", 5);
            Person person4 = new Person("D", 10);
            
            State initialState = new State
            {
                StartingSide = new []
                {
                    person1, person2, person3, person4
                },
                EndingSide = new Person[]{},
                TorchLocation = TorchLocation.StartingSide
            };
            
            State endingState = new State
            {
                StartingSide = new Person[]{},
                EndingSide = new []
                {
                    person1, person2, person3, person4
                },
                
                TorchLocation = TorchLocation.EndingSide
            };
            
            InitialNode = new Node<State>(null, initialState, "Initial Node", 0, 0);
            GoalNode = new Node<State>(null, endingState, "Goal Node", 0, 0);
        }
        
        public bool IsGoalNode(Node<State> node)
        {
            return GoalNode.State.Equals(node.State);
        }

        public Node<State> GetInitialNode()
        {
            return InitialNode;
        }

        public IList<Node<State>> ExpandNode(Node<State> node)
        {
            throw new System.NotImplementedException();
        }

        private Node<State> MoveTwoPeople(Node<State> node, int[] peopleToMove)
        {
            var newNode = new Node<State>(node);
            var startingSide = new Person[4];
            var endingSide = new Person[4];
            var State = new State(startingSide, endingSide, TorchLocation.EndingSide);

            return newNode;
        }

        private List<int[]> GetPersonCombinations(IReadOnlyCollection<Person> people)
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