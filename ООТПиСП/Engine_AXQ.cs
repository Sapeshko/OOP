using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООТПиСП
{
    public class Engine_AXQ : FazeRegul
    {
        public Engine_AXQ()
            : base(
                "AXQ 4.2",
                4.2,
                310,
                410,
                "Images/AXQ.jpg"
            )
        {
        }
    }
}