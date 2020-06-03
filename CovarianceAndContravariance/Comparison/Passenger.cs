using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Frontline.CovarianceAndContravariance.Comparison
{
    public class Passenger
    {
        public string Name { get; }
        public string LastName { get; }
        public string PassportNo { get; }
        public string Nationality { get; }

        public Passenger(string name, string lastName, string passportNo, string nationality)
        {
            this.Name = name;
            this.LastName = lastName;
            this.PassportNo = passportNo;
            this.Nationality = nationality;
        }

        public static int CompareByName(Passenger passenger1, Passenger passenger2)
        {
            return String.Compare(passenger1.Name, passenger2.Name);
        }

        public static int CompareByLastName(Passenger passenger1, Passenger passenger2)
        {
            return String.Compare(passenger1.LastName, passenger2.LastName);
        }

        public static int CompareNationality(Passenger passenger1, Passenger passenger2)
        {
            return String.Compare(passenger1.Nationality, passenger2.Nationality);
        }
    }

    public class TestPassengerSort
    {
        Passenger p1 = new Passenger("Johon", "Floid", "A123456789", "USA");
        Passenger p2 = new Passenger("Jo", "Sina", "A987463215", "UAE");
        Passenger p3 = new Passenger("Ped", "Zoola", "A987855215", "Italy");

        public void SortThem()
        {
            Passenger[] passengers = new Passenger[] { p1, p2, p3 };
            List<Passenger> passengerList = new List<Passenger> { p1, p2, p3 };

            Array.Sort(passengers, Passenger.CompareByName);
            Array.Sort(passengers, Passenger.CompareByLastName);
            Array.Sort(passengers, Passenger.CompareNationality);

            passengerList.Sort(Passenger.CompareByName);
            passengerList.Sort(Passenger.CompareByLastName);
            passengerList.Sort(Passenger.CompareNationality);

            passengerList.OrderBy(x => x.Name);
        }
    }
}
