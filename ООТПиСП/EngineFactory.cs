using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООТПиСП
{
    public static class EngineFactory
    {
        private static readonly Dictionary<string, Func<string, double, int, int, string, Engine>> engineConstructors
            = new Dictionary<string, Func<string, double, int, int, string, Engine>>
        {
        { "GasolineFazeReg", (model, disp, power, torque, img) => new FazeRegul(model, disp, power, torque, img) },
        { "GasolineNoFazeReg", (model, disp, power, torque, img) => new NoFazeRegul(model, disp, power, torque, img) },
        { "DieselTurbo", (model, disp, power, torque, img) => new Turbo(model, disp, power, torque, img) },
        { "DieselAtmo", (model, disp, power, torque, img) => new Atmo(model, disp, power, torque, img) }
        };

        public static Engine CreateEngine(string typeKey, string model, double displacement, int power, int torque, string imagePath)
        {
            if (engineConstructors.TryGetValue(typeKey, out var constructor))
            {
                return constructor(model, displacement, power, torque, imagePath);
            }

            throw new ArgumentException("Неизвестный тип двигателя: " + typeKey);
        }
    }

}
