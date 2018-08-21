namespace BreadthFirstImplementation
{
    public class State
    {
        public int Number { get; }

        public State(int number)
        {
            Number = number;
        }

        public State()
        {
            
        }

        public override bool Equals(object obj)
        {
            if (!(obj is State item))
            {
                return false;
            }

            return item.Number == Number;
        }

        public override int GetHashCode()
        {
            return Number;
        }
    }
}