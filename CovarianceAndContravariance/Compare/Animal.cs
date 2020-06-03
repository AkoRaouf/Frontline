using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Frontline.CovarianceAndContravariance.Compare
{
    public class Animal : IComparable, IEquatable<Animal>
    {
        public string Name { get; set; }
        public int MaxSpeed { get; set; }

        public int CompareTo(object obj)
        {
            if (!(obj is Animal))
            {
                throw new ArgumentException("It is not an animal");
            }

            Animal animal = obj as Animal;
            return Name.CompareTo(animal.Name);
        }

        public bool Equals([AllowNull] Animal other)
        {
            return this.Name == other.Name && this.MaxSpeed == other.MaxSpeed;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.MaxSpeed.GetHashCode();
        }
    }

    public class AnimalComparer : IComparer<Animal>
    {
        public enum SortBy
        {
            Name,
            MaxSpeed
        }
        public SortBy compareField = SortBy.Name;
        public int Compare([AllowNull] Animal x, [AllowNull] Animal y)
        {
            switch (compareField)
            {
                case SortBy.Name:
                    return x.Name.CompareTo(y.Name);
                case SortBy.MaxSpeed:
                    return x.MaxSpeed.CompareTo(y.MaxSpeed);
                default:
                    return x.Name.CompareTo(y.Name);
            }
        }
    }

    public class Application
    {
        public static void MainPo(string[] args)
        {
            Animal[] animals = new Animal[]
            {
                new Animal(){Name = "Fox", MaxSpeed = 50},
                new Animal() { Name = "Pig", MaxSpeed = 10},
                new Animal() {Name = "Lion", MaxSpeed = 20}
            };

            Array.Sort(animals);
            var comprare = new AnimalComparer();
            comprare.compareField = AnimalComparer.SortBy.Name;
            Array.Sort(animals, comprare);
        }
    }
}
