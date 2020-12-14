using System;
using System.Collections.Generic;
using System.Text;

namespace designMethod
{
    class soliderRookie:ICharacter
    {
        public override void creatCharacter()
        {
            characterBase = CharacterBase.Instance;
            characterBase.BaseMessage("中尉士兵", 80, "RookieIcon");
        }
    }
}
