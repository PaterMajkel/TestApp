// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;
using TestApp;

var parkingLot = new ParkingLot();

bool toggleVisualize = false;

while (true)
{
    // I know that it's not really what task intended me to do, but I think that it works much better as a toggle and not a button
    if (toggleVisualize)
        Console.WriteLine(parkingLot.Visualize());

    Console.WriteLine($"""
        1.Occupy new space
        2.Empty a space
        3.Show the parking lot
        4.Reset ids
        5.Visualize the parking lot [{(toggleVisualize ? "X" : " ")}]
        6.Quit
        """);

    string userInput = Console.ReadLine();
    Console.Clear();

    switch (userInput)
    {
        case "1":
            {
                Console.WriteLine(parkingLot.OccupySpace());
                break;
            }
        case "2":
            {
                Console.WriteLine("Which car do you want to leave the parking lot?");

                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int value))
                    {
                        Console.WriteLine(parkingLot.EmptyParkingSpace(value));
                        break;
                    }
                    Console.WriteLine("You have entered a wrong value");

                }

                break;
            }
        case "3":
            {
                Console.WriteLine(parkingLot.ToString());
                break;
            }
        case "4":
            {
                Console.WriteLine(parkingLot.ResetIds());
                break;
            }
        case "5":
            {
                toggleVisualize = !toggleVisualize;
                break;
            }
        case "6":
            {
                return;
            }
        default:
            break;
    }



}
