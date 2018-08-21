using System;

namespace BridgeAndTorch
{
    public class Person
    {
        public string Name { get; set; }
        public int Speed { get; set; }

        public Person(string name, int speed)
        {
            Name = name;
            Speed = speed;
        }
    }
}