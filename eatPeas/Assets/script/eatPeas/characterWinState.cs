﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class characterWinState : playerStateBase
{
    public GameObject soliderPoint;
    public override void _AIBaseState(player_move player)
    {
        soliderPoint = player.characterPoint;
        closeNav();
        UI_controller.instance.gameWin.SetActive(true);
    }
    //在人物获胜状态时，关闭敌人的代码
    public void closeNav()
    {
        for (int i = 0; i < soliderPoint.transform.childCount; i++)
        {
            if (soliderPoint.transform.GetChild(i).GetComponent<NavMeshAgent>())
            {
                soliderPoint.transform.GetChild(i).GetComponent<NavMeshAgent>().enabled = false;
                soliderPoint.transform.GetChild(i).GetComponent<soliderTest>().enabled = false;
            }
        }
    }
}
