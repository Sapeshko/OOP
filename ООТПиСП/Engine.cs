using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООТПиСП
{
    public class Engine
{
    public string Model { get; set; }
    public double Displacement { get; set; } 
    public int Power { get; set; }
    public int Torque { get; set; } 
    public string ImagePath { get; set; } 

    public Engine(string model, double displacement, int power, int torque, string imagePath)
    {
        Model = model;
        Displacement = displacement;
        Power = power;
        Torque = torque;
        ImagePath = imagePath;
    }

    public virtual string GetInfo()
    {
            return $"Модель: {Model}\n" +
                   $"Объем: {Displacement} л\n" +
                   $"Мощность: {Power} л.с.\n" +
                   $"Крутящий момент: {Torque} Нм\n";
    }
}
}