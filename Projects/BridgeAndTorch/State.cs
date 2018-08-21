namespace BridgeAndTorch
{
    public class State
    {
        public Person[] StartingSide { get; set; }
        public Person[] EndingSide { get; set; }
        public TorchLocation TorchLocation { get; set; }
        
        public State(Person[] startingSide, Person[] endingSide, TorchLocation torchLocation)
        {
            StartingSide = startingSide;
            EndingSide = endingSide;
            TorchLocation = torchLocation;
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

            return StartingSide == item.StartingSide
                   && EndingSide == item.EndingSide
                   && TorchLocation == item.TorchLocation;
        }

        protected bool Equals(State other)
        {
            return Equals(StartingSide, other.StartingSide) && Equals(EndingSide, other.EndingSide) && TorchLocation == other.TorchLocation;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (StartingSide != null ? StartingSide.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (EndingSide != null ? EndingSide.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int) TorchLocation;
                return hashCode;
            }
        }
    }

    public enum TorchLocation
    {
        StartingSide,
        EndingSide
    }
}