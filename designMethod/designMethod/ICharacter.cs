using System;
using System.Collections.Generic;
using System.Text;

namespace designMethod
{
    public abstract class ICharacter
    {
        public CharacterBase characterBase;
        public ICharacter()
        {
          
        }
        public abstract void creatCharacter();
    }
}
