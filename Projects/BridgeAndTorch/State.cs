using System.Collections.Generic;

namespace BridgeAndTorch
{
    public class State
    {
        public List<Person> StartingSide { get; set; }
        public List<Person> EndingSide { get; set; }
        public TorchLocation TorchLocation { get; set; }
        
        public State(List<Person> startingSide, List<Person> endingSide, TorchLocation torchLocation)
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

            return StartingSide.Count == item.StartingSide.Count
                   && EndingSide.Count == item.EndingSide.Count
                   && TorchLocation == item.TorchLocation;
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

        public override string ToString()
        {
            var stringToReturn = "StartingSide: ";
            foreach (var person in StartingSide)
            {
                stringToReturn += person.ToString();
            }

            stringToReturn += "\t EndingSide: ";
            foreach (var person in EndingSide)
            {
                stringToReturn += person.ToString();
            }

            stringToReturn += $"\t TorchLocation: {TorchLocation}";
            
            return stringToReturn;
        }
    }

    public enum TorchLocation
    {
        StartingSide,
        EndingSide
    }
}