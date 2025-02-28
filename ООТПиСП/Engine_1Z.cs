using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООТПиСП
{
    public class Engine_1Z : Turbo
    {
        public Engine_1Z()
            : base(
                "1Z 1.9 TDI",
                1.9,
                90,
                210,
                "Images/1Z.jpg"
            )
        {
        }
    }
}