using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООТПиСП
{

    [Serializable]
    public class NoFazeRegul : GasolineEngine
    {

        public string ISFazeRegul { get; set; } = "Нет";

        public NoFazeRegul() { }

        public NoFazeRegul(string model, double displacement, int power, int torque, string imagePath)
            : base(model, displacement, power, torque, imagePath)
        {
        }

        public override string ToString()
        {
            return base.ToString() + $"Фазорегулятор: {ISFazeRegul}\n";
        }

    }
}
