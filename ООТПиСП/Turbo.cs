using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace ООТПиСП
{
    public class Turbo : DieselEngine
    {

        public string ISTurbo { get; set; } = "Турбонаддув";

        public Turbo(string model, double displacement, int power, int torque, string imagePath)
            : base(model, displacement, power, torque, imagePath)
        {
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $"Тип наддува: {ISTurbo}\n";
        }

    }
}
