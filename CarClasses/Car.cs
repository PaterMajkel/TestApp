using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.CarClasses;

public class Car
{
    public int Id { get; set; }
    public bool IsParked { get; set; } = false;
    public Car(int? id)
    {
        Id = id is null ? 1 : id.Value + 1;
    }
}
