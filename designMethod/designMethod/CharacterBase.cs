using System;
using System.Collections.Generic;
using System.Text;

namespace designMethod
{
    public class CharacterBase
    {
        private static CharacterBase instance = null;
        private CharacterBase() { }
        public static CharacterBase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CharacterBase();
                }
                return instance;
            }
        }
        public string _name;
        public float _maxHp;
        public string _iconSprite;
        public void BaseMessage(string name, float maxHp, string iconSprite)
        {
            this._name = name;
            this._maxHp = maxHp;
            this._iconSprite = iconSprite;
        }
        public override string ToString()
        {
            return string.Format("我是{0},我的血量是{1},我的勋章是{2}", _name, _maxHp, _iconSprite);
        }
    }
}
