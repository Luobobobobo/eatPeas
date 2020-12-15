using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookieBase : MonoBehaviour
{
    public characterBase character = new characterBase();
    public Vector3 trans;
    public void showMessage()
    {
        character.baseMessage("中尉士兵", 70, " RookieIcon");
        character.solidSpeed = 8f;
    }
    //获取敌人的初始生成位置
    public void getPos(Vector3 vector)
    {
        this.trans = vector;
        character.originPos = trans;
    }
}
