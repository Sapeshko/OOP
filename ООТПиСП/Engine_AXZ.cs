using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООТПиСП
{
    public class Engine_AXZ : FazeRegul
    {
        public Engine_AXZ()
            : base(
                "AXZ 3.2",
                3.2,
                250,
                330,
                "Images/AXZ.jpg"
            )
        {
        }
    }
}
