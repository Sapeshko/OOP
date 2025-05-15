using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООТПиСП
{
    [Serializable]
    public class Engine_AAA : NoFazeRegul
    {
        public Engine_AAA()
            : base(
                "AAA 2.8",
                2.8,
                174,
                235,
                "Images/AAA.jpg"
            )
        {
        }
    }
}