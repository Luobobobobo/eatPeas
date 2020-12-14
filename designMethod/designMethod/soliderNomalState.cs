using System;
using System.Collections.Generic;
using System.Text;

namespace designMethod
{
    public class soliderNomalState : soliderBaseState
    {
        public override void _AIbaseState(soliderTest solider)
        {
            Console.WriteLine("敌方士兵正在巡游，请小心绕行！");
        }
    }
}
