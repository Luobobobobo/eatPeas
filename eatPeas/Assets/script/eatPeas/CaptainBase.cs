using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptainBase : MonoBehaviour
{
    public characterBase character = new characterBase();
    public Vector3 trans;
    public void showMessage()
    {
        character.baseMessage("上尉士兵", 100, " CaptainIcon");
        character.solidSpeed = 10f;
    }
    //获取敌人的初始生成位置
    public void getPos(Vector3 vector)
    {
        this.trans = vector;
        character.originPos = trans;
    }
}
