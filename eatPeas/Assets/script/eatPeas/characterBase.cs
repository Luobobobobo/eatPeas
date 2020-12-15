using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌人的基础属性类
/// </summary>
public class characterBase 
{
    public string _name;
    public float maxHp;
    public string iconSprite;
    public Vector3 originPos;
    public float solidSpeed;

    public void baseMessage(string Name, float MaxHp, string IconSprite)
    {
        this._name = Name;
        this.maxHp = MaxHp;
        this.iconSprite = IconSprite;

    }
    public override string ToString()
    {
        return string.Format("我是{0},我的血量是{1},我的勋章是{2}", _name, maxHp, iconSprite);
    }
}
