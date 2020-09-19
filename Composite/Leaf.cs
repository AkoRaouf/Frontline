using System;
using System.Collections.Generic;
using System.Text;

namespace Frontline.Composite
{
    public interface IPlanet
    {
        void Eat();
    }
    public class Leaf : IPlanet
    {
        public bool IsEaten { get; private set; } = false;
        public void Eat()
        {
            IsEaten = true;
            Console.WriteLine("Leaf eaten!");
        }
    }

    public class Branch : IPlanet
    {
        private readonly List<IPlanet> children;
        public Branch(List<IPlanet> children)
        {
            this.children = children;
        }
        public void Eat()
        {
            foreach (var child in children)
            {
                child.Eat();
            }
        }
    }

    public static class CompostionExample
    {
        public static void MainEn()
        {
            var plants = new List<IPlanet>();
            var branch = new Branch(new List<IPlanet>() { new Leaf(), new Leaf() });
            var anotherBranch = new Branch(new List<IPlanet>() { new Leaf(), new Leaf(), new Leaf(), new Leaf(), new Leaf(), new Leaf() });

            plants.Add(new Branch(new List<IPlanet>() { branch, anotherBranch }));

            plants.ForEach(x => x.Eat());
        }
    }


}
