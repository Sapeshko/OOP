using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООТПиСП
{
    [Serializable]
    public class GasolineEngine : Engine
    {
        public string FuelType { get; set; } = "Бензин";

        public GasolineEngine() { }

        public GasolineEngine(string model, double displacement, int power, int torque, string imagePath)
            : base(model, displacement, power, torque, imagePath)
        {
        }

        public override string ToString()
        {
            return base.ToString() + $"Тип топлива: {FuelType}\n";
        }
    }
}


