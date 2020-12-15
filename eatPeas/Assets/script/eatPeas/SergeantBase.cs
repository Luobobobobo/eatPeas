using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SergeantBase : MonoBehaviour
{
    public characterBase character = new characterBase();
    public Vector3 trans;
    public void showMessage()
    {
        character.baseMessage("新兵", 40, " SergeantIcon");
        character.solidSpeed = 5f;
    }
    //获取敌人的初始生成位置
    public void getPos(Vector3 vector)
    {
        this.trans = vector;
        character.originPos = trans;
    }
}
