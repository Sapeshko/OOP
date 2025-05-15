using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООТПиСП
{
    [Serializable]
    public class Engine_AAB : Atmo
    {
        public Engine_AAB()
            : base(
                "AAB 2.4 D",
                2.4,
                78,
                164,
                "Images/AAB.jpg"
            )
        {
        }
    }
}