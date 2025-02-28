using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООТПиСП
{
    public class DieselEngine : Engine
    {
        public string FuelType { get; set; } = "Дизель";

        public DieselEngine(string model, double displacement, int power, int torque, string imagePath)
            : base(model, displacement, power, torque, imagePath)
        {
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $"Тип топлива: {FuelType}\n";
        }
    }
}
