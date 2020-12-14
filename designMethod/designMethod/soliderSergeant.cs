using System;
using System.Collections.Generic;
using System.Text;

namespace designMethod
{
    class soliderSergeant:ICharacter
    {
        public override void creatCharacter()
        {
            characterBase = CharacterBase.Instance;
            characterBase.BaseMessage("新兵", 50, "SergeantIcon");
        }
    }
}
