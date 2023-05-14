﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp;

public class CarContainer
{
    private List<Car> Cars = new();
    public Car GetNewCar()
    {
        int? lastId = Cars.LastOrDefault()?.Id;
        Car car = new(lastId);
        Cars.Add(car);
        return car;
    }

    public int? DriveAway(int id)
    {
        var car = Cars.FirstOrDefault(p => p.Id == id && p.IsParked);
        
        if (car is null) return null;

        car.IsParked = false;

        return car.Id;
    }

    public string ResetIds()
    {
        Cars.RemoveAll(p => !p.IsParked);
        int id = 0;
        Cars.ForEach(p => p.Id = ++id);

        return "Cars have been assigned new ids";
    }
}
