using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestApp.CarClasses;

namespace TestApp.ParkingClasses;

public class ParkingSpace
{
    public Car? ParkedCar { get; set; }
    public int ParkingSpaceNumber { get; set; }
    public bool IsOccupied => ParkedCar != null;
    public bool IsReserved { get; set; } = false;
    public ParkingSpace(int parkingSpaceNumber)
    {
        ParkingSpaceNumber = parkingSpaceNumber;
    }

    public void EmptySpace()
    {
        ParkedCar = null;
    }

    public override string ToString()
    {
        return ParkingSpaceNumber + (IsOccupied ? $"- {ParkedCar!.Id}" : IsReserved ? "- X" : "");
    }
}
