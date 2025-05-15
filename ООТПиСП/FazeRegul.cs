using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООТПиСП
{

    [Serializable]
    public class FazeRegul: GasolineEngine
    {


        public string ISFazeRegul { get; set; } = "Да";

        public FazeRegul() { }

        public FazeRegul(string model, double displacement, int power, int torque, string imagePath)
            : base(model, displacement, power, torque, imagePath)
        {
        }

        public override string ToString()
        {
            return base.ToString() + $"Фазорегулятор: {ISFazeRegul}\n";
        }

    }
}
