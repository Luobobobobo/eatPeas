using System;
using System.Collections.Generic;
using System.Text;

namespace designMethod
{
    class soliderCaptain:ICharacter
    {
        public override void creatCharacter()
        {
            
           characterBase = CharacterBase.Instance;
            characterBase.BaseMessage("上尉士兵", 100, " CaptainIcon");
        }
    }
}
