using System;
using System.Collections.Generic;
using System.Text;

namespace designMethod
{
    public class CreatCharacter
    {
        public Dictionary<int, ICharacter> _dicCharacter;
        public void init()
        {
            _dicCharacter = new Dictionary<int, ICharacter>();
            _dicCharacter.Add(0, new soliderCaptain());
            _dicCharacter.Add(1, new soliderRookie());
            _dicCharacter.Add(2, new soliderSergeant());
        }
        public void creatSolider()
        {
            Console.Write("请输入数字0~2中的一个：");
            int num = int.Parse(Console.ReadLine());
            _dicCharacter.TryGetValue(num, out ICharacter character);
            character.creatCharacter();
            Console.WriteLine(character.characterBase.ToString());
        }
    }
}
