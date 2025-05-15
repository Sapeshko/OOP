using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ООТПиСП
{
    [Serializable]
    [XmlInclude(typeof(FazeRegul))]    
    [XmlInclude(typeof(NoFazeRegul))]
    [XmlInclude(typeof(Turbo))]
    [XmlInclude(typeof(Atmo))]
    [XmlInclude(typeof(Engine_1Z))]
    [XmlInclude(typeof(Engine_AFN))]
    [XmlInclude(typeof(Engine_AAA))]
    [XmlInclude(typeof(Engine_AXZ))]
    [XmlInclude(typeof(Engine_AAB))]
    [XmlInclude(typeof(Engine_AXQ))]
    public class Engine
    {
        public string Model { get; set; }
        public double Displacement { get; set; }
        public int Power { get; set; }
        public int Torque { get; set; }
        public string ImagePath { get; set; }

        public Engine() { }

        public Engine(string model, double displacement, int power, int torque, string imagePath)
        {
            Model = model;
            Displacement = displacement;
            Power = power;
            Torque = torque;
            ImagePath = imagePath;
        }

        public override string ToString()
        {
            return $"Модель: {Model}\n" +
                   $"Объем: {Displacement} л\n" +
                   $"Мощность: {Power} л.с.\n" +
                   $"Крутящий момент: {Torque} Нм\n";
        }
    }
}
