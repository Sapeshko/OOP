using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООТПиСП
{
    [Serializable]
    public class Atmo : DieselEngine
    {
        public string ISTurbo { get; set; } = "Атмосферный";

        public Atmo() { }

        public Atmo(string model, double displacement, int power, int torque, string imagePath)
            : base(model, displacement, power, torque, imagePath)
        {
        }

        public override string ToString()
        {
            return base.ToString() + $"Тип наддува: {ISTurbo}\n";
        }
    }
}


