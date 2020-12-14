using System;
using System.Collections.Generic;
using System.Text;

namespace designMethod
{
    public class soliderTest
    {
        soliderBaseState currentState;
        public void SetState(soliderBaseState soliderBaseState)
        {
            currentState = soliderBaseState;
        }

        public void displayState()
        {
            float i=_distance();
            Console.WriteLine("玩家与敌方士兵之间的距离为{0}", i);
            if (i > 5)
            {
                SetState(new soliderNomalState());
                currentState._AIbaseState(this);
            }
            else 
            {
                SetState(new soliderChasingState());
                currentState._AIbaseState(this);
            }
        }

        public float _distance()
        {
            Random rd = new Random();
            float dis = rd.Next(0, 20);
            return dis;
        }
    }
}
