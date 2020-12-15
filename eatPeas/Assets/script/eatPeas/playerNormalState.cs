using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerNormalState : playerBaseState
{
    //士兵的基础状态
    public override void _AIbaseState(soliderTest solider)
    {
        solidertest = solider;
        choseScript();
        //Debug.Log("敌方士兵正在巡游，请小心绕行！");

        solider.nav.SetDestination(characterBase.originPos);
    }
}
