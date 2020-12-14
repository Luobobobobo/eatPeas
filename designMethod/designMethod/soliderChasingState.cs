using System;
using System.Collections.Generic;
using System.Text;

namespace designMethod
{
    public class soliderChasingState : soliderBaseState
    {
        public override void _AIbaseState(soliderTest solider)
        {
            Console.WriteLine("敌方士兵正在追击，请躲避！");
        }
    }
}
