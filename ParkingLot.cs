using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace TestApp;

public class ParkingLot
{
    private CarContainer CarContainer = new();
    private List<ParkingSpace> ParkingSpaces = new();

    public ParkingLot() {
        for (int i = 1; i < 11; i++)
        {
            ParkingSpaces.Add(new(100+i));
        }

        Random random = new Random();

        var firstReservedSpace = random.Next(0,10);
        int secondReservedSpace = firstReservedSpace;

        while(firstReservedSpace == secondReservedSpace)
        {
            secondReservedSpace = random.Next(0,10);
        }

        ParkingSpaces[firstReservedSpace].IsReserved = true;
        ParkingSpaces[secondReservedSpace].IsReserved = true;
    }

    public string EmptyParkingSpace(int id)
    {
        var result = CarContainer.DriveAway(id);

        if (result is null)
            return $"Car of the id {id} does not exist";

        var occupiedParkinSpace = ParkingSpaces.FirstOrDefault(p => p.ParkedCar?.Id == result);
        if (occupiedParkinSpace is null)
            return $"Car of the id {id} does not exist on this parking lot";

        occupiedParkinSpace?.EmptySpace();

        return $"Car of the id {id} has left the parking lot";
    }

    public string ResetIds()
    {
        return CarContainer.ResetIds();
    }

    public string OccupySpace()
    {
        var newCar = CarContainer.GetNewCar();
        int i = 0;
        int j = 0;
        while (i != 10){
            if(!ParkingSpaces[i].IsOccupied && !ParkingSpaces[i].IsReserved)
            {
                ParkingSpaces[i].ParkedCar = newCar;
                newCar.IsParked = true;
                return $"New car of the id {newCar.Id} has parked at {ParkingSpaces[i].ParkingSpaceNumber}";
            }

            i = j%2 == 0 ? i += 5 : i -= 4;
            j++;
        }

        return $"There are no free spaces left. Car of the id {newCar.Id} has decided to leave the premise :C";
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        foreach(var parkingSpace in ParkingSpaces)
        {
            sb.AppendLine(parkingSpace.ToString());
        }

        return sb.ToString();
    }

    public string Visualize()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("     |        |");
        sb.AppendLine("     | Entry  |");
        sb.AppendLine("     |        |");
        sb.AppendLine(" ____|        |____");
        sb.AppendLine("|                  |");

        for (int i = 0; i < 5; i++)
        {
            var firstParkingSpace = ParkingSpaces[i].ToString();
            var secondParkingSpace = ParkingSpaces[i+5].ToString();

            sb.AppendLine($"| {firstParkingSpace.PadRight(9-firstParkingSpace.Length)}   " +
                $"{secondParkingSpace.PadRight(9 - secondParkingSpace.Length)}  |");

        }
        sb.AppendLine("|__________________|");

        return sb.ToString();
    }

    public string SwapReservedSpaces(int fromSpaceId, int toSpaceId)
    {
        throw new NotImplementedException();
    }
}
