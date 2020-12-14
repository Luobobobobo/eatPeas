using System;
using designMethod;

namespace designMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                CreatCharacter creatCharacter = new CreatCharacter();
                creatCharacter.init();
                creatCharacter.creatSolider();
                soliderTest soliderTest = new soliderTest();
                soliderTest.displayState();
                Console.ReadKey();
            }
        }
    }
}
