using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌人的工厂接口
/// </summary>
public abstract class ICharacter
{
    public GameObject peasObj;
    public ICharacter()
    {

    }
    public abstract SergeantBase sergeantBase(GameObject game);
    public abstract RookieBase rookieBase(GameObject game);
    public abstract CaptainBase captainBase(GameObject game);
}
