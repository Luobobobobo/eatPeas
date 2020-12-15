using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class playerBaseState
{
    public characterBase characterBase;
    public soliderTest solidertest;
    //这个是士兵的基本状态
    public abstract void _AIbaseState(soliderTest solider);

    //给敌人规定移动范围
    public float distanceLimited()
    {
        //choseScript();
        float dis = Vector3.Distance(characterBase.originPos, solidertest.gameObject.transform.position);
        return dis;
    }
    //初始化脚本
    public characterBase choseScript()
    {
        if (solidertest.gameObject.tag == "captain")
        {
            CaptainBase captainBase = solidertest.gameObject.GetComponent<CaptainBase>();
            characterBase = captainBase.character;
        }
        else if (solidertest.gameObject.tag == "rookie")
        {
            RookieBase rookieBase = solidertest.gameObject.GetComponent<RookieBase>();
            characterBase = rookieBase.character;
        }
        else if (solidertest.gameObject.tag == "sergeant")
        {
            SergeantBase SergeantBase = solidertest.gameObject.GetComponent<SergeantBase>();
            characterBase = SergeantBase.character;
        }
        return characterBase;
    }
}
