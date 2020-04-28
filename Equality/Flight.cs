using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Equality
{
    public class Flight
    {
        public string Name { get; }
        public string Number { get; }

        public Flight(string name, string number)
        {
            this.Name = name;
            this.Number = number;
        }

        public override bool Equals(object obj) => Equal(obj as Flight);

        private bool Equal(Flight objB)
        {
            if (!ReferenceEquals(this, null) && !ReferenceEquals(objB, null) && (this.Name == objB.Name && this.Number == objB.Number))
                return true;
            return false;
        }

        public override int GetHashCode()
          => this.Name.GetHashCode() ^ this.Number.GetHashCode();
    }
}
