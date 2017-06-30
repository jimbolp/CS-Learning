using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        public class Bicycle
        {
            private int cadence;
            private int gear;
            private int speed;
            protected Bicycle() { }
            protected Bicycle(int startCadence, int startGear, int startSpeed)
            {
                gear = startGear;
                cadence = startCadence;
                speed = startSpeed;
            }
            public void setCadence(int newValue)
            {
                cadence = newValue;
            }
            public void setGear(int newValue)
            {
                gear = newValue;
            }
            public void Break(int decrement)
            {
                speed -= decrement;
            }
            public void speedUp(int increment)
            {
                speed += increment;
            }
        }
        public class MountainBike : Bicycle
        {
            private int seatHeight;
            public MountainBike(int seatHeight, int startCadence, int startGear, int startSpeed) :
                base(startCadence, startGear, startSpeed)
            {
                this.seatHeight = seatHeight;
            }
            public void setHeight(int newValue)
            {
                seatHeight = newValue;
            }

        }
    }
}
 
