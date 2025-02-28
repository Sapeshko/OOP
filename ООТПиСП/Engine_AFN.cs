using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООТПиСП
{
    public class Engine_AFN : Turbo
    {
        public Engine_AFN()
            : base(
                "AFN 1.9 TDI",
                1.9,
                110,
                235,
                "Images/AFN.jpg"
            )
        {
        }
    }
}
